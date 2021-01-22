package com.tp.rpg;

import com.tp.rpg.armors.Armor;
import com.tp.rpg.weapons.Weapon;

public abstract class NonPlayerCharacter extends Character {

    public NonPlayerCharacter(Armor armor, Weapon weapon, int hp) {
        super(armor, weapon, hp);
    }

    public abstract void setArmor(Armor armor);

    public abstract void setHp(int hp);

    public abstract void setWeapon(Weapon weapon);

}
