package com.tp.rpg.weapons;

public class Fist extends Weapon {
    @Override
    public int generateDamage() {
        return rng.nextInt(10) + 15;
    }
}
