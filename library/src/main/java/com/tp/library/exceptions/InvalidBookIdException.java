package com.tp.library.exceptions;

public class InvalidBookIdException extends Exception {

    public InvalidBookIdException(String message) {
        super(message);
    }

    public InvalidBookIdException(String message, Throwable innerException) {
        super(message, innerException);
    }
}
