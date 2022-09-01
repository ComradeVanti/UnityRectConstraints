using System;
using UnityEngine;

namespace Dev.ComradeVanti.RectConstraints
{

    /// <summary>
    /// Edge constrains for a specific direction
    /// </summary>
    public class DirectionalEdgeConstraints
    {
        
        private readonly Direction direction;

        
        internal DirectionalEdgeConstraints(Direction direction) => 
            this.direction = direction;

        /// <summary>
        ///     Constrains to the edge of the current window (game-view, editor-window, ...)
        /// </summary>
        public EdgeConstraint OfWindow =>
            new EdgeConstraint(direction switch
            {
                Direction.Top => 0,
                Direction.Right => Screen.width,
                Direction.Bottom => Screen.height,
                Direction.Left => 0,
                _ => throw new ArgumentOutOfRangeException()
            });

        /// <summary>
        ///     Constrains to the edge of the given rectangle
        /// </summary>
        /// <param name="rect">The rectangle</param>
        /// <returns>The created constraint</returns>
        public EdgeConstraint Of(Rect rect) =>
            new EdgeConstraint(direction switch
            {
                Direction.Top => rect.yMin,
                Direction.Right => rect.xMax,
                Direction.Bottom => rect.yMax,
                Direction.Left => rect.xMin,
                _ => throw new ArgumentOutOfRangeException()
            });

    }

}