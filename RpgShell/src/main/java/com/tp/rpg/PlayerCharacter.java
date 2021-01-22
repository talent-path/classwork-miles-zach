package com.tp.rpg;

import com.tp.rpg.armors.Armor;
import com.tp.rpg.weapons.Weapon;

import java.util.Scanner;

public class PlayerCharacter extends Character {

    private static Scanner scanner = new Scanner(System.in);

    public PlayerCharacter(Armor armor, Weapon weapon) {
        super(armor, weapon);
    }

    //use scanner here to get something from the user
    @Override
    public String makeChoice() {
        Console.print("Would you like to attack or defend?\n");
        String userChoice = scanner.nextLine();
        return userChoice;
    }

    @Override
    public void drinkPotion() {
        int hp = this.getHp();
        this.setHp(hp + 10);
    }
}
