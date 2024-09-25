/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public TreeNode SortedArrayToBST(int[] nums) {
        return MakeTree(nums, 0, nums.Length - 1);
    }

    private TreeNode MakeTree(int[] nums, int start, int end){
        var middle = GetMiddle(start, end);
        var node = new TreeNode(nums[middle]);
        if(start != end){
            node.left = MakeTree(nums, start, middle - 1);
            if(middle < end){
                node.right = MakeTree(nums, middle + 1, end);
            }
        }

        return node;
    }

    private int GetMiddle(int start, int end){
        var half = ((end - start) / 2) + start;
                
        if((end - start) % 2 == 1)
        {//odd length
            return half + 1;
        }
        else
        {//even length
            return half;
        }
    }
}