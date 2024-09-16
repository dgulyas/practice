namespace test;

class Program
{
    static void Main(string[] args)
    {
        var tree = new TreeNode(1, new TreeNode(2), new TreeNode(3, new TreeNode(4), new TreeNode(5)));

        var x = LevelOrder(tree);
    }

    public static IList<IList<int>> LevelOrder(TreeNode root) {
        if(root == null){
            return new List<IList<int>>();
        }
        var answer = new List<IList<int>>();
        Queue<TreeNode> que = new Queue<TreeNode>();

        que.Enqueue(root);
        que.Enqueue(null);

        var currentLevel = new List<int>();

        while(que.Count > 1){
            var currentNode = que.Dequeue();
            if(currentNode == null){
                answer.Add(currentLevel);
                currentLevel = new List<int>();
                que.Enqueue(null);
            }else{
                currentLevel.Add(currentNode.val);
                if(currentNode.left != null){
                    que.Enqueue(currentNode.left);
                }
                if(currentNode.right != null){
                    que.Enqueue(currentNode.right);
                }
            }
        }
        answer.Add(currentLevel);
        return answer;
    }
}

public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}
