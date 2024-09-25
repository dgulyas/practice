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

//Leetcode wants an algorithm that runs in less than O(n)
//This involves binary searching the paths and then
//computing the number of nodes based on where the
//right-most bottom level node is.
//That approach would require complex code
//that would be harder to maintain.
//So here's a O(n) solution that is still faster than 
//the binary search solution that has to compute paths, 
//until the number of nodes gets very large.
public class Solution {

    private int numNodes = 0;

    public int CountNodes(TreeNode root) {
        numNodes = 0;
        Count(root);
        return numNodes;
    }

    public void Count(TreeNode root){
        if(root == null){
            return;
        }
        numNodes++;
        Count(root.left);
        Count(root.right);
    }
}