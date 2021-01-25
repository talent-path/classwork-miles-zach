package com.tp.rpg.characters;

import com.tp.rpg.armors.Armor;
import com.tp.rpg.weapons.Weapon;

public abstract class NonPlayerCharacter extends Character {

    public NonPlayerCharacter(String name, Armor armor, Weapon weapon, int hp) {
        super(name, armor, weapon, hp);
    }

    public abstract void setArmor(Armor armor);

    public abstract void setHp(int hp);

    public abstract void setWeapon(Weapon weapon);

}
