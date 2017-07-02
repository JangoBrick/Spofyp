using NAudio.Wave;
using System;

namespace Spofyp.Core
{
    public class Recording : IDisposable
    {
        public readonly Track Track;
        public readonly string FileName;

        private WasapiLoopbackCapture Capture;
        private WaveFileWriter Writer;
        private bool IsRunning, HasEnded;

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
        }

        private void Capture_DataAvailable(object sender, WaveInEventArgs e)
        {
            Writer.Write(e.Buffer, 0, e.BytesRecorded);
        }
    }
}
