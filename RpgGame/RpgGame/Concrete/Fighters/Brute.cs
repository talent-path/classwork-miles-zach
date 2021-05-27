using System;
using RpgGame.Abstractions;
using RpgGame.Concrete.Armors;
using RpgGame.Interfaces;

namespace RpgGame.Concrete
{
    public class Brute : Fighter
    {
        public Brute(int Health, string Name, IArmor armor, IWeapon weapon)
        {
            this.Health = Health;
            this.Name = Name;
            this.Armor = armor;
            this.Weapon = weapon;
        }

        public Brute()
        {

        }

        public override int Health { get; set; } = 100;
        public override string Name { get; set; } = "Brute";
        public override IArmor Armor { get; set; } = new Helmet();
        public override IWeapon Weapon { get; set; } = new Fists();

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
