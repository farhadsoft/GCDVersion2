using System;
using System.Linq;

namespace Gcd
{
    /// <summary>
    /// Provide methods with integers.
    /// </summary>
    public static class IntegerExtensions
    {
        /// <summary>
        /// Calculates GCD of two integers from [-int.MaxValue;int.MaxValue] by the Euclidean algorithm.
        /// </summary>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or two numbers are int.MinValue.</exception>
        public static int GetGcdByEuclidean(int a, int b)
        {
            if (a == 0 && b == 0)
            {
                throw new ArgumentException("Thrown when all numbers are 0 at the same time.");
            }

            if (a == int.MinValue || b == int.MinValue)
            {
                throw new ArgumentOutOfRangeException($"Thrown when one or two numbers are int.MinValue.");
            }

            int result = GCD(a, b);

            return result;
        }

        public static int GCD(int[] numbers)
        {
            return numbers.Aggregate(GCD);
        }

        public static int GCD(int a, int b)
        {
            int result;
            if (b == 0)
            {
                result = a;
            }
            else
            {
                result = GCD(b, a % b);
            }

            return (result < 0) ? Math.Abs(result) : result;
        }

        public static int GcdByStein(int a, int b)
        {
            if (a == 0)
                {
                return b;
            }

            if (b == 0)
                {
                return a;
            }

            if (a == b)
                {
                return a;
            }

            if (a == 1 || b == 1)
                {
                return 1;
            }

            if ((a & 1) == 0)
                {
                return ((b & 1) == 0) ? GcdByStein(a >> 1, b >> 1) << 1 : GcdByStein(a >> 1, b);
            }
            else
            {
                return ((b & 1) == 0) ? GcdByStein(a, b >> 1) : GcdByStein(b, a > b ? a - b : b - a);
            }
        }

        /// <summary>
        /// Calculates GCD of three integers from [-int.MaxValue;int.MaxValue] by the Euclidean algorithm.
        /// </summary>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <param name="c">Third integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByEuclidean(int a, int b, int c)
        {
            if (a == int.MinValue || b == int.MinValue || c == int.MinValue)
            {
                throw new ArgumentOutOfRangeException($"Thrown when one or two numbers are int.MinValue.");
            }

            if (a == 0 && b == 0 && c == 0)
            {
                throw new ArgumentException("All numbers cannot be 0 at the same time.");
            }

            int result = GCD(a, b);
            result = GCD(result, c);

            return result;
        }

        /// <summary>
        /// Calculates the GCD of integers from [-int.MaxValue;int.MaxValue] by the Euclidean algorithm.
        /// </summary>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <param name="other">Other integers.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByEuclidean(int a, int b, params int[] other)
        {
            bool isNull = false;
            if (a == int.MinValue || b == int.MinValue)
            {
                throw new ArgumentOutOfRangeException($"Thrown when one or two numbers are int.MinValue.");
            }

            for (int i = 0; i < other.Length; i++)
            {
                if (other[i] != 0)
                {
                    isNull = false;
                    break;
                }
                else
                {
                    isNull = true;
                }
            }

            if (a == 0 && b == 0 && isNull)
            {
                throw new ArgumentException("All numbers cannot be 0 at the same time.");
            }

            int result = GCD(a, b);
            for (int i = 0; i < other.Length; i++)
            {
                result = GCD(result, other[i]);
            }

            return result;
        }

        /// <summary>
        /// Calculates GCD of two integers [-int.MaxValue;int.MaxValue] by the Stein algorithm.
        /// </summary>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or two numbers are int.MinValue.</exception>
        public static int GetGcdByStein(int a, int b)
        {
            if (a == 0 && b == 0)
            {
                throw new ArgumentException("Thrown when all numbers are 0 at the same time.");
            }

            if (a == int.MinValue || b == int.MinValue)
            {
                throw new ArgumentOutOfRangeException($"Thrown when one or two numbers are int.MinValue.");
            }

            var result = GcdByStein(a, b);

            return (result < 0) ? Math.Abs(result) : result;
        }

        /// <summary>
        /// Calculates GCD of three integers [-int.MaxValue;int.MaxValue] by the Stein algorithm.
        /// </summary>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <param name="c">Third integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByStein(int a, int b, int c)
        {
            if (a == int.MinValue || b == int.MinValue || c == int.MinValue)
            {
                throw new ArgumentOutOfRangeException($"Thrown when one or two numbers are int.MinValue.");
            }

            if (a == 0 && b == 0 && c == 0)
            {
                throw new ArgumentException("All numbers cannot be 0 at the same time.");
            }

            int result = GcdByStein(a, b);
            result = GcdByStein(result, c);

            return (result < 0) ? Math.Abs(result) : result;
        }

        /// <summary>
        /// Calculates the GCD of integers [-int.MaxValue;int.MaxValue] by the Stein algorithm.
        /// </summary>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <param name="other">Other integers.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByStein(int a, int b, params int[] other)
        {
            bool isNull = false;
            if (a == int.MinValue || b == int.MinValue)
            {
                throw new ArgumentOutOfRangeException($"Thrown when one or two numbers are int.MinValue.");
            }

            for (int i = 0; i < other.Length; i++)
            {
                if (other[i] != 0)
                {
                    isNull = false;
                    break;
                }
                else
                {
                    isNull = true;
                }
            }

            if (a == 0 && b == 0 && isNull)
            {
                throw new ArgumentException("All numbers cannot be 0 at the same time.");
            }

            int result = GcdByStein(a, b);
            for (int i = 0; i < other.Length; i++)
            {
                result = GcdByStein(result, other[i]);
            }

            return (result < 0) ? Math.Abs(result) : result;
        }

