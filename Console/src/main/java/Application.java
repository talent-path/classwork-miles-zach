public class Application {
    public static void main(String[] args) {
        int age = Console.readInt("Enter your age", 0, 100);
        System.out.println(age);

        double price = Console.readDouble("Enter the price of the product", 0, Double.MAX_VALUE);
        System.out.println(price);
    }
}
