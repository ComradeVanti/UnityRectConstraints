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

        /// <summary>
        ///     Contains methods to constrain to top edges
        /// </summary>
        public static class ToTop
        {

            /// <summary>
            ///     The top edge of the current window (game-view, editor-window, ...)
            /// </summary>
            public static EdgeConstraint OfWindow =>
                new EdgeConstraint(0);

            /// <summary>
            ///     Constrains to the top edge of the given rectangle
            /// </summary>
            /// <param name="rect">The rectangle</param>
            /// <returns>The created constraint</returns>
            public static EdgeConstraint Of(Rect rect) =>
                new EdgeConstraint(rect.yMin);

        }


        /// <summary>
        ///     Contains methods to constrain to right edges
        /// </summary>
        public static class ToRight
        {

            /// <summary>
            ///     The right edge of the current window (game-view, editor-window, ...)
            /// </summary>
            public static EdgeConstraint OfWindow =>
                new EdgeConstraint(Screen.width);

            /// <summary>
            ///     Constrains to the right edge of the given rectangle
            /// </summary>
            /// <param name="rect">The rectangle</param>
            /// <returns>The created constraint</returns>
            public static EdgeConstraint Of(Rect rect) =>
                new EdgeConstraint(rect.xMax);

        }

        /// <summary>
        ///     Contains methods to constrain to bottom edges
        /// </summary>
        public static class ToBottom
        {

            /// <summary>
            ///     The bottom edge of the current window (game-view, editor-window, ...)
            /// </summary>
            public static EdgeConstraint OfWindow =>
                new EdgeConstraint(Screen.height);

            /// <summary>
            ///     Constrains to the bottom edge of the given rectangle
            /// </summary>
            /// <param name="rect">The rectangle</param>
            /// <returns>The created constraint</returns>
            public static EdgeConstraint Of(Rect rect) =>
                new EdgeConstraint(rect.yMax);

        }

        /// <summary>
        ///     Contains methods to constrain to left edges
        /// </summary>
        public static class ToLeft
        {

            /// <summary>
            ///     The left edge of the current window (game-view, editor-window, ...)
            /// </summary>
            public static EdgeConstraint OfWindow =>
                new EdgeConstraint(0);

            /// <summary>
            ///     Constrains to the left edge of the given rectangle
            /// </summary>
            /// <param name="rect">The rectangle</param>
            /// <returns>The created constraint</returns>
            public static EdgeConstraint Of(Rect rect) =>
                new EdgeConstraint(rect.xMin);

        }

    }

}