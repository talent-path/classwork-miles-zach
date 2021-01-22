package com.tp.rpg.armors;

public class Shirt implements Armor  {
    @Override
    public int reduceDamage(int startingDamage) {
        return startingDamage - 5;
    }
}
