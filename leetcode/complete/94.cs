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
    public IList<int> InorderTraversal(TreeNode root) {
        return Traversal(root);
    }

    private List<int> Traversal(TreeNode root){
        if(root == null){
            return new List<int>();
        }
        var list = Traversal(root.left);
        list.AddRange(new List<int>{root.val});
        list.AddRange(Traversal(root.right));
        return list;
    }
}