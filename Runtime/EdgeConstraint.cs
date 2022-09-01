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
        private readonly float padding;


        internal EdgeConstraint(float edge, float padding = 0)
        {
            this.edge = edge;
            this.padding = padding;
        }


        public EdgeConstraint WithPadding(float padding) =>
            new EdgeConstraint(edge, padding);

        internal float GetEdge(Side side) =>
            side switch
            {
                Side.Start =>
                    edge + padding,
                Side.End =>
                    edge - padding,
                _ => throw new ArgumentOutOfRangeException(nameof(side), side, null)
            };

    }

}