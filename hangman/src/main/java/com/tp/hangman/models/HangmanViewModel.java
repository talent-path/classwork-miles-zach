package com.tp.hangman.models;

import java.util.List;

public class HangmanViewModel {
    String partialWord;
    List<Character> guessedLetters;
    Integer numberOfCorrectGuesses;
    Boolean isGameOver = false;

    public Boolean getGameOver() {
        return isGameOver;
    }

    public void setGameOver(Boolean gameOver) {
        isGameOver = gameOver;
    }

    public void setNumberOfCorrectGuesses(Integer numberOfCorrectGuesses) {
        this.numberOfCorrectGuesses = numberOfCorrectGuesses;
    }

    public Integer getNumberOfCorrectGuesses() {
        return numberOfCorrectGuesses;
    }

    public String getPartialWord() {
        return partialWord;
    }

    public void setPartialWord(String partialWord) {
        this.partialWord = partialWord;
    }

    public List<Character> getGuessedLetters() {
        return guessedLetters;
    }

    public void setGuessedLetters(List<Character> guessedLetters) {
        this.guessedLetters = guessedLetters;
    }
}
