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

        }

    }

}