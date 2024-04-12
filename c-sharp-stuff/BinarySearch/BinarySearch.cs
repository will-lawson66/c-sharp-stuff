namespace BinarySearch
{
    public class BinarySearch
    {
        public static bool FindInSortedArray(int[] input, int target)
        {
            int left = 0;
            int right = input.Length - 1;
            int iteration = 1;

            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (target == input[mid]) return true;
                iteration++;
                if (target < input[mid])
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return false;
        }
    }
}
