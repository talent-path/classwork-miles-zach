import java.util.Scanner;

public class Console {

    static Scanner sc = new Scanner(System.in);

    public static int readInt(String msg, int min, int max) {
        int num = readInt(msg);
        while(num >= max || num <= min) {
            num = readInt(msg);
        }
        return num;
    }

    public static int readInt(String msg) {
        boolean valid = false;
        int parsedInt = Integer.MIN_VALUE;
        while(!valid) {
            print(msg);
            String input = sc.nextLine();
            try {
                parsedInt = Integer.parseInt(input);
                valid = true;
            } catch(NumberFormatException e) {
                System.out.println("NumberFormatException caught");
            }
        }
        return parsedInt;
    }

    public static double readDouble(String msg, double min, double max) {
        double num = readDouble(msg);
        while(num <= min || num >= max) {
            System.out.println("That number you provided was less than or equal to the min of " + min +
                    " and greater than or equal to the max of " + max);
            num = readDouble(msg);
        }
        return num;
    }

    public static double readDouble(String msg) {
        double parsedDouble = Double.MIN_VALUE;
        boolean isValid = false;
        while(!isValid) {
            print(msg);
            String userInput = sc.nextLine();
            try {
                parsedDouble = Double.parseDouble(userInput);
                isValid = true;
            } catch(NumberFormatException nfe) {
                System.out.println("NumberFormatException caught");
            }
        }
        return parsedDouble;
    }

    public static void print(String msg) {
        System.out.println(msg);
    }
}
