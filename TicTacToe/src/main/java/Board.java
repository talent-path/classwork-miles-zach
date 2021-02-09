import java.util.*;

public class Board {

    static char[] moves = new char[9];
    static StringBuilder board = new StringBuilder();
    static Scanner scanner = new Scanner(System.in);
    static Deque<Integer> userMoves = new ArrayDeque<>();
    static Deque<Integer> computerMoves = new ArrayDeque<>();

    public static void initialize() {
        userMoves.clear();
        computerMoves.clear();
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
        try {
            userMove = Console.readInt("Enter a number corresponding to the space you would like occupy.");
            char space = moves[userMove - 1];
            if(space != 'X' && space != 'O') {
                moves[userMove - 1] = 'X';
                userMoves.push(userMove - 1);
            } else {
                askForMove();
            }
        } catch(NoSuchElementException | IllegalArgumentException e) {
            System.out.println("Sorry that was an invalid input.");
        }
    }

    public static boolean checkForWin() {
        boolean winner = false;
        for(int i = 0; i < 7; i++) {
            if(winner) break;
            else if(i == 4 || i == 5) continue;
            else if(moves[i] != Character.forDigit(i + 1, 10) && i == 0) {
                winner = checkForRowWin(moves[i], i) || checkForColumnWin(moves[i], i) || checkForDiagonalWin(moves[i]);
            } else if(moves[i] != Character.forDigit(i + 1, 10) && i == 1) {
                winner = checkForColumnWin(moves[i], i);
            } else if(moves[i] != Character.forDigit(i + 1, 10) && i == 2) {
                winner = checkForColumnWin(moves[i], i) || checkForDiagonalWin(moves[i]);
            } else if(moves[i] != Character.forDigit(i + 1, 10) && i == 3) {
                winner = checkForRowWin(moves[i], i);
            } else if(moves[i] != Character.forDigit(i + 1, 10) && i == 6) {
                winner = checkForRowWin(moves[i], i);
            }
        }
        return winner;
    }

    public static boolean checkForRowWin(char check, int idx) {
        return moves[idx+1] == check && moves[idx+2] == check;
    }

    public static boolean checkForColumnWin(char check, int idx) {
        return moves[idx+3] == check && moves[idx+6] == check;
    }

    public static boolean checkForDiagonalWin(char check) {
        return moves[4] == check && (moves[6] == check || moves[8] == check);
    }

    public static void askUser() {
        display();
        System.out.println("Would you like to take back your last move? Enter \"yes\" to undo your last turn.");
        String response = scanner.nextLine();
        if(response.equalsIgnoreCase("yes")) {
            int userMove = userMoves.pop();
            int computerMove = computerMoves.pop();
            moves[userMove] = Character.forDigit(userMove + 1, 10);
            moves[computerMove] = Character.forDigit(computerMove + 1, 10);
        }
    }
}


