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