using System;
using System.IO;

namespace Spofyp.Core
{
    public class Recorder : IDisposable
    {
        private readonly TrackWatcher Watcher;

        public bool IsRecording
        {
            get;
            private set;
        }
        private bool RecordAll;
        private string DirectoryName;

        public Recording CurrentRecording
        {
            get;
            private set;
        }

        public Recorder(TrackWatcher watcher)
        {
            Watcher = watcher;
            Watcher.TrackChange += Watcher_TrackChange;
        }

        public void Dispose()
        {
            Watcher.TrackChange -= Watcher_TrackChange;

            IsRecording = false;
            StopCurrentRecording();
        }

        private void Watcher_TrackChange(object sender, EventArgs e)
        {
            if (CurrentRecording != null)
            {
                if (!RecordAll)
                {
                    StopRecording();
                    return;
                }
                StopCurrentRecording();
            }

            TryRecord();
        }

        /// <summary>
        /// Starts recording either a single track or a series of tracks as
        /// soon as something is played, which may or may not be immediately.
        /// </summary>
        /// <param name="all">Whether to record all following tracks until
        /// stopped, as opposed to a single track.</param>
        /// <param name="dirName">The path to the destination directory.</param>
        public void StartRecording(bool all, string dirName)
        {
            if (IsRecording)
            {
                throw new InvalidOperationException("already recording");
            }

            IsRecording = true;
            RecordAll = all;
            DirectoryName = dirName;

            Directory.CreateDirectory(dirName);

            TryRecord();
        }

        /// <summary>
        /// Stops the current recording and stops listening for new tracks to
        /// record.
        /// </summary>
        public void StopRecording()
        {
            if (!IsRecording)
            {
                throw new InvalidOperationException("not recording");
            }

            IsRecording = false;

            StopCurrentRecording();
        }

        private void TryRecord()
        {
            if (!IsRecording || Watcher.CurrentTrack == null)
            {
                return;
            }

            var track = Watcher.CurrentTrack;
            var fileName = GetFileName(Watcher.CurrentTrack);
            CurrentRecording = new Recording(track, fileName);

            CurrentRecording.Start();
        }

        private string GetFileName(Track track)
        {
            return Path.Combine(DirectoryName, track.Artist + " - " + track.Title + ".wav");
        }

        private void StopCurrentRecording()
        {
            if (CurrentRecording == null)
            {
                return;
            }

            CurrentRecording.Dispose();
            CurrentRecording = null;
        }
    }
}
