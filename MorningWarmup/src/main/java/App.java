import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class App {

    public static void main(String[] args) {
//        System.out.println(middleOfThree(1, 2, 3));
//        System.out.println(middleOfThree(1, 3, 2));
//        System.out.println(middleOfThree(2, 1, 3));
//        System.out.println(middleOfThree(2, 3, 1));
//        System.out.println(middleOfThree(3, 1, 2));
//        System.out.println(middleOfThree(3, 2, 1));
//        fizzBuzz();

//        String[] names = { "Rob", "Bob", "Robert", "Bobby", "Alice", "Alicia" };
//        System.out.println(getFirstTwoLetters(names));

//        System.out.println(flipInt(112)); //211
//        System.out.println(flipInt(321)); //123
//        System.out.println(flipInt(100)); //1
//        System.out.println(flipInt(59642)); //24695
//
//        System.out.println(perfectNum(6));
//        System.out.println(perfectNum(496));

        System.out.println(permute(new int[]{1,2,3}));

        //m
    }

    public static int flipInt(int num) {
        int reversed = 0;
        while(num != 0) {
            int digit = num % 10;
            reversed = reversed * 10 + digit;
            num /= 10;
        }
        return reversed;
    }

    public static Map<String, List<String>> getFirstTwoLetters(String[] names) {
        Map<String, List<String>> map = new HashMap<>();
        List<String> namesToAdd;
        for(String name : names) {
            String firstTwoLetters = name.substring(0, 2).toLowerCase();
            namesToAdd = map.getOrDefault(firstTwoLetters, new ArrayList<>());
            namesToAdd.add(name);
            map.put(firstTwoLetters, namesToAdd);
        }
        return map;
    }

    public static int middleOfThree(int a, int b, int c) {
        if(a > b) {
            if(c > a) {
                return a;
            } else if(c > b) {
                return c;
            } else {
                 return b;
            }
        } else {
            if(c > b) {
                return b;
            } else if(c > a) {
                return c;
            } else {
                return a;
            }
        }
    }

    public static void fizzBuzz() {
        for(int i = 1; i <= 100; i++) {
            if(i % 3 == 0 && i % 5 == 0) {
                System.out.println("FizzBuzz");
            } else if(i % 3 == 0) {
                System.out.println("Fizz");
            } else if(i % 5 == 0){
                System.out.println("Buzz");
            } else {
                System.out.println(i);
            }
        }
    }

    public static boolean perfectNum(int num) {
        int sum = 1;
        for(int i = 2; i * i < num; i++) {
            if(num % i == 0) {
                sum += i + (num / i);
            }
        }
        return sum == num;
    }

    public static List<List<Integer>> permute(int[] nums) {
        List<List<Integer>> list = new ArrayList<>();
        // Arrays.sort(nums); // not necessary
        backtrack(list, new ArrayList<>(), nums);
        return list;
    }

    private static void backtrack(List<List<Integer>> list, List<Integer> tempList, int [] nums){
        if(tempList.size() == nums.length){
            list.add(new ArrayList<>(tempList));
        } else{
            for(int i = 0; i < nums.length; i++){
                if(tempList.contains(nums[i])) continue; // element already exists, skip
                tempList.add(nums[i]);
                backtrack(list, tempList, nums);
                tempList.remove(tempList.size() - 1);
            }
        }
    }


}
