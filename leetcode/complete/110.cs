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
    bool isBalanced = true;
    
    public bool IsBalanced(TreeNode root) {
        isBalanced = true;
        IsBalancedR(root);
        return isBalanced;

    }

    //Returns the depth of the subtree starting at root.
    //R for recursive.
    private int IsBalancedR(TreeNode root){
        if(root == null){
            return 0;
        }
        var depthRight = IsBalancedR(root.right);
        var depthLeft = IsBalancedR(root.left);

        if(Math.Abs(depthRight - depthLeft) > 1){
            isBalanced = false;
        }

        return Math.Max(depthRight, depthLeft) + 1;
    }
}