import java.util.Arrays;

public class Application {
    public static void main(String[] args) {
//        System.out.println(canBalance(new int[]{1, 2, 3, 4, 4, 3, 2, 1}));
//        System.out.println(canBalance(new int[]{2, 8, 5, 5}));
//        System.out.println(canBalance(new int[]{2, 8, 1, 5, 5}));
//        System.out.println(canBalance(new int[]{2, 8, 1, 5, 5}));
//        int[] left = new int[100];
//        int[] right = new int[100];
//
//        for(int i = 0; i < 100; i++) {
//            left[i] = 9;
//            right[i] = 8;
//        }
//
//        System.out.println(Arrays.toString(addBigNum(left, right)));

        System.out.println(lengthOfLongestSubstring("abcabcbb"));
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

    public static int[] addBigNum(int[] left, int[] right) {
        int[] output = new int[Math.max(left.length, right.length) + 1];
        int remainder = 0;
        int sum;
        for(int i = 0; i < 100; i++) {
            sum = left[i] + right[i];
            if(sum > 9) {
                output[i] = sum % 10 + remainder;
                remainder = 1;
            } else {
                output[i] = sum + remainder;
                remainder = 0;
            }
        }
        output[100] = remainder;
        return output;
    }

    public static int lengthOfLongestSubstring(String s) {
        int length = 0;
        String sub = "";
        for(int i = 0; i < s.length(); i++) {
            //loop through rest of string to see if the current character is present in any of the other substring
            //if it is then store the length of substring and reset its value to the next character in the string
            if(sub.length() > length) length = sub.length();
            String character = s.substring(i, i + 1);
            sub = character;
            for(int j = i + 1; j < s.length(); j++) {
                character = s.substring(j, j + 1);
                if(sub.contains(character)) {
                    break;
                } else {
                    sub += character;
                }
            }
        }
        return length;
    }

}

//if(sub.contains(character)) {
//                    if(length < sub.length()) length = sub.length();
//                    sub = character;
//                } else {
//                    sub += character;
//                }
