package com.tp.rpg.weapons;

import java.util.Random;

public abstract class Weapon {
    Random rng = new Random();

    //generate some amount of damage to be dealt
    public abstract int generateDamage();

}
