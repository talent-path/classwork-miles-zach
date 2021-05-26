using System;

namespace RpgGame.Abstractions
{
    public abstract class Weapon : IWeapon
    {
        public Weapon()
        {
        }

        public abstract string Name { get; set; }
        public abstract int Damage { get; set; }
        public abstract int Durability { get; set; }
    }
}
