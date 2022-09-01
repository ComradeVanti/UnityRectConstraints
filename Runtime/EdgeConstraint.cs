using System;

namespace Dev.ComradeVanti.RectConstraints
{

    /// <summary>
    ///     A constraint to a specific point on the screen. Used to set start and end
    ///     points for rectangles.
    /// </summary>
    public readonly struct EdgeConstraint
    {

        private readonly float edge;
        private readonly float offset;


        internal EdgeConstraint(float edge, float offset = 0)
        {
            this.edge = edge;
            this.offset = offset;
        }


        public EdgeConstraint WithOffset(float offset) =>
            new EdgeConstraint(edge, offset);

        internal float GetEdge(Side side) =>
            side switch
            {
                Side.Start =>
                    edge + offset,
                Side.End =>
                    edge - offset,
                _ => throw new ArgumentOutOfRangeException(nameof(side), side, null)
            };

    }

}