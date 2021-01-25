package com.tp.rpg.weapons;

public class Sword extends Weapon {
    @Override
    public int generateDamage() {
        return rng.nextInt(30) + 15;
    }
}
