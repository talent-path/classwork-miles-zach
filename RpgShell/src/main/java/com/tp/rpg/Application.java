package com.tp.rpg;

import com.tp.rpg.armors.Armor;
import com.tp.rpg.armors.Leather;
import com.tp.rpg.armors.Shirt;
import com.tp.rpg.armors.Steel;
import com.tp.rpg.characters.Character;
import com.tp.rpg.characters.Goblin;
import com.tp.rpg.characters.NonPlayerCharacter;
import com.tp.rpg.characters.PlayerCharacter;
import com.tp.rpg.util.Console;
import com.tp.rpg.weapons.Bow;
import com.tp.rpg.weapons.Fist;
import com.tp.rpg.weapons.Sword;
import com.tp.rpg.weapons.Weapon;

import java.util.Random;

public class Application {
    public static void main(String[] args) {

        PlayerCharacter pc = setUpPlayer();
        int battles = 0;
        while( pc.isAlive() ){
            NonPlayerCharacter enemy = setUpEnemy();

            battle( pc, enemy );
            battles++;

        }

        gameOverScreen(battles);

    }

    //walk the user through setting up their character
    private static PlayerCharacter setUpPlayer() {
        int weaponChoice = Console.readInt("Enter a number 0-2 for what type of weapon you would like to equip." +
                        "\n0: Fist\n1: Sword\n2: Bow\n",
                0, 2);
        int armorChoice = Console.readInt("Enter a number 0-2 for what type of armor you would like to equip." +
                        "\n0: Shirt\n1: Leather\n2: Steel\n",
                0, 2);

        Armor armor = selectArmor(armorChoice);
        Weapon weapon = selectWeapon(weaponChoice);
        return new PlayerCharacter(armor, weapon);
    }

    //create some NPC object (with armor & weapons?)
    private static NonPlayerCharacter setUpEnemy() {
        Random rng = new Random();
        Armor armor = selectArmor(rng.nextInt(3));
        Weapon weapon = selectWeapon(rng.nextInt(3));
        return new Goblin(armor, weapon, 50);
    }

    //a and b battle until one is dead
    private static void battle(Character a, Character b) {
        Character attacker = a;
        Character defender = b;

        while( attacker.isAlive() && defender.isAlive() ){
            String userChoice = attacker.makeChoice();
            if( userChoice.equalsIgnoreCase("attack")) {
                attacker.attack(defender);
            } else if(userChoice.equalsIgnoreCase("heal")){
                attacker.drinkPotion();
            } else {
                //block implementation
            }

            Character temp = attacker;
            attacker = defender;
            defender = temp;

            //TODO: display HP status?
            System.out.println(attacker.getClass().getName() + "(" + attacker.getHp() + ")" +
                    " vs. " + defender.getClass().getName() + "(" + defender.getHp() + ")");
        }
    }

    //display some message
    private static void gameOverScreen(int battles) {
        Console.print("You survived " + battles + " battles!");
    }

    private static Armor selectArmor(int armorChoice) {
        Armor armor;
        switch(armorChoice) {
            case 0:
                armor = new Shirt();
                break;
            case 1:
                armor = new Leather();
                break;
            case 2:
                armor = new Steel();
                break;
            default:
                throw new UnsupportedOperationException();
        }
        return armor;
    }

    private static Weapon selectWeapon(int weaponChoice) {
        Weapon weapon;
        switch (weaponChoice) {
            case 0:
                weapon = new Fist();
                break;
            case 1:
                weapon = new Sword();
                break;
            case 2:
                weapon = new Bow();
                break;
            default:
                throw new UnsupportedOperationException();
        }
        return weapon;
    }
}
