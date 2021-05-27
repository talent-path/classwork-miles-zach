using System;
using RpgGame.Abstractions;

namespace RpgGame.Concrete
{
    public class Fists : Weapon
    {
        public Fists()
        {
        }

        public override string Name { get; set; } = "Fists";
        public override int Damage { get; set; } = 1;
        public override int Durability { get; set; } = 10;
    }
}
