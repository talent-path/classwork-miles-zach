package com.tp.library.exceptions;

import java.util.function.Supplier;

public class BookNotFoundException extends Exception implements Supplier<String> {

    public BookNotFoundException(String message, Throwable cause) {
        super(message, cause);
    }

    public BookNotFoundException(String message) {
        super(message);
    }

    public BookNotFoundException() {

    }

    @Override
    public String get() {
        return "Book not found for given id";
    }
}
