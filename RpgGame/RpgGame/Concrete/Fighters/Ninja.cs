using System;
using RpgGame.Abstractions;
using RpgGame.Concrete.Armors;
using RpgGame.Concrete.Weapons;
using RpgGame.Interfaces;

namespace RpgGame.Concrete
{
    public class Ninja : Fighter
    {
        public Random random = new Random();

        public override int Health { get; set; } = 100;
        public override string Name { get; set; } = "Ninja";
        public override IArmor Armor { get; set; } = new Shirt();
        public override IWeapon Weapon { get; set; } = new Crossbow();

        public Ninja(int health, string name, IArmor armor, IWeapon weapon)
        {
            Health = health;
            Name = name;
            Armor = armor;
            Weapon = weapon;
        }

        public Ninja()
        {

        }

        public override void Defend(int incomingDamage)
        {
            int x = random.Next(3);

            if (x == 2)
            {
                incomingDamage = 0;
            }
            else
            {
                int dmg = Armor.ReduceDamage(incomingDamage);
                Health -= dmg;
            }
        }

        public override int Attack(IFighter toAttack)
        {
            int dmg = Weapon.Damage;

            return dmg;
        }
    }
}
