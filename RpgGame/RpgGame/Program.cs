using System;

namespace RpgGame
{
    class Program
    {
        static void Main(string[] args)
        {
            //IHealthy
            //Health property(integer)


//INamed
//    Name property



//IFighter
//    Attack(IFighter toAttack)
//    Defend(IFighter attacker, int attackPower)




//IWeapon
//    Damage property
//    Durability property



//IArmor
//    ReduceDamage(int incomingDamage)
//    Durability property





//abstract Fighter




//Brute - should do one extra point of damage
//Ninja - should have a % chance to dodge
//Troll - should regenerate one point of damage every round




//abstract Weapon




//Fists - should always do one point of damage
//Sword - 5 to 10 damage, loses one point of durability with each attack, gets replaced with fists
//Crossbow - 50% chance of 0 damage, 50% chance of 20 damage



//abstract Armor




//shirt -  reduces incoming damage by 1 unless it has lost durability and then 0
//helmet - reduces incoming damage by 1, never loses durability
//shield - 50% to reduce incoming damage to 0, 5% chance to lose 1 durability, when at 0 no reduction




//Let player pick, fighter type, weapon and armor, have them auto-fight randomly generated enemies.they get one point per enemy they defeat
        }
    }
}
