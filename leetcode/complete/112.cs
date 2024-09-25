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
    public bool HasPathSum(TreeNode root, int targetSum) {
        return TravelTree(root, targetSum, 0);
    }

    public bool TravelTree(TreeNode root, int targetSum, int sumSoFar){
        if(root == null){
            return false;
        }
        
        if(root.left == null && root.right == null){
            return sumSoFar + root.val == targetSum;
        }
        
        return TravelTree(root.left, targetSum, sumSoFar + root.val) ||
            TravelTree(root.right, targetSum, sumSoFar + root.val);
    }
}