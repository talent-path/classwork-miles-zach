package com.tp.diceroller.service;

import org.springframework.stereotype.Service;

import java.util.Random;

@Service
public class DiceService {

    static Random random = new Random();

    public static int rollDice(int sides) {
        return random.nextInt(sides) + 1;
    }
}
