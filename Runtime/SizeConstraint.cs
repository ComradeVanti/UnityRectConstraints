namespace Dev.ComradeVanti.RectConstraints
{

    /// <summary>
    ///     A constraint to a specific size. Used to set widths and heights for
    ///     rectangles.
    /// </summary>
    public readonly struct SizeConstraint
    {

        private float Value { get; }


        internal SizeConstraint(float value) =>
            Value = value;


        public static implicit operator float(SizeConstraint c) =>
            c.Value;

    }

}