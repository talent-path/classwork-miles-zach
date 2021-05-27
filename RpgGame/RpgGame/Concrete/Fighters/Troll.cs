using System;
using RpgGame.Abstractions;
using RpgGame.Concrete.Armors;
using RpgGame.Concrete.Weapons;
using RpgGame.Interfaces;

namespace RpgGame.Concrete
{
    public class Troll : Fighter
    {

        public Troll(int health, string name, IArmor armor, IWeapon weapon)
        {
            Health = health;
            Name = name;
            Armor = armor;
            Weapon = weapon;
        }

        public Troll()
        {
        }

        public override int Health { get; set; } = 100;
        public override string Name { get; set; } = "Troll";
        public override IArmor Armor { get; set; } = new Shield();
        public override IWeapon Weapon { get; set; } = new Sword();

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
