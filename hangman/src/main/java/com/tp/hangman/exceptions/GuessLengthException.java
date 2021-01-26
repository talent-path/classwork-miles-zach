package com.tp.hangman.exceptions;

public class GuessLengthException extends RuntimeException {
    public GuessLengthException() {
        super("The length of your guess was too long.");
    }
}
