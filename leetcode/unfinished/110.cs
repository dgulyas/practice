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
    public bool IsBalanced(TreeNode root) {
        if(root == null){
            return true;
        }

        var depths = GetDepths(root, 0);
        var distinctD = depths.GroupBy(i => i).Select(i => i.Key).ToList();
        return distinctD.Count == 1 || 
            (distinctD.Count == 2 && Math.Abs(distinctD[0] - distinctD[1]) == 1);

    }

    private List<int> GetDepths(TreeNode root, int currentDepth){
        if(root.left == null && root.right == null){
            return new List<int>{currentDepth};
        }
        else{
            var depths = new List<int>();
            if(root.left != null){
                depths.AddRange(GetDepths(root.left, currentDepth +1));
            }
            if(root.right != null){
                depths.AddRange(GetDepths(root.right, currentDepth +1));
            }
            return depths;
        }
    }


    
}