package com.tp.library.exceptions;

public class MissingAuthorException extends Exception {

    public MissingAuthorException(String message) {
        super(message);
    }

    public MissingAuthorException(String message, Throwable cause) {
        super(message, cause);
    }
}
