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
    private int sum = 0;
    
    public int SumOfLeftLeaves(TreeNode root) {
        SumLeftLeaves(root, false);
        return sum;
    }

    public void SumLeftLeaves(TreeNode root, bool isLeft){
        if(root.left == null && root.right == null && isLeft){
            sum += root.val;
        }else{
            if(root.left != null){
                SumLeftLeaves(root.left, true);
            }

            if(root.right != null){
                SumLeftLeaves(root.right, false);
            }
        }
    }

}