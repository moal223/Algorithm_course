using System;
 
namespace Selection_sort
{
    class Program
    {
        #region my_code
        static void selection_sort_v1(ref int[] arr)
        {
            for(var i = 0; i < arr.Length - 1; i++) // 2 6 4 8 3 9 7 
            {
                for(var j = i+1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[i])
                        (arr[i], arr[j]) = (arr[j], arr[i]);
                }
            }
        }
        #endregion
        static void Main(string[] args)
        {
            int[] arr = new int[7] { 2, 6, 4, 8, 3, 9, 7 };
            selection_sort_v1(ref arr);
            for(var i = 0; i < 7; i++)
            {
                Console.Write($"{arr[i]} ");
            }
        }
    }
}