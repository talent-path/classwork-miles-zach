package com.tp.rpg.weapons;

public class Bow extends Weapon{
    @Override
    public int generateDamage() {
        return rng.nextInt(20) + 15;
    }
}
