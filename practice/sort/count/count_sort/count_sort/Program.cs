using System;

namespace count_sort
{
    internal class Program
    {
        static int[] count = new int[501];
        #region my code
        static void count_sort_v1(ref int[] arr)
        {
            for(var i = 0; i < arr.Length; i++)
            {
                ++count[arr[i]];
            }
            int idx = 0;
            for(var i = 0; i < count.Length; i++)
            {
                for(var j = 0; j < count[i]; j++)
                {
                    arr[idx] = i;
                    ++idx;
                }
            }
        }
        #endregion
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 10, 0, 100, 100, 6, 125, 20, 8, 99, 17, 125 };
            count_sort_v1(ref arr);
            for (var i = 0; i < arr.Length; i++)
                Console.Write($"{arr[i]} ");
        }
    }
}