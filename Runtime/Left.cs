using UnityEngine;

namespace Dev.ComradeVanti.RectConstraints
{

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