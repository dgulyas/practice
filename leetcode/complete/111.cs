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
    public int MinDepth(TreeNode root) {
        if(root == null){
            return 0;
        }

        return MinDepthOfNode(root);
    }

    private int MinDepthOfNode(TreeNode root){
        if(root.left == null && root.right == null){
            return 1;
        }
        
        var depthL = (root.left != null) ? MinDepthOfNode(root.left) : 1000000;
        var depthR = (root.right != null) ? MinDepthOfNode(root.right) : 1000000;
        return 1 + Math.Min(depthL, depthR);
    }
}