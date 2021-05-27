using System;
using RpgGame.Abstractions;

namespace RpgGame.Concrete.Weapons
{
    public class Sword : Weapon
    {
        public Sword()
        {
            Random random = new Random();
            Damage = random.Next(5, 11);
        }

        public override string Name { get; set; } = "Sword";
        public override int Damage { get; set; }
        public override int Durability { get; set; } = 10;
    }
}
