package com.tp.rpg.armors;

public class Steel implements Armor {
    @Override
    public int reduceDamage(int startingDamage) {
        return startingDamage - 15;
    }
}
