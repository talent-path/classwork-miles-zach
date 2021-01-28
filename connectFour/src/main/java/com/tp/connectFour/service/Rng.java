package com.tp.connectFour.service;

import java.util.Random;

public class Rng {
    static Random rng = new Random();

    public static int randomIndex( int maxIndexInc ){
        return rng.nextInt(maxIndexInc + 1);
    }
}
