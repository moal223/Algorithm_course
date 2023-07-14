using System;

namespace HomeWrok2{
    class Program{
        
        #region countSort
        static int[] countSort(int[] arr){
            int max_value = arr[0], size = arr.Length;

            // Max Value
            for(var i = 1; i < size; i++){
                if(arr[i] > max_value)
                    max_value = arr[i];
            }

            int[] temp = new int[max_value+1];
            Array.Clear(temp, 0, temp.Length);
            for(var i = 0; i < size; i++){
                ++temp[arr[i]];
            }

            int idx = 0;
            for(var i = 0; i < max_value+1; i++){
                for(var j = 0; j < temp[i]; j++, idx++){
                    arr[idx] = i;
                    
                }
            }
            return arr;
        }
        public static int[] SortArray(int[] nums){
            int[] arr = new int[100002];
            int size = nums.Length, idx = 0;

            Array.Clear(arr, 0, arr.Length);
            for(var i = 0; i < size; i++){
                if(nums[i] >= 0)
                    ++arr[nums[i]];
                else // 100001
                    ++arr[100001+nums[i]];
            }

            for(var i = 50001; i < 100002; i++){
                for(var j = 0; j < arr[i]; j++, idx++){
                    nums[idx] = i-100001;
                }
            }
            for(var i = 0; i < 50001 ; i++){
                for(var j = 0; j < arr[i]; j++, idx++){
                    nums[idx] = i;
                }
            }

            return nums;
        }
        #endregion

        public static void Main(string[] args)
        {
            
            
            Console.Read();
        }
    }
}
