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
            EdgeConstraint? startTo,
            SizeConstraint? sizeIs,
            EdgeConstraint? endTo) =>
            (startTo, sizeIs, endTo) switch
            {
                (null, null, null) =>
                    empty,
                ({ } start, null, null) =>
                    LineAt(start, Side.Start),
                (null, { } size, null) =>
                    BlockWith(size),
                ({ } start, { } size, null) =>
                    Forward(start, size),
                (null, null, { } end) =>
                    LineAt(end, Side.End),
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
        /// <param name="topTo">The top constraint</param>
        /// <param name="rightTo">The right constraint</param>
        /// <param name="bottomTo">The bottom constraint</param>
        /// <param name="leftTo">The left constraint</param>
        /// <param name="widthIs">The width constraint</param>
        /// <param name="heightIs">The height constraint</param>
        /// <returns>The constrained rectangle</returns>
        public static Rect Rect(
            EdgeConstraint? topTo = null,
            EdgeConstraint? rightTo = null,
            EdgeConstraint? bottomTo = null,
            EdgeConstraint? leftTo = null,
            SizeConstraint? widthIs = null,
            SizeConstraint? heightIs = null)
        {
            var (x, w) = Constrain.Axis(leftTo, widthIs, rightTo);
            var (y, h) = Constrain.Axis(topTo, heightIs, bottomTo);

            return new Rect(x, y, w, h);
        }

    }

}