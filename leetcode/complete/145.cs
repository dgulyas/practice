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
    public IList<int> PostorderTraversal(TreeNode root) {
        var answer = new List<int>();
        
        if(root == null){
            return answer;
        }

        answer.AddRange(PostorderTraversal(root.left));
        answer.AddRange(PostorderTraversal(root.right));
        answer.Add(root.val);
        return answer;
    }
}