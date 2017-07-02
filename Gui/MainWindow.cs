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

        public MainWindow()
        {
            InitializeComponent();

            Load += MainWindow_Load;
            FormClosing += MainWindow_FormClosing;
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            // init watcher
            Watcher = new TrackWatcher();
            UpdateCurrentlyPlaying(Watcher.CurrentTrack);
            Watcher.TrackChange += Watcher_TrackChange;

            // set dest dir value
            DestDir_Input.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic), "Spofyp");

            // init tracks grid
            var tracksData = new DataTable();
            foreach (DataGridViewColumn col in TracksGrid.Columns)
            {
                tracksData.Columns.Add(col.Name);
                col.DataPropertyName = col.Name;
            }
            TracksSource.DataSource = tracksData;
            TracksGrid.Sort(StartedAt, System.ComponentModel.ListSortDirection.Descending);
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Watcher.Dispose();
            Recorder.Dispose();
        }

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
    }
}
