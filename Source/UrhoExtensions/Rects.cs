using Urho;

namespace Urho
{
    public static class Rects
    {
        public static IntVector2 Size(this IntRect r)
        {
            return new IntVector2(r.Right - r.Left, r.Bottom - r.Top);
        }

        public static Vector2 Size(this Rect r)
        {
            return r.Max - r.Min;
        }
    }
}
