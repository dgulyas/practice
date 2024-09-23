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
    public bool HasPathSum(TreeNode root, int targetSum) {
        if(root == null){
            return false;
        }
        return GetSums(root, targetSum).Exists(s => s == targetSum);
    }

    private List<int> GetSums(TreeNode root, int targetSum){
        var sums = new List<int>();
        
        if(root.left != null){
            sums.AddRange(GetSums(root.left, targetSum));
        }
        if(root.right != null){
            sums.AddRange(GetSums(root.right, targetSum));
        }

        if(sums.Count < 1){
            sums.Add(root.val);
        }else{
            for(int i = 0; i < sums.Count; i++){
                sums[i] += root.val;
            }
        }

        sums = sums.Where(s => s <= targetSum).ToList();
        return sums;
    }
}