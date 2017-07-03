using System;

namespace Spofyp.Core
{
    public class TrackRecordingEventArgs : EventArgs
    {
        public readonly Recording Recording;

        public TrackRecordingEventArgs(Recording rec)
        {
            Recording = rec;
        }
    }
}
