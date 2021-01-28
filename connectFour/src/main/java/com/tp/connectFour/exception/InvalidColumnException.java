package com.tp.connectFour.exception;

public class InvalidColumnException extends Exception {

    public InvalidColumnException(String message, Throwable throwable) {
        super(message, throwable);
    }

    public InvalidColumnException(String message) {
        super(message);
    }
}
