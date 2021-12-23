using System;

#pragma warning disable CA1814
#pragma warning disable S2368

namespace SpiralMatrixTask
{
    /// <summary>
    /// Matrix manipulation.
    /// </summary>
    public static class MatrixExtension
    {
        /// <summary>
        /// Fills the matrix with natural numbers, starting from 1 in the top-left corner, increasing in an inward, clockwise spiral order.
        /// </summary>
        /// <param name="size">Matrix size.</param>
        /// <returns>Filled matrix.</returns>
        /// <exception cref="ArgumentException">Thrown when matrix size less or equal zero.</exception>
        /// <example> size = 3
        ///     1 2 3
        ///     8 9 4
        ///     7 6 5.
        /// </example>
        /// <example> size = 4
        ///     1  2  3  4
        ///     12 13 14 5
        ///     11 16 15 6
        ///     10 9  8  7.
        /// </example>
        public static int[,] GetMatrix(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException($"Size of matrix '{size}' cannot be less or equal zero.");
            }

            int[,] result = new int[size, size];

            for (int x = 0, y = 0, count = 0; size > 0; x += 1, y += 1, size -= 2)
            {
                for (int i = y; i < y + size; i++)
                {
                    result[x, i] = ++count;
                }

                for (int j = x + 1; j < x + size; j++)
                {
                    result[j, y + size - 1] = ++count;
                }

                for (int i = y + size - 2; i >= y; i--)
                {
                    result[x + size - 1, i] = ++count;
                }

                for (int i = x + size - 2; i > x; i--)
                {
                    result[i, y] = ++count;
                }
            }

            return result;
        }
    }
}
