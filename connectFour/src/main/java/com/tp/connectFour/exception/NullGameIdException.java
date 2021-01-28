package com.tp.connectFour.exception;

public class NullGameIdException extends Exception{

    public NullGameIdException(String message){
        super(message);
    }

    public NullGameIdException(String message, Throwable throwable) {
        super(message, throwable);
    }
}