        /// <summary>
        /// Calculates GCD of two integers from [-int.MaxValue;int.MaxValue] by the Euclidean algorithm with elapsed time.
        /// </summary>
        /// <param name="elapsedTicks">Method execution time in ticks.</param>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or two numbers are int.MinValue.</exception>
        public static int GetGcdByEuclidean(out long elapsedTicks, int a, int b)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            if (a == 0 && b == 0)
            {
                throw new ArgumentException("Thrown when all numbers are 0 at the same time.");
            }

            if (a == int.MinValue || b == int.MinValue)
            {
                throw new ArgumentOutOfRangeException($"Thrown when one or two numbers are int.MinValue.");
            }

            int result = GCD(a, b);
            watch.Stop();
            elapsedTicks = watch.ElapsedMilliseconds;

            return result;
        }

        /// <summary>
        /// Calculates GCD of three integers from [-int.MaxValue;int.MaxValue] by the Euclidean algorithm with elapsed time.
        /// </summary>
        /// <param name="elapsedTicks">Method execution time in ticks.</param>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <param name="c">Third integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByEuclidean(out long elapsedTicks, int a, int b, int c)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            if (a == int.MinValue || b == int.MinValue || c == int.MinValue)
            {
                throw new ArgumentOutOfRangeException($"Thrown when one or two numbers are int.MinValue.");
            }

            if (a == 0 && b == 0 && c == 0)
            {
                throw new ArgumentException("All numbers cannot be 0 at the same time.");
            }

            int result = GCD(a, b);
            result = GCD(result, c);
            watch.Stop();
            elapsedTicks = watch.ElapsedMilliseconds;

            return result;
        }

        /// <summary>
        /// Calculates the GCD of integers from [-int.MaxValue;int.MaxValue] by the Euclidean algorithm with elapsed time.
        /// </summary>
        /// <param name="elapsedTicks">Method execution time in Ticks.</param>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <param name="other">Other integers.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByEuclidean(out long elapsedTicks, int a, int b, params int[] other)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            bool isNull = false;
            if (a == int.MinValue || b == int.MinValue)
            {
                throw new ArgumentOutOfRangeException($"Thrown when one or two numbers are int.MinValue.");
            }

            for (int i = 0; i < other.Length; i++)
            {
                if (other[i] != 0)
                {
                    isNull = false;
                    break;
                }
                else
                {
                    isNull = true;
                }
            }

            if (a == 0 && b == 0 && isNull)
            {
                throw new ArgumentException("All numbers cannot be 0 at the same time.");
            }

            int result = GCD(a, b);
            for (int i = 0; i < other.Length; i++)
            {
                result = GCD(result, other[i]);
            }

            watch.Stop();
            elapsedTicks = watch.ElapsedMilliseconds;
            return result;
        }

        /// <summary>
        /// Calculates GCD of two integers from [-int.MaxValue;int.MaxValue] by the Stein algorithm with elapsed time.
        /// </summary>
        /// <param name="elapsedTicks">Method execution time in ticks.</param>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or two numbers are int.MinValue.</exception>
        public static int GetGcdByStein(out long elapsedTicks, int a, int b)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            if (a == 0 && b == 0)
            {
                throw new ArgumentException("Thrown when all numbers are 0 at the same time.");
            }

            if (a == int.MinValue || b == int.MinValue)
            {
                throw new ArgumentOutOfRangeException($"Thrown when one or two numbers are int.MinValue.");
            }

            var result = GcdByStein(a, b);

            watch.Stop();
            elapsedTicks = watch.ElapsedMilliseconds;
            return (result < 0) ? Math.Abs(result) : result;
        }

        /// <summary>
        /// Calculates GCD of three integers from [-int.MaxValue;int.MaxValue] by the Stein algorithm with elapsed time.
        /// </summary>
        /// <param name="elapsedTicks">Method execution time in ticks.</param>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <param name="c">Third integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByStein(out long elapsedTicks, int a, int b, int c)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            if (a == int.MinValue || b == int.MinValue || c == int.MinValue)
            {
                throw new ArgumentOutOfRangeException($"Thrown when one or two numbers are int.MinValue.");
            }

            if (a == 0 && b == 0 && c == 0)
            {
                throw new ArgumentException("All numbers cannot be 0 at the same time.");
            }

            int result = GcdByStein(a, b);
            result = GcdByStein(result, c);

            watch.Stop();
            elapsedTicks = watch.ElapsedMilliseconds;
            return (result < 0) ? Math.Abs(result) : result;
        }

        /// <summary>
        /// Calculates the GCD of integers from [-int.MaxValue;int.MaxValue] by the Stein algorithm with elapsed time.
        /// </summary>
        /// <param name="elapsedTicks">Method execution time in Ticks.</param>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <param name="other">Other integers.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByStein(out long elapsedTicks, int a, int b, params int[] other)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            bool isNull = false;
            if (a == int.MinValue || b == int.MinValue)
            {
                throw new ArgumentOutOfRangeException($"Thrown when one or two numbers are int.MinValue.");
            }

            for (int i = 0; i < other.Length; i++)
            {
                if (other[i] != 0)
                {
                    isNull = false;
                    break;
                }
                else
                {
                    isNull = true;
                }
            }

            if (a == 0 && b == 0 && isNull)
            {
                throw new ArgumentException("All numbers cannot be 0 at the same time.");
            }

            int result = GcdByStein(a, b);
            for (int i = 0; i < other.Length; i++)
            {
                result = GcdByStein(result, other[i]);
            }

            watch.Stop();
            elapsedTicks = watch.ElapsedMilliseconds;
            return (result < 0) ? Math.Abs(result) : result;
        }
    }
}
