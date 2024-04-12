namespace ArrayProblems
{
    public class TwoSum
    {
        /// <summary>
        /// THe brute force technique
        /// Complexity is O(n^2)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[]? BruteForce(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[j] == target - nums[i])
                    {
                        return new int[] { i, j };
                    }
                }
            }
            return null;
        }

       public int[]? ArrayFindIndex(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                var idx = Array.FindIndex<int>(nums, x => target - x == nums[i]);
                if (idx != -1 && idx != i) return new int[] { i, idx };
            }
            return null;
        }
    }
}
