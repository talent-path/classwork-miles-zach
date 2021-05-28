using System;
using RpgGame.Abstractions;
using RpgGame.Concrete.Armors;
using RpgGame.Interfaces;

namespace RpgGame.Concrete
{
    public class Brute : Fighter
    {
        public Brute(int health, string name, IArmor armor, IWeapon weapon, bool hasPotion)
        {
            Health = health;
            Name = name;
            Armor = armor;
            Weapon = weapon;
            HasPotion = hasPotion;
        }

        public Brute()
        {

        }

        public override int Health { get; set; }
        public override string Name { get; set; }
        public override IArmor Armor { get; set; }
        public override IWeapon Weapon { get; set; }
        public override bool HasPotion { get; set; }

        public override int Attack(IFighter defender)
        {
            int dmg = Weapon.Damage + 1;

            return dmg;
        }

        public override void Defend(int incomingDamage)
        {
            int dmg = Armor.ReduceDamage(incomingDamage);
            Health -= dmg;
        }
    }
}
