using UnityEngine;
using static Dev.ComradeVanti.RectConstraints.Util;

namespace Dev.ComradeVanti.RectConstraints
{

    /// <summary>
    ///     Contains methods to constrain rectangles
    /// </summary>
    public static class Constrain
    {

        private static (float Start, float Size) Axis(
            EdgeConstraint? maybeStart,
            SizeConstraint? maybeSize,
            EdgeConstraint? maybeEnd) =>
            (maybeStart, maybeSize, maybeEnd) switch
            {
                (null, null, null) =>
                    empty,
                ({ } start, null, null) =>
                    LineAt(start),
                (null, { } size, null) =>
                    BlockWith(size),
                ({ } start, { } size, null) =>
                    Forward(start, size),
                (null, null, { } end) =>
                    LineAt(end),
                ({ } start, null, { } end) =>
                    StretchBetween(start, end),
                (null, { } size, { } end) =>
                    Backwards(end, size),
                ({ } start, { } size, { } end) =>
                    CenterBetween(start, end, size)
            };

        /// <summary>
        ///     Create a constrained rectangle
        /// </summary>
        /// <param name="top">The top constraint</param>
        /// <param name="right">The right constraint</param>
        /// <param name="bottom">The bottom constraint</param>
        /// <param name="left">The left constraint</param>
        /// <param name="width">The width constraint</param>
        /// <param name="height">The height constraint</param>
        /// <returns>The constrained rectangle</returns>
        public static Rect Rect(
            EdgeConstraint? top = null,
            EdgeConstraint? right = null,
            EdgeConstraint? bottom = null,
            EdgeConstraint? left = null,
            SizeConstraint? width = null,
            SizeConstraint? height = null)
        {
            var (x, w) = Constrain.Axis(left, width, right);
            var (y, h) = Constrain.Axis(top, height, bottom);

            return new Rect(x, y, w, h);
        }

    }

}