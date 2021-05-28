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

        public override int Health { get; set; }
        public override string Name { get; set; }
        public override IArmor Armor { get; set; }
        public override IWeapon Weapon { get; set; }
        public override bool HasPotion { get; set; }

        public Ninja(int health, string name, IArmor armor, IWeapon weapon, bool hasPotion)
        {
            Health = health;
            Name = name;
            Armor = armor;
            Weapon = weapon;
            HasPotion = hasPotion;
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
            int dmg = Armor.ReduceDamage(incomingDamage);
            Health -= dmg;
            
        }

        public override int Attack(IFighter toAttack)
        {
            int dmg = Weapon.Damage;

            return dmg;
        }
    }
}
