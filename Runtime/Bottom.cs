using UnityEngine;

namespace Dev.ComradeVanti.RectConstraints
{

    public static partial class Constrain
    {

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

    }

}