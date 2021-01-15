import java.util.Scanner;

public class Application {
    public static void main(String[] args) {
//        int[] arr = {82, 95, 71, 6, 34};
//        System.out.println(Aggregate.min(arr));
//        System.out.println(Aggregate.max(arr));
//        System.out.println(Aggregate.sum(arr));
//        System.out.println(Aggregate.average(arr));
//        System.out.println(Aggregate.standardDeviation(arr));

        int ROCK = 0;
        int PAPER = 1;
        int SCISSORS = 2;

        int wins = 0;
        int losses = 0;
        int ties = 0;

        Scanner scanner = new Scanner(System.in);
        boolean playing = true;
        while(playing) {

            System.out.println("0 for ROCK, 1 for PAPER, 2 for SCISSORS.");
            int input = scanner.nextInt();
            int computerChoice = Rng.randInt(0, 2);
            if(input == ROCK) {
                if(computerChoice == ROCK) System.out.println("You tied!");
                else if(computerChoice == PAPER) System.out.println("You lose!");
                else if(computerChoice == SCISSORS) System.out.println("You win!");
            } else if(input == PAPER) {
                if(computerChoice == SCISSORS) System.out.println("You Lose");
                else if(computerChoice == ROCK) System.out.println("You win!");
                else if(computerChoice == PAPER) System.out.println("You tied!");
            } else if(input == SCISSORS) {
                if(computerChoice == PAPER) System.out.println("You win!");
                else if(computerChoice == ROCK) System.out.println("You lose!");
                else if(computerChoice == SCISSORS) System.out.println("You tied!");
            }

            System.out.println("Would you like to continue playing? Y/N");

        }
    }
}
