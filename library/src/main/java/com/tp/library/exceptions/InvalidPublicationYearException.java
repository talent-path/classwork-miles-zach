package com.tp.library.exceptions;

public class InvalidPublicationYearException extends Exception {

    public InvalidPublicationYearException(String message, Throwable ex) {
        super(message, ex);
    }

    public InvalidPublicationYearException(String message) {
        super(message);
    }
}
