using UnityEngine;

namespace Dev.ComradeVanti.RectConstraints
{

    public static partial class Constrain
    {

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

    }

}