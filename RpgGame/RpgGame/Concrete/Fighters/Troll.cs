using System;
using RpgGame.Abstractions;
using RpgGame.Concrete.Armors;
using RpgGame.Concrete.Weapons;
using RpgGame.Interfaces;

namespace RpgGame.Concrete
{
    public class Troll : Fighter
    {

        public Troll(int health, string name, IArmor armor, IWeapon weapon, bool hasPotion)
        {
            Health = health;
            Name = name;
            Armor = armor;
            Weapon = weapon;
            HasPotion = hasPotion;
        }

        public Troll()
        {
        }

        public override int Health { get; set; }
        public override string Name { get; set; }
        public override IArmor Armor { get; set; }
        public override IWeapon Weapon { get; set; }
        public override bool HasPotion { get; set; }

        public override int Attack(IFighter toAttack)
        {
            int dmg = Weapon.Damage;

            return dmg;
        }

        public override void Defend(int incomingDamage)
        {
            Health += 1;
            int dmg = Armor.ReduceDamage(incomingDamage);
            Health -= dmg;
        }
    }
}
