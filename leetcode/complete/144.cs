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
    public IList<int> PreorderTraversal(TreeNode root) {
        var answer = new List<int>();
        
        if(root == null){
            return answer;
        }

        answer.Add(root.val);
        answer.AddRange(PreorderTraversal(root.left));
        answer.AddRange(PreorderTraversal(root.right));
        return answer;
    }  
}