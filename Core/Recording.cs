using NAudio.Wave;
using System;

namespace Spofyp.Core
{
    public class Recording : IDisposable
    {
        public readonly Track Track;
        public readonly string FileName;

        public DateTime StartedAt
        {
            get;
            private set;
        }
        public DateTime EndedAt
        {
            get;
            private set;
        }
        public TimeSpan Length
        {
            get
            {
                return EndedAt != null ? (EndedAt - StartedAt) : TimeSpan.Zero;
            }
        }

        private WasapiLoopbackCapture Capture;
        private WaveFileWriter Writer;

        public bool IsRunning
        {
            get;
            private set;
        }
        public bool HasEnded
        {
            get;
            private set;
        }

        public Recording(Track track, string fileName)
        {
            Track = track;
            FileName = fileName;
        }

        public void Dispose()
        {
            Stop();
        }

        /// <summary>
        /// Starts streaming the source to the destination file.
        /// </summary>
        public void Start()
        {
            if (IsRunning || HasEnded)
            {
                throw new InvalidOperationException("cannot be restarted");
            }

            IsRunning = true;

            Capture = new WasapiLoopbackCapture();
            Capture.DataAvailable += Capture_DataAvailable;
            Writer = new WaveFileWriter(FileName, Capture.WaveFormat);

            Capture.StartRecording();

            StartedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Stops listening and closes the destination file.
        /// </summary>
        public void Stop()
        {
            if (!IsRunning)
            {
                throw new InvalidOperationException("not running");
            }

            IsRunning = false;
            HasEnded = true;

            Capture.StopRecording();
            Writer.Close();

            Capture.Dispose();
            Writer.Dispose();

            EndedAt = DateTime.UtcNow;
        }

        private void Capture_DataAvailable(object sender, WaveInEventArgs e)
        {
            Writer.Write(e.Buffer, 0, e.BytesRecorded);
        }
    }
}
