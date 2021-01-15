public class Application {
    public static void main(String[] args) {
        System.out.println(canBalance(new int[]{1, 2, 3, 4, 4, 3, 2, 1}));
        System.out.println(canBalance(new int[]{2, 8, 5, 5}));
        System.out.println(canBalance(new int[]{2, 8, 1, 5, 5}));
//        System.out.println(canBalance(new int[]{2, 8, 1, 5, 5}));
    }

    public static boolean canBalance(int[] nums) {
        //return true if we can split array so that earlier numbers equal later half

        //get sum of entire array if odd then cannot be balanced then use half of sum (if even) to see if a portion of the
        //array will add up to this number
        int sum = 0;
        for(int i = 0; i < nums.length; i++) {
            sum += nums[i];
        }
        if(sum % 2 != 0) return false;

        int halfSum = sum / 2;
        int portionSum = 0;
        boolean isBalanced = false;
        for(int i = 0; i < nums.length; i++) {
            portionSum += nums[i];
            if(portionSum == halfSum) {
                isBalanced = true;
                break;
            }
            if(portionSum > halfSum) isBalanced = false;
        }
        return isBalanced;
    }
}
