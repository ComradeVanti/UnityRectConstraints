using UnityEngine;

namespace Dev.ComradeVanti.RectConstraints
{

    public static partial class Constrain
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

    }

}