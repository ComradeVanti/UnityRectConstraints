namespace Dev.ComradeVanti.RectConstraints
{

    /// <summary>
    ///     A constraint to a specific point on the screen. Used to set start and end
    ///     points for rectangles.
    /// </summary>
    public readonly struct EdgeConstraint
    {

        private float Value { get; }


        public EdgeConstraint(float value) =>
            Value = value;


        public static implicit operator float(EdgeConstraint c) =>
            c.Value;

    }

}