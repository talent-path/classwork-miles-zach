package com.tp.rpg.characters;

import com.tp.rpg.armors.Armor;
import com.tp.rpg.weapons.Weapon;

//goblins always attack?
public class Goblin extends NonPlayerCharacter {

    public Goblin(Armor armor, Weapon weapon, int hp) {
        super("Goblin", armor, weapon, hp);
    }

    @Override
    public void setArmor(Armor armor) {

    }

    @Override
    public void setHp(int hp) {
        this.hp = hp;
    }

    @Override
    public void drinkPotion() {

    }

    @Override
    public void setWeapon(Weapon weapon) {

    }

    @Override
    public String makeChoice() {
        return "attack";
    }
}
