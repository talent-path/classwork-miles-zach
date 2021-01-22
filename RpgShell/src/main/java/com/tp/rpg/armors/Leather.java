package com.tp.rpg.armors;

public class Leather implements Armor{
    @Override
    public int reduceDamage(int startingDamage) {
        return startingDamage - 10;
    }
}
