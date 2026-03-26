namespace Home_Work
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CanConstruct("aa", "aab")); // true
            Console.WriteLine(FindLucky(new int[] { 2, 2, 3, 3, 3 })); // 3
            Console.WriteLine(LongestOnes(new int[] { 1, 1, 0, 0, 1, 1, 1 }, 1)); // 4
        }

        static bool CanConstruct(string ransomNote, string magazine)
        {
            char[] r = ransomNote.ToCharArray();
            char[] m = magazine.ToCharArray();

            Array.Sort(r);
            Array.Sort(m);

            int i = 0;
            int j = 0;

            while (i < r.Length && j < m.Length)
            {
                if (r[i] == m[j])
                {
                    i++;
                    j++;
                }
                else
                {
                    j++;
                }
            }

            return i == r.Length;
        }



        static int FindLucky(int[] arr)
        {
            Array.Sort(arr);

            int slow = 0;
            int result = -1;

            while (slow < arr.Length)
            {
                int fast = slow;

                while (fast < arr.Length && arr[fast] == arr[slow])
                {
                    fast++;
                }

                int count = fast - slow;

                if (count == arr[slow] && arr[slow] > result)
                {
                    result = arr[slow];
                }

                slow = fast;
            }

            return result;
        }



        static int LongestOnes(int[] nums, int k)
        {
            int left = 0;
            int zeros = 0;
            int max = 0;

            for (int right = 0; right < nums.Length; right++)
            {
                if (nums[right] == 0)
                {
                    zeros++;
                }

                while (zeros > k)
                {
                    if (nums[left] == 0)
                    {
                        zeros--;
                    }
                    left++;
                }

                int length = right - left + 1;

                if (length > max)
                {
                    max = length;
                }
            }

            return max;
        }



    }
}


