using System.Collections.Generic;
using UnityEngine;

namespace Dev.ComradeVanti.RectConstraints
{

    /// <summary>
    ///     Contains useful extension methods for Rects
    /// </summary>
    public static class RectExt
    {

        /// <summary>
        ///     Splits a rectangle into two parts horizontally, according to a ratio
        /// </summary>
        /// <param name="rect">The rectangle to split</param>
        /// <param name="ratio">The ratio. Should be between 0 and 1</param>
        /// <returns>The two rectangles</returns>
        public static (Rect, Rect) Split2Horizontal(this Rect rect, float ratio)
        {
            ratio = Mathf.Clamp(ratio, 0, 1);

            var width1 = rect.width * ratio;
            var width2 = rect.width - width1;

            var rect1 = Constrain.Rectangle(
                top: Constrain.toTop.Of(rect),
                left: Constrain.toLeft.Of(rect),
                bottom: Constrain.toBottom.Of(rect),
                width: Constrain.ToSize(width1));
            var rect2 = Constrain.Rectangle(
                top: Constrain.toTop.Of(rect),
                right: Constrain.toRight.Of(rect),
                bottom: Constrain.toBottom.Of(rect),
                width: Constrain.ToSize(width2));

            return (rect1, rect2);
        }

        /// <summary>
        ///     Splits a rectangle into two parts vertically, according to a ratio
        /// </summary>
        /// <param name="rect">The rectangle to split</param>
        /// <param name="ratio">The ratio. Should be between 0 and 1</param>
        /// <returns>The two rectangles</returns>
        public static (Rect, Rect) Split2Vertical(this Rect rect, float ratio)
        {
            ratio = Mathf.Clamp(ratio, 0, 1);

            var height1 = rect.height * ratio;
            var height2 = rect.height - height1;

            var rect1 = Constrain.Rectangle(
                top: Constrain.toTop.Of(rect),
                left: Constrain.toLeft.Of(rect),
                right: Constrain.toRight.Of(rect),
                height: Constrain.ToSize(height1));
            var rect2 = Constrain.Rectangle(
                left: Constrain.toLeft.Of(rect),
                right: Constrain.toRight.Of(rect),
                bottom: Constrain.toBottom.Of(rect),
                height: Constrain.ToSize(height2));

            return (rect1, rect2);
        }

        /// <summary>
        ///     Split a rectangle into multiple rows
        /// </summary>
        /// <remarks>
        ///     If the rows are too large to fit in the rectangle they will "spill
        ///     out" the bottom
        /// </remarks>
        /// <param name="rect">This rectangle</param>
        /// <param name="count">The number of rows to split into</param>
        /// <param name="minHeight">The minimum-height for each row</param>
        /// <param name="maxHeight">The maximum-height for each row</param>
        /// <returns>The created rows</returns>
        public static IEnumerable<Rect> Rows(this Rect rect, int count, float minHeight = 0, float maxHeight = float.MaxValue)
        {
            if (count <= 0)
                yield break;

            minHeight = Mathf.Max(minHeight, 0);
            maxHeight = Mathf.Max(maxHeight, minHeight);
            var height = Mathf.Clamp(rect.height / count, minHeight, maxHeight);

            for (var i = 0; i < count; i++)
            {
                var y = rect.y + height * i;
                yield return new Rect(rect.x, y, rect.width, height);
            }
        }

        /// <summary>
        ///     Split a rectangle into multiple columns
        /// </summary>
        /// <remarks>
        ///     If the columns are too large to fit in the rectangle they will "spill
        ///     out" on the left
        /// </remarks>
        /// <param name="rect">This rectangle</param>
        /// <param name="count">The number of columns to split into</param>
        /// <param name="minWidth">The minimum-width for each column</param>
        /// <param name="maxWidth">The maximum-width for each column</param>
        /// <returns>The created columns</returns>
        public static IEnumerable<Rect> Columns(this Rect rect, int count, float minWidth = 0, float maxWidth = float.MaxValue)
        {
            if (count <= 0)
                yield break;

            minWidth = Mathf.Max(minWidth, 0);
            maxWidth = Mathf.Max(maxWidth, minWidth);
            var width = Mathf.Clamp(rect.width / count, minWidth, maxWidth);

            for (var i = 0; i < count; i++)
            {
                var x = rect.x + width * i;
                yield return new Rect(x, rect.y, width, rect.height);
            }
        }

        /// <summary>
        ///     Create a rectangle inside this one with the specified padding
        /// </summary>
        /// <param name="rect">This rectangle</param>
        /// <param name="top">The top padding, 0 by default</param>
        /// <param name="right">The right padding, 0 by default</param>
        /// <param name="bottom">The bottom padding, 0 by default</param>
        /// <param name="left">The left padding, 0 by default</param>
        /// <returns>The padded rectangle</returns>
        public static Rect Pad(this Rect rect, float top = 0, float right = 0, float bottom = 0, float left = 0) =>
            Constrain.Rectangle(
                top: Constrain.toTop.Of(rect).WithOffset(top),
                right: Constrain.toRight.Of(rect).WithOffset(right),
                bottom: Constrain.toBottom.Of(rect).WithOffset(bottom),
                left: Constrain.toLeft.Of(rect).WithOffset(left)
            );

        /// <summary>
        ///     Create a rectangle inside this one with the specified padding at the top
        /// </summary>
        /// <param name="rect">This rectangle</param>
        /// <param name="padding">The padding</param>
        /// <returns>The padded rectangle</returns>
        public static Rect PadTop(this Rect rect, float padding) =>
            rect.Pad(top: padding);

        /// <summary>
        ///     Create a rectangle inside this one with the specified padding at the right
        /// </summary>
        /// <param name="rect">This rectangle</param>
        /// <param name="padding">The padding</param>
        /// <returns>The padded rectangle</returns>
        public static Rect PadRight(this Rect rect, float padding) =>
            rect.Pad(right: padding);

        /// <summary>
        ///     Create a rectangle inside this one with the specified padding at the bottom
        /// </summary>
        /// <param name="rect">This rectangle</param>
        /// <param name="padding">The padding</param>
        /// <returns>The padded rectangle</returns>
        public static Rect PadBottom(this Rect rect, float padding) =>
            rect.Pad(bottom: padding);

        /// <summary>
        ///     Create a rectangle inside this one with the specified padding at the left
        /// </summary>
        /// <param name="rect">This rectangle</param>
        /// <param name="padding">The padding</param>
        /// <returns>The padded rectangle</returns>
        public static Rect PadLeft(this Rect rect, float padding) =>
            rect.Pad(left: padding);

        /// <summary>
        ///     Create a rectangle inside this one with the specified padding at the top
        ///     and bottom
        /// </summary>
        /// <param name="rect">This rectangle</param>
        /// <param name="padding">The padding</param>
        /// <returns>The padded rectangle</returns>
        public static Rect PadVertical(this Rect rect, float padding) =>
            rect.Pad(top: padding, bottom: padding);

        /// <summary>
        ///     Create a rectangle inside this one with the specified padding at the left
        ///     and right
        /// </summary>
        /// <param name="rect">This rectangle</param>
        /// <param name="padding">The padding</param>
        /// <returns>The padded rectangle</returns>
        public static Rect PadHorizontal(this Rect rect, float padding) =>
            rect.Pad(left: padding, right: padding);

    }

}