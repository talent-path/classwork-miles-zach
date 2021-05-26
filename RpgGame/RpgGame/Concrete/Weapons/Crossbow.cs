using System;
using RpgGame.Abstractions;

namespace RpgGame.Concrete.Weapons
{
    public class Crossbow : Weapon
    {
        public Crossbow()
        {
        }

        public override string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override int Damage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override int Durability { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
