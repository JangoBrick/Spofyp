namespace Spofyp.Core
{
    public class Track
    {
        public readonly string Title, Artist;

        public Track(string title, string artist)
        {
            Title = title;
            Artist = artist;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var t = (Track)obj;
            return (Title == t.Title) && (Artist == t.Artist);
        }

        public override int GetHashCode()
        {
            return Title.GetHashCode() ^ Artist.GetHashCode();
        }
    }
}
