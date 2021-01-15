public class App {

    public static void main(String[] args) {
        System.out.println(middleOfThree(1, 2, 3));
        System.out.println(middleOfThree(1, 3, 2));
        System.out.println(middleOfThree(2, 1, 3));
        System.out.println(middleOfThree(2, 3, 1));
        System.out.println(middleOfThree(3, 1, 2));
        System.out.println(middleOfThree(3, 2, 1));
        fizzBuzz();
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
}
