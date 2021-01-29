package com.tp.library.exceptions;

public class EmptyFieldException extends Exception {

    public EmptyFieldException(String message, Throwable ex) {
        super(message, ex);
    }

    public EmptyFieldException(String message) {
        super(message);
    }
}
