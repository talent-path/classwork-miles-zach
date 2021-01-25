package com.tp.rpg.characters;

import com.tp.rpg.armors.Armor;
import com.tp.rpg.weapons.Weapon;

//TODO:
//      add a concept of hitpoints
//      add a concept of armor (or maybe multiple pieces of armor)
//      add a concept of a weapon (or maybe multiple weapons)
//Stretch goals:
//      add a potion class/interface that the character can drink instead of attacking
//      let the character "disarm" the opponent instead of attacking
//          base this on the weapons used?
//      let the character choose to "block" or "defend"
//          could stun the opponent if they attack?
//          could give us TWO attacks on the next round?
public abstract class Character implements Chooser {

    //TODO: add fields for armor(s) and weapon(s)
    protected String name;
    protected Armor armor;
    protected Weapon weapon;
    protected int hp = 100;

    public Character(String name, Armor armor, Weapon weapon) {
        this.name = name;
        this.armor = armor;
        this.weapon = weapon;
    }

    public Character(String name, Armor armor, Weapon weapon, int hp) {
        this.name = name;
        this.armor = armor;
        this.weapon = weapon;
        this.hp = hp;
    }

    public void attack( Character defender ){
        int damage = defender.getArmor().reduceDamage(weapon.generateDamage());
        defender.takeDamage(damage);
    }


    public void takeDamage( int damage ){
        this.setHp(this.getHp() - damage);
    }

    public boolean isAlive(){
        return hp > 0;
    }

    public void setHp(int hp) {
        this.hp = hp;
    }
    public Armor getArmor() {
        return armor;
    }
    public int getHp() {
        return hp;
    }

    public abstract void drinkPotion();

    public String getName() {
        return name;
    }
}
