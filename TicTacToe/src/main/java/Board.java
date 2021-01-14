import java.util.NoSuchElementException;
import java.util.Scanner;

public class Board {

    static char[] moves = new char[9];
    static StringBuilder board = new StringBuilder();
    static Scanner scanner = new Scanner(System.in);

    public static void initialize() {
        for(int i = 0; i < moves.length; i++) {
            moves[i] = Character.forDigit(i + 1, 10);
        }
    }

    public static void display() {
        board = new StringBuilder();
        for(int i = 0; i < moves.length; i++) {
            if(i == 2 || i == 5) {
                board.append(moves[i] + "\n---------\n");
            } else if(i == 8) {
                board.append(moves[i] + "\n");
            }
            else {
                board.append(moves[i] + " | ");
            }
        }
        System.out.println(board.toString());
    }

    public static void askForMove() {
        int userMove;
        System.out.println("Enter a number corresponding to the space you would like occupy.");
        try {
            userMove = scanner.nextInt();
            char space = moves[userMove - 1];
            if(space != 'X' && space != 'O') {
                moves[userMove - 1] = 'X';
            } else {
                askForMove();
            }
        } catch(NoSuchElementException | IllegalArgumentException e) {
            System.out.println("Sorry that was an invalid input.");
            askForMove();
        }
    }

    public static boolean checkForWin() {
        boolean winner = false;
        for(int i = 0; i < 7; i++) {
            if(winner) break;
            else if(i == 4 || i == 5) continue;
            else if(moves[i] != Character.forDigit(i + 1, 10) && i == 0) {
                winner = checkForRowWin(moves[i], i) || checkForColumnWin(moves[i], i) || checkForDiagonalWin(moves[i], i);
            } else if(moves[i] != Character.forDigit(i + 1, 10) && i == 1) {
                winner = checkForColumnWin(moves[i], i);
            } else if(moves[i] != Character.forDigit(i + 1, 10) && i == 2) {
                winner = checkForColumnWin(moves[i], i) || checkForDiagonalWin(moves[i], i);
            } else if(moves[i] != Character.forDigit(i + 1, 10) && i == 3) {
                winner = checkForRowWin(moves[i], i);
            } else if(moves[i] != Character.forDigit(i + 1, 10) && i == 6) {
                winner = checkForRowWin(moves[i], i);
            }
        }
        return winner;
    }

    public static boolean checkForRowWin(char check, int idx) {
        boolean win = true;
        for(int i = idx + 1; i < idx + 3; i++) {
            if(moves[i] != check) {
                win = false;
                break;
            }
        }
        return win;
    }

    public static boolean checkForColumnWin(char check, int idx) {
        boolean win = true;
        for(int i = idx; i < idx + 6; i += 3) {
            if(moves[i] != check) {
                win = false;
                break;
            }
        }
        return win;
    }

    public static boolean checkForDiagonalWin(char check, int idx) {
        return moves[4] == check && (moves[6] == check || moves[8] == check);
    }
}
