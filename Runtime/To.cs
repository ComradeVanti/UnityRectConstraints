using UnityEngine;

namespace Dev.ComradeVanti.RectConstraints
{

    /// <summary>
    ///     Contains methods for creating constraints
    /// </summary>
    public static class To
    {

        /// <summary>
        ///     Contains methods to constrain to top edges
        /// </summary>
        public static class Top
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
        public static class Right
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
        public static class Bottom
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
        public static class Left
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