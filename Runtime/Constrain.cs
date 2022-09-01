using UnityEngine;
using static Dev.ComradeVanti.RectConstraints.Util;

namespace Dev.ComradeVanti.RectConstraints
{

    /// <summary>
    ///     Contains methods to constrain rectangles
    /// </summary>
    public static partial class Constrain
    {

        private static (float Start, float Size) Axis(
            EdgeConstraint? startAt,
            SizeConstraint? sizeOf,
            EdgeConstraint? endAt) =>
            (startTo: startAt, sizeIs: sizeOf, endTo: endAt) switch
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
        /// <param name="topAt">The top constraint</param>
        /// <param name="rightAt">The right constraint</param>
        /// <param name="bottomAt">The bottom constraint</param>
        /// <param name="leftAt">The left constraint</param>
        /// <param name="widthOf">The width constraint</param>
        /// <param name="heightOf">The height constraint</param>
        /// <returns>The constrained rectangle</returns>
        public static Rect MakeRectWith(
            EdgeConstraint? topAt = null,
            EdgeConstraint? rightAt = null,
            EdgeConstraint? bottomAt = null,
            EdgeConstraint? leftAt = null,
            SizeConstraint? widthOf = null,
            SizeConstraint? heightOf = null)
        {
            var (x, w) = Constrain.Axis(leftAt, widthOf, rightAt);
            var (y, h) = Constrain.Axis(topAt, heightOf, bottomAt);

            return new Rect(x, y, w, h);
        }

    }

}