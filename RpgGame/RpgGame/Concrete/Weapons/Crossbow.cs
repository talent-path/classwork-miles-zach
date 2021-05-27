using System;
using RpgGame.Abstractions;

namespace RpgGame.Concrete.Weapons
{
    public class Crossbow : Weapon
    {
        public Crossbow()
        {
        }

        public override string Name { get; set; } = "Crossbow";
        public override int Damage { get; set; } = 20;
        public override int Durability { get; set; } = 10;
    }
}
