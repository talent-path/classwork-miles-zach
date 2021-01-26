package com.tp.hangman.services;

import com.tp.hangman.exceptions.GuessLengthException;
import com.tp.hangman.models.HangmanGame;
import com.tp.hangman.models.HangmanViewModel;
import com.tp.hangman.persistence.HangmanDao;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;
import org.springframework.stereotype.Service;

import java.util.List;

//handles the logic for the game
//
//    Goal #1: get the service layer to properly censor un-guessed letters from the string that goes into the viewmodel
//
//    Goal #2: prevent the user from making more than 5 incorrect guesses
//
//    (prevent here just means return a null instead of doing work)
//
//    Goal #3: prevent the user from making guesses on a successfully completed game
//    goal #4 would probably be to randomly create some games in dao using a wordlist (there are a bunch online you can look at)
@Component
public class HangmanService {

    @Autowired
    HangmanDao dao;

    public HangmanViewModel getGameById(Integer gameId) {
        HangmanGame game = dao.getGameById( gameId );
        return convertModel( game );
    }


    public HangmanViewModel makeGuess(Integer gameId, String guess) {
        if( guess.length() != 1){
            throw new GuessLengthException();
        }

        if( gameId == null ){
            throw new RuntimeException("Game ID doesn't correspond to any games");
        }

        HangmanGame game = dao.getGameById(gameId);

        //we'll assume here that the dao gives us back a null
        //if there's no matching game
        if( game == null) {
            return null;
        }

        game.getGuessedLetters().add(guess.charAt(0));

        HangmanViewModel model = convertModel(game);

        checkIfGameOver(model, game.getHiddenWord());

        if(model.getGameOver()) {
            return null;
        }


        return model;

    }

    private Integer checkForIncorrectGuesses(HangmanViewModel game) {
        return game.getGuessedLetters().size() - game.getNumberOfCorrectGuesses();
    }

    private void checkIfGameOver(HangmanViewModel hangmanViewModel, String hiddenWord) {
        if(checkForIncorrectGuesses(hangmanViewModel).equals(5)
                || hangmanViewModel.getPartialWord().equals(hiddenWord)) {
            hangmanViewModel.setGameOver(true);
        }
    }


    private HangmanViewModel convertModel(HangmanGame game) {
        //TODO: generate the string with all the letters hidden that have not been guessed
        //and build the view model object (using the setters)

        String partialWord = "";
        //... figure out the logic here
        String hiddenWord = game.getHiddenWord();
        List<Character> guessedLetters = game.getGuessedLetters();
        int correctGuesses = 0;
        for(Character c : hiddenWord.toCharArray()) {
            if(guessedLetters.contains(c)) {
                partialWord += c;
                correctGuesses++;
            } else {
                partialWord += "_";
            }
        }

        HangmanViewModel toReturn = new HangmanViewModel();
        toReturn.setPartialWord( partialWord );
        toReturn.setNumberOfCorrectGuesses(correctGuesses);
        toReturn.setGuessedLetters( game.getGuessedLetters() );

        return toReturn;
    }
}
