using System;

namespace homeWork2
{
    class Program
    {
        #region suffixSum with for loop
        static int[] SuffixSumLoop(int[] arr, int n)
        {
            // initialize the suffix array
            int[] suffixSum = new int[n];

            /*
              * initial the last element of suffix array
              * with last element of original array
             */
            suffixSum[n - 1] = arr[n - 1];

            // traverse the array from n-2 to 0
            for (var i = n - 2; i >= 0; i--)
            {
                suffixSum[i] = suffixSum[i + 1] + arr[i];
            }
            return suffixSum;
        }
        #endregion

        #region suffixsum with recursion
        static int suffixSumRecursion(int[]arr, int len, int cnt)
        {
            if (cnt == 0)
                return 0;
            else
                return arr[len - 1] + suffixSumRecursion(arr, --len, --cnt);
        }
        #endregion

        #region PrefixSum
        static int prefixSum(int[]arr, int cnt)
        {
            if (cnt == 0)
                return 0;
            else
                return arr[cnt - 1] + prefixSum(arr, --cnt);
        }
        #endregion

        #region Plindrome
        static bool plindrome(int[] arr, int start, int end)
        {
            // the end point
            // if the recursion loop arrived to this piont it is true
            Console.WriteLine($"{arr[start]} {arr[end]}");
            if (start >= end)
                return true;
            if (arr[start] != arr[end])
                return false;
            return plindrome(arr, ++start, --end);
        }
        #endregion

        #region is_prefix => string
        static bool is_prefix(string main, string prefix, int start_pos)
        {
            if (start_pos >= prefix.Length)
                return true;
            if (main[start_pos] != prefix[start_pos])
                return false;
            return is_prefix(main, prefix, ++start_pos);
        }
        #endregion

        #region Sieve of Eratosthenes
        static long count_prime_forloop(int l, long r)
        {
            // initialize the arrayies
            int[] prefix = new int[r + 1];
            bool[] prime = new bool[r + 1];

            for(var p = 2; p*p <= r; p++)
            {
                if (prime[p] == false)
                {
                    for(var i = p*2; i <= r; i+=p)
                    {
                        prime[i] = true;
                    }
                }
            }
            prefix[0] = prefix[1] = 0;
            for(var i = 2; i <= r; i++)
            {
                prefix[i] = prefix[i - 1];
                if (prime[i] == false)
                    prefix[i]++;
            }
            return prefix[r] - prefix[l-1];
        }
        #endregion

        #region count prime by recuresion
        static bool is_prime(long m, long s = 3)
        {
            if (m == 2)
                return true;
            if (m % 2 == 0 || m <= 1)
                return false;
            if (m == s)
                return true;
            if (m % s == 0)
                return false;
            
            return is_prime(m, ++s);
        }
        static long count_prime(long s, long e)
        {
            if (s > e)
                return 0;
            long result = count_prime(++s, e);
            if (is_prime(s))
                ++result;
            return result;
        }
        #endregion

        #region Grid Sum
        static int[] next_dirction(int[,] grid, int row, int col, int ROWS, int COLS)
        {
            if(col < COLS-1 && row < ROWS - 1)
            {
                if (Math.Max(grid[row, col + 1], Math.Max(grid[row + 1, col + 1], grid[row + 1, col])) == grid[row, col + 1])
                {
                    ++col;
                }
                else if (Math.Max(grid[row, col + 1], Math.Max(grid[row + 1, col + 1], grid[row + 1, col])) == grid[row + 1, col + 1])
                {
                    ++row;
                    ++col;
                }
                else if (Math.Max(grid[row, col + 1], Math.Max(grid[row + 1, col + 1], grid[row + 1, col])) == grid[row + 1, col])
                {
                    ++row;
                }
            }
            else if (col == COLS - 1)
            {
                ++row;
            }
            else if (row == ROWS - 1)
            {
                ++col;
            }
            return new int[2] {row, col};
        }
        static int path_sum(int[,] grid, int row, int col, int ROWS, int COLS)
        {
            if (row >= ROWS || col >= COLS)
                return 0;
            int[] arr = next_dirction(grid, row, col, ROWS, COLS);
            int sum = path_sum(grid, arr[0], arr[1], ROWS, COLS);
            return sum + grid[row, col];
        }
        #endregion

        #region fibonacci
        static int fibonacci(int n)
        {
            Console.WriteLine(n);
            if (n <= 1)
                return 1;
            return fibonacci(n-1) + fibonacci(n-2);
        }
        #endregion

        static void Main(string[] args)
        {
            Console.WriteLine(fibonacci(6));
        }
    } 
}
