using Microsoft.WindowsAPICodePack.Dialogs;
using Spofyp.Core;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Spofyp.Gui
{
    public partial class MainWindow : Form
    {
        private TrackWatcher Watcher;
        private Recorder Recorder;
        private DataTable TracksData;

        public MainWindow()
        {
            InitializeComponent();

            Load += MainWindow_Load;
            FormClosing += MainWindow_FormClosing;
        }

        // FORM EVENTS

        private void MainWindow_Load(object sender, EventArgs e)
        {
            // init watcher
            Watcher = new TrackWatcher();
            UpdateCurrentlyPlaying(Watcher.CurrentTrack);
            Watcher.TrackChange += Watcher_TrackChange;

            // init recorder
            Recorder = new Recorder(Watcher);
            Recorder.RecordingStateChanged += Recorder_RecordingStateChanged;
            Recorder.TrackRecordingStarted += Recorder_TrackRecordingStarted;
            Recorder.TrackRecordingFinished += Recorder_TrackRecordingFinished;

            // set dest dir value
            DestDir_Input.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic), "Spofyp");

            // init tracks grid
            TracksData = new DataTable();
            foreach (DataGridViewColumn col in TracksGrid.Columns)
            {
                TracksData.Columns.Add(col.Name);
                col.DataPropertyName = col.Name;
            }
            TracksSource.DataSource = TracksData;
            TracksGrid.Sort(StartedAt, System.ComponentModel.ListSortDirection.Descending);

            // update state
            UpdateRecordingState();
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Watcher.Dispose();
            Recorder.Dispose();
        }

        // TRACK CHANGE EVENT

        private void Watcher_TrackChange(object sender, EventArgs e)
        {
            UpdateCurrentlyPlaying(Watcher.CurrentTrack);
        }

        private void UpdateCurrentlyPlaying(Track track)
        {
            if (CurrentlyPlaying_Value.InvokeRequired)
            {
                Invoke(new Action<Track>(UpdateCurrentlyPlaying), new[] { track });
                return;
            }

            if (track == null)
            {
                CurrentlyPlaying_Value.Text = "(none)";
            } else
            {
                CurrentlyPlaying_Value.Text = "\"" + track.Title + "\" by " + track.Artist;
            }
        }

        // DESTINATION DIRECTORY EVENTS

        private void DestDir_Button_Choose_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog()
            {
                InitialDirectory = DestDir_Input.Text,
                IsFolderPicker = true,
                RestoreDirectory = true,
            };

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                DestDir_Input.Text = dialog.FileName;
            }
        }

        private void DestDir_Button_Open_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", DestDir_Input.Text);
        }

        // RECORDING BUTTON EVENTS, STATE MANAGEMENT

        private void Record_Button_Once_Click(object sender, EventArgs e)
        {
            Recorder.StartRecording(false, DestDir_Input.Text);
        }

        private void Record_Button_All_Click(object sender, EventArgs e)
        {
            Recorder.StartRecording(true, DestDir_Input.Text);
        }

        private void Record_Button_Stop_Click(object sender, EventArgs e)
        {
            Recorder.StopRecording();
        }

        private void Recorder_RecordingStateChanged(object sender, EventArgs e)
        {
            UpdateRecordingState();
        }

        private void UpdateRecordingState()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(UpdateRecordingState));
                return;
            }

            bool recording = Recorder.IsRecording;

            Record_Button_Once.Enabled = !recording;
            Record_Button_All.Enabled = !recording;

            Record_Button_Stop.Enabled = recording;

            DestDir_Button_Choose.Enabled = !recording;

            if (recording)
            {
                Record_Button_Stop.Focus();
            } else
            {
                if (Recorder.RecordAll)
                {
                    Record_Button_All.Focus();
                } else
                {
                    Record_Button_Once.Focus();
                }
            }
        }

        // RECORDER TRACK EVENTS

        private void Recorder_TrackRecordingStarted(object sender, TrackRecordingEventArgs e)
        {
            AddToTrackList(e.Recording, false);
        }

        private void Recorder_TrackRecordingFinished(object sender, TrackRecordingEventArgs e)
        {
            AddToTrackList(e.Recording, true);
        }

        private void AddToTrackList(Recording rec, bool replace)
        {
            if (TracksGrid.InvokeRequired)
            {
                Invoke(new Action<Recording, bool>(AddToTrackList), new object[] { rec, replace });
                return;
            }

            if (replace && TracksData.Rows.Count > 0)
            {
                TracksData.Rows.RemoveAt(TracksData.Rows.Count - 1);
            }

            DataRow row = TracksData.NewRow();

            row[Status.DataPropertyName] = rec.HasEnded ? "Done" : "Recording";
            row[Artist.DataPropertyName] = rec.Track.Artist;
            row[Title.DataPropertyName] = rec.Track.Title;
            row[Length.DataPropertyName] = rec.HasEnded ? rec.Length.ToString("mm\\:ss") : "";
            row[StartedAt.DataPropertyName] = rec.StartedAt;

            TracksData.Rows.Add(row);

            TracksGrid.ClearSelection();
            TracksGrid.Rows[0].Selected = true;
        }
    }
}
