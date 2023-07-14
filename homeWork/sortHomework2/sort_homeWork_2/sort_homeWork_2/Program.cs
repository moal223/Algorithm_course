using System;
using System.Diagnostics;

namespace sort_homeWork_2
{
 
    internal class Program
    {
        #region Minimum Absolute Difference
        // my code
        public static IList<IList<int>> MinimumAbsDifference(int[] arr)
        {
            List<IList<int>> my_pairs = new List<IList<int>>();
            Array.Sort(arr);
            int difference = Math.Abs(arr[1] - arr[0]);
            my_pairs.Add(new List<int>(2));
            my_pairs[0].Add(arr[0]);
            my_pairs[0].Add(arr[1]);
            int idx = 0;
            
            for (var num = 2; num < arr.Length; num++)
            {
                
                if (Math.Abs(arr[num] - arr[num - 1]) < difference)
                {
                    difference = Math.Abs(arr[num] - arr[num - 1]);
                    my_pairs.Clear();
                    idx = 0;
                    my_pairs.Add(new List<int>(2));
                    my_pairs[idx].Add(arr[num - 1]);
                    my_pairs[idx].Add(arr[num]);
                }
                else if(Math.Abs(arr[num] - arr[num - 1]) == difference)
                {
                    ++idx;
                    my_pairs.Add(new List<int>(2));
                    my_pairs[idx].Add(arr[num-1]);
                    my_pairs[idx].Add(arr[num]);
                }
                
            }
            return my_pairs;
        }
        // leetCode
        public static void CountSort(ref int[] arr)
        {
            int min = arr.Min(), max = arr.Max(), len = arr.Length-1;
            int[] counts = new int[max - min + 1];
            for(var i = 0; i <= len; i++)
                ++counts[arr[i] - min];
            for (var i = max; i >= min; i--)
                for (var j = 0; j < counts[i - min]; j++)
                    arr[len--] = i;
        }
        public static IList<IList<int>> MinimumAbsDifference_v2(int[] arr)
        {
            IList<IList<int>> result = new List<IList<int>>();
            CountSort(ref arr);
            int minDif = Math.Abs(arr[1] - arr[0]); 
            for(var i = 0; i < arr.Length-1; i++)
            {
                int newDif = Math.Abs(arr[i + 1] - arr[i]);
                if (newDif == minDif)
                    result.Add(new List<int>() { arr[i], arr[i + 1] });
                else if(newDif < minDif)
                {
                    result.Clear();
                    result.Add(new List<int>() { arr[i], arr[i + 1] });
                    minDif = newDif;
                }
            }
            return result;
        }
        
        #endregion
        static void Main(string[] args)
        {
            int[] arr = new int[] { 4, 2, 1, 3 };
            IList<IList<int>> hh = MinimumAbsDifference_v2(arr);
        }
    }
}