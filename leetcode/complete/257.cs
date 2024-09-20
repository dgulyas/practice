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
    public IList<string> BinaryTreePaths(TreeNode root) {
        var answer = new List<string>();
        if(root == null){
            return answer;
        }
        GetPath(root, answer, "");
        return answer;
    }

    private void GetPath(TreeNode node, List<string> answer, string currentPath){
        if(currentPath != ""){
            currentPath += "->";
        }
        currentPath += $"{node.val}";
        if(node.left == null && node.right == null){
            answer.Add(string.Copy(currentPath));
            return;
        }
        if(node.left != null){
            GetPath(node.left, answer, currentPath);
        }
        if(node.right != null){
            GetPath(node.right, answer, currentPath);
        }
    }
}