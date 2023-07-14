using System;
using System.Collections;
using System.Diagnostics.Metrics;
using System.Text;

namespace sort_homework
{
    #region Vector Structor
    public class VectorDS<T> where T : new()
    {
        private T[] values;
        private int count;
        private int idx;

        public T this[int index]
        {
            get { return values[index]; }
            set { values[index] = value; }
        }

        // Constructor
        public VectorDS()
        {
            values = Array.Empty<T>();
            count = 0;
            idx = -2;
        }
        public VectorDS(int size)
        {
            values = new T[size];
            for (var i = 0; i < size; i++)
                values[i] = new T();
            count = size;
            idx = -1;
        }
        public bool IsEmpty() => count == 0;
        public bool IsFull() => idx == count - 1;
        public void push_back(T value)
        {
            if (IsEmpty())
            {
                ++count;
                idx = 0;
                values = new T[count];
                values[idx] = value;
            }
            else if (IsFull())
            {
                ++count;
                ++idx;
                T[] temp = values;
                values = new T[count];
                for (var i = 0; i < temp.Length; i++)
                    values[i] = temp[i];
                values[idx] = value;
            }
            else
            {
                ++idx;
                values[idx] = value;
            }
        }
    }
    #endregion
    internal class Program
    {
        #region problem 3 => count for range
        static int[] count_sort_3(int[] nums)
        {
            // determine the min and max value
            int mnValue = nums[0], mxValue = nums[0];
            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] < mnValue)
                    mnValue = nums[i];
                if (nums[i] > mxValue)
                    mxValue = nums[i];
            }
            // new value
            int newMax = mxValue - mnValue;
            int[] count = new int[newMax + 1];

            for (var i = 0; i < nums.Length; i++)
            {
                ++count[nums[i] - mnValue];
            }
            // fill the array with the sorted numbers
            int idx = 0;
            for (var i = 0; i <= newMax; i++)
            {
                for (var j = 0; j < count[i]; j++)
                {
                    nums[idx] = i + mnValue;
                    ++idx;
                }
            }
            return nums;
        }
        #endregion

        #region count sort for strings
        static void string_count_sort_v1(ref string[] arr)
        {
            const int size = 26;
            List<List<string>> letter_to_string = new List<List<string>>(size);
            for (var i = 0; i < size; i++)
                letter_to_string.Add(new List<string>());

            for (var i = 0; i < arr.Length; i++)
            {
                letter_to_string[(int)arr[i][0] - 97].Add(arr[i]);
            }

            int idx = 0;
            for (var letter = 0; letter < size; ++letter)
            {
                for (var str_idx = 0; str_idx < letter_to_string[letter].Count; ++str_idx, ++idx)
                {
                    arr[idx] = letter_to_string[letter][str_idx];
                }
            }
        }
        static void string_count_sort_v2(ref string[] arr)
        {
            const int size = 26;
            List<List<List<string>>> letter_to_string = new List<List<List<string>>>(size);
            // initialize my sort Grid
            for(var i = 0; i < size; ++i)
            {
                letter_to_string.Add(new List<List<string>>(size));
                for (var j = 0; j < size; ++j)
                    letter_to_string[i].Add(new List<string>());
            }
            
            for(int name = 0; name < arr.Length; ++name)
            {
                letter_to_string[(int)arr[name][0] - 97][(int)arr[name][1] - 97].Add(arr[name]);
            }

            // put the names back to the array
            int idx = 0;
            for(var f_letter = 0; f_letter < size; ++f_letter)
            {
                for(var s_letter = 0; s_letter < size; ++s_letter)
                {
                    for(var name = 0; name < letter_to_string[f_letter][s_letter].Count; ++name, ++idx)
                    {
                        arr[idx] = letter_to_string[f_letter][s_letter][name];
                    }
                }
            }
        }
        #endregion

        static void Main(string[] args)
        {
            string[] names = new string[] { "axz", "axa", "zzz", "abc", "abe" };

            string_count_sort_v2(ref names);

            foreach (string name in names)
                Console.Write($"{name} ");

            Console.Read();
        }
    }
}