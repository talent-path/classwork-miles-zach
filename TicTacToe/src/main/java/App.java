import java.util.NoSuchElementException;
import java.util.Scanner;

public class App {

    static int wins = 0;
    static int losses = 0;
    static int ties = 0;
    static int rounds = 0;
    static int turns = 0;
    static Scanner scanner = new Scanner(System.in);

    public static void main(String[] args) {
        System.out.println("How many rounds would you like to play?");
        try {
            rounds = scanner.nextInt();
        } catch(NoSuchElementException | IllegalArgumentException e) {
            System.out.println("That was an invalid input.");
        }

        Board.initialize();
        while(rounds > 0) {
            if(turns == 9) {
                rounds--;
                ties++;
                turns = 0;
                Board.display();
                System.out.println("You tied!\n");
                Board.initialize();
                continue;
            }
            Board.display();
            Board.askForMove();
            if(Board.checkForWin()) {
                rounds--;
                wins++;
                turns = 0;
                Board.display();
                System.out.println("You win!\n");
                Board.initialize();
                continue;
            }
            Computer.generateMove(Board.moves);
            if(Board.checkForWin()) {
                rounds--;
                losses++;
                turns = 0;
                Board.display();
                System.out.println("You lost!\n");
                Board.initialize();
                continue;
            }

            turns++;

            if(turns > 0) {
               Board.askUser();
            }
        }
        System.out.println("Wins: " + wins + "\nLosses: " + losses + "\nTies: " + ties);
    }
}
