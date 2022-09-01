using UnityEngine;
using static Dev.ComradeVanti.RectConstraints.Util;

namespace Dev.ComradeVanti.RectConstraints
{

    /// <summary>
    ///     Contains methods to constrain rectangles
    /// </summary>
    public static class Constrain
    {

        public static readonly DirectionalEdgeConstraints toTop =
            new DirectionalEdgeConstraints(Direction.Top);

        public static readonly DirectionalEdgeConstraints toRight =
            new DirectionalEdgeConstraints(Direction.Right);

        public static readonly DirectionalEdgeConstraints toBottom =
            new DirectionalEdgeConstraints(Direction.Bottom);

        public static readonly DirectionalEdgeConstraints toLeft =
            new DirectionalEdgeConstraints(Direction.Left);


        private static (float Start, float Size) Axis(
            EdgeConstraint? startConstraint,
            SizeConstraint? sizeConstraint,
            EdgeConstraint? endConstraint) =>
            (startConstraint, sizeConstraint, endConstraint) switch
            {
                (null, null, null) =>
                    empty,
                ({ } start, null, null) =>
                    Util.LineAt(start, Side.Start),
                (null, { } size, null) =>
                    Util.BlockWith(size),
                ({ } start, { } size, null) =>
                    Util.Forward(start, size),
                (null, null, { } end) =>
                    Util.LineAt(end, Side.End),
                ({ } start, null, { } end) =>
                    Util.StretchBetween(start, end),
                (null, { } size, { } end) =>
                    Util.Backwards(end, size),
                ({ } start, { } size, { } end) =>
                    Util.CenterBetween(start, end, size)
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
        public static Rect Rectangle(
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