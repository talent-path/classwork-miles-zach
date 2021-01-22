import java.util.HashMap;
import java.util.Map;

public class Application {

    static final Map<Integer, Integer> previousResults = new HashMap<>();

    public static void main(String[] args) {
//        long maxSteps = 0;
//        int collatzNum = 0;
//        for(int i = 500000; i <= 1000000; i++) {
//            long num = i;
//            long steps = 0;
//            while(num != 1) {
//                if(num % 2 == 0) {
//                    num /= 2;
//                } else {
//                    num = num * 3 + 1;
//                }
//                steps++;
//            }
//            if(steps > maxSteps) {
//                maxSteps = steps;
//                collatzNum = i;
//            }
//        }
        System.out.println(collatzNum(1000000));
    }

    public static int collatzNum(int n) {
        int result = 1;
        if(previousResults.containsKey(n)) return previousResults.get(n);
        else {
            if(n == 1) {
                result = 1;
            } else if(n % 2 == 0){
                result += collatzNum(n / 2);
            } else {
                result += collatzNum(n * 3 + 1);
            }
            previousResults.put(n, result);
            return result;
        }
    }
}
