package com.tp.library.exceptions;

public class NullFieldException extends Exception {

    public NullFieldException(String message, Throwable innerException) {
        super(message, innerException);
    }

    public NullFieldException(String message) {
        super(message);
    }
}
