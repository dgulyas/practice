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
    public bool IsSymmetric(TreeNode root) {
        if(root == null){
            return true;
        }
        if(root.left == null && root.right == null){
            return true;
        } else if(root.left != null && root.right != null){
            return IsSymmetric(root.right, root.left);
        }
        
        return false;
    }

    public bool IsSymmetric(TreeNode a, TreeNode b){
        if(a == null && b != null){
            return false;
        }
        if(b == null && a != null){
            return false;
        }

        return (a.val == b.val) 
            && ((a.right == null && b.left == null) || IsSymmetric(a.right, b.left))
            && ((a.left == null && b.right == null) || IsSymmetric(a.left, b.right));
    }
}