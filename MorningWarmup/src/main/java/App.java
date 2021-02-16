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

//        System.out.println(permute(new int[]{1,2,3}));

//        System.out.println(canPlaceFlowers(new int[]{1,0,0,0,1,0,0}, 2));

//        System.out.println(advCalculate("(3   +   (3 + 3))"));
//        System.out.println(advCalculate("((3+ 3) / 2)"));
//        System.out.println(advCalculate("((3 + 3) * (2 + 1))"));
        System.out.println(letterCasePermutation("a1b2"));
    }

    public static List<String> letterCasePermutation(String S) {
        List<String> result = new ArrayList<>();
        compute(result, S.toCharArray(), 0);
        return result;
    }

    public static void compute(List<String> result, char[] chars, int i)  {
        if(i == chars.length) {
            result.add(new String(chars));
        } else {
            if(Character.isLetter(chars[i])) {
                chars[i] = Character.toLowerCase(chars[i]);
                compute(result, chars, i + 1);
                chars[i] = Character.toUpperCase(chars[i]);
            }
            compute(result, chars, i + 1);
        }
    }

    public static int advCalculate(String expression) {
        String trimmedExpression = expression.replace(" ", "");
        trimmedExpression = trimmedExpression.substring(1, trimmedExpression.length() - 1);
        int firstIndexOfClosingParenthesis = Integer.MAX_VALUE;
        while(firstIndexOfClosingParenthesis > 0) {
            firstIndexOfClosingParenthesis = trimmedExpression.indexOf(")");
            if(firstIndexOfClosingParenthesis == -1) {
                return calculate(trimmedExpression);
            }
            int indexOfOpeningParenthesis = Integer.MIN_VALUE;
            for (int i = firstIndexOfClosingParenthesis; i >= 0; i--) {
                if (trimmedExpression.charAt(i) == '(') {
                    indexOfOpeningParenthesis = i;
                    break;
                }
            }
            int calc = calculate(trimmedExpression.substring(indexOfOpeningParenthesis + 1, firstIndexOfClosingParenthesis));
            trimmedExpression = trimmedExpression.substring(0, indexOfOpeningParenthesis) + calc + trimmedExpression.substring(firstIndexOfClosingParenthesis + 1);
        }
        return Integer.MIN_VALUE;
    }

    public static int calculate(String expression) {
        String[] numbers = expression.split("[+\\-\\*\\/]");
        String operand = expression.substring(numbers[0].length(), numbers[0].length() + 1);
        Integer num1 = Integer.valueOf(numbers[0]);
        Integer num2 = Integer.valueOf(numbers[1]);
        int answer = Integer.MIN_VALUE;
        switch(operand) {
            case "+":
                answer = num1 + num2;
                break;
            case "*":
                answer = num1 * num2;
                break;
            case "-":
                answer = num1 - num2;
                break;
            case "/":
                answer = num1 / num2;
                break;
        }
        return answer;
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

    public static boolean canPlaceFlowers(int[] flowerbed, int n) {
        if(flowerbed[0] == 0 && flowerbed[1] == 0) {
            flowerbed[0] = 1;
            n--;
        }

        for(int i = 1; i < flowerbed.length - 1 && n > 0; i++) {
            if(flowerbed[i-1] == 0 && flowerbed[i] == 0 && flowerbed[i + 1] == 0) {
                flowerbed[i] = 1;
                n--;
            }
        }

        if(flowerbed[flowerbed.length - 2] == 0 && flowerbed[flowerbed.length - 1] == 0) {
            flowerbed[flowerbed.length - 1] = 1;
            n--;
        }

        return n == 0;
    }


}
