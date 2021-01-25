package com.tp.rpg.characters;

import com.tp.rpg.util.Console;
import com.tp.rpg.armors.Armor;
import com.tp.rpg.weapons.Weapon;

import java.util.Scanner;

public class PlayerCharacter extends Character {

    private static Scanner scanner = new Scanner(System.in);

    public PlayerCharacter(Armor armor, Weapon weapon) {
        super("Player", armor, weapon);
    }

    //use scanner here to get something from the user
    @Override
    public String makeChoice() {
        Console.print("Would you like to attack, block, or heal?\n");
        String userChoice = scanner.nextLine();
        return userChoice;
    }

    @Override
    public void drinkPotion() {
        if(hp + 10 < 100) this.setHp(hp + 10);
        else this.setHp((100 - hp) + hp);
    }
}
