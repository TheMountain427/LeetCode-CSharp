
public class Solution {
    public int[]? Output;
    public int[] TwoSum(int[] nums, int target) 
    {
        var Target = target;
        var Nums = nums;

        for (int i = 0; i <= (Nums.Length - 1); i++)
        {
            for (int x = 1; x <= (Nums.Length - 1); x++)
            {
                if (i != x && (Nums[i] + Nums[x]) == Target)
                {
                    Output = [i,x];
                    return Output;
                }
            }
        }
        Output = [0,0];
        return Output;

    }
    static void Main(string[] args)
    {
        var sol = new Solution();
        var h = sol.TwoSum([2,5,5,11], 10);
        foreach (int item in h)
        {
            Console.WriteLine($"{item}");
        }
        
    }
}