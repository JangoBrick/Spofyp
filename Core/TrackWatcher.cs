using System;
using WindowTitleWatcher;
using WindowTitleWatcher.Util;

namespace Spofyp.Core
{
    public class TrackWatcher : IDisposable
    {
        private RecurrentWatcher watcher;

        public Track CurrentTrack
        {
            get;
            private set;
        }
        public event EventHandler TrackChange;

        public TrackWatcher()
        {
            watcher = new RecurrentWatcher(() => Windows.FindFirst(IsMatchingWindow));
            Update(watcher.Title);
            watcher.TitleChanged += Watcher_TitleChanged;
        }

        public void Dispose()
        {
            watcher.Dispose();
        }

        private void Watcher_TitleChanged(object sender, TitleEventArgs e)
        {
            Update(e.NewTitle);
        }

        private void Update(string title)
        {
            Track prev = CurrentTrack;
            CurrentTrack = Parse(title);

            if (CurrentTrack != prev)
            {
                TrackChange?.Invoke(this, EventArgs.Empty);
            }
        }

        private Track Parse(string title)
        {
            if (title == null)
            {
                return null;
            }

            int index = title.IndexOf(" - ");
            if (index < 0)
            {
                return null;
            }
            
            string artist = title.Substring(0, index);
            string name = title.Substring(index + 3);

            return new Track(name, artist);
        }

        private bool IsMatchingWindow(WindowInfo window)
        {
            if (!window.IsVisible)
            {
                return false;
            }

            string name = window.ProcessName;
            string nameHalf = name.Substring(name.Length / 2);

            return Hash(name) == 1683649665141281877 && Hash(nameHalf) == 17050863026783743523;
        }

        private static ulong Hash(string s)
        {
            ulong p = 16777619;
            ulong v = 2166136261;

            for (int i = 0; i < s.Length; ++i)
            {
                v = (v ^ s[i]) * p;
            }

            return v;
        }
    }
}
