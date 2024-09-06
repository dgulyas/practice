/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */

public class Solution {
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        var currentNode = root;
        while(true){
            if(currentNode.val == p.val){
                return p;
            }
            if(currentNode.val == q.val){
                return q;
            }
            if(currentNode.val > p.val && currentNode.val < q.val){
                return currentNode;
            }
            if(currentNode.val < p.val && currentNode.val > q.val){
                return currentNode;
            }
            if(currentNode.val > p.val && currentNode.val > q.val){
                currentNode = currentNode.left;
            }
            if(currentNode.val < p.val && currentNode.val < q.val){
                currentNode = currentNode.right;
            }
        }
    }
}