namespace Empty{
    class Program
	{
        static void Main(string[] args){



            var x = FirstMissingPositive([1,2,0]);
        }

        //We're going to reorder the numbers in the array
        //such that all positive numbers are in their matching 
        //index - 1. So 1 is in index 0, 2 is in index 1, ect.
        //Ex: [1,2,-4,4,0,-8,7]
        //Then we just go along the array and return the first
        //number that's not positive. If they're all positive
        //That means every integer in the array was a unique
        //positive int so return Count() + 1;
        public static int FirstMissingPositive(int[] nums) {
            for(int i = 0; i < nums.Count(); i++){
                PutInPlace(nums, i);
            }

            for(int i = 0; i < nums.Count(); i++){
                if(nums[i] != i + 1){
                    return i + 1;
                }
            }


            return nums.Count() + 1;
        }

        private static void PutInPlace(int[] nums, int i){
            
            //If the number is already in it's right place
            //or it's negative, or it's bigger than the
            //number of spaces in the array we don't need
            //to do anything.
            if(nums[i] == i + 1 || nums[i] < 1 || nums[i] > nums.Count()){
                return;
            }
            do{
                int tmp = nums[nums[i] - 1];
                nums[nums[i] - 1] = nums[i];
                i = tmp;
            }while()
        }


        
    }


    // public class TreeNode {
    //     public int val;
    //     public TreeNode left;
    //     public TreeNode right;
    //     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
    //         this.val = val;
    //         this.left = left;
    //         this.right = right;
    //     }
    // }

    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int val=0, ListNode next=null) {
            this.val = val;
            this.next = next;
        }
    }

}