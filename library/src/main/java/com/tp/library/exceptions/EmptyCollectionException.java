package com.tp.library.exceptions;

public class EmptyCollectionException extends Exception {

    public EmptyCollectionException(String message) {
        super(message);
    }

    public EmptyCollectionException(String message, Throwable cause) {
        super(message, cause);
    }
}
