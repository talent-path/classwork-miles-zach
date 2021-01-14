import java.util.Random;

public class Computer {

    static Random rng = new Random();

    public static void generateMove(char[] moves) {
        int computerMove = rng.nextInt(9);
        while(moves[computerMove] == 'X' || moves[computerMove] == 'O') {
            computerMove = rng.nextInt(9);
        }
        Board.moves[computerMove] = 'O';
    }
}
