namespace Dev.ComradeVanti.RectConstraints
{

    internal static class Util
    {

        public static readonly (float Start, float Size) empty = (0, 0);


        private static float DistanceBetween(EdgeConstraint start, EdgeConstraint end) =>
            end.GetEdge(Side.End) - start.GetEdge(Side.Start);

        private static float CenterOf(EdgeConstraint start, EdgeConstraint end) =>
            start.GetEdge(Side.Start) + Util.DistanceBetween(start, end) / 2;

        public static (float Start, float Size) CenterBetween(
            EdgeConstraint start, EdgeConstraint end, SizeConstraint size)
        {
            var center = Util.CenterOf(start, end);
            return (center - size / 2f, size);
        }

        public static (float Start, float Size) Forward(
            EdgeConstraint start, SizeConstraint size) =>
            (start.GetEdge(Side.Start), size);

        public static (float Start, float Size) Backwards(
            EdgeConstraint end, SizeConstraint size) =>
            (end.GetEdge(Side.End) - size, size);

        public static (float Start, float Size) StretchBetween(
            EdgeConstraint start, EdgeConstraint end) =>
            (start.GetEdge(Side.Start), DistanceBetween(start, end));

        public static (float Start, float Size) LineAt(EdgeConstraint line, Side side) =>
            (line.GetEdge(side), 0);

        public static (float Start, float Size) BlockWith(SizeConstraint size) =>
            (0, size);

    }

}