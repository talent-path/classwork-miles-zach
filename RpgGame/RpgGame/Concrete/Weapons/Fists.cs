using System;
using RpgGame.Abstractions;

namespace RpgGame.Concrete
{
    public class Fists : Weapon
    {
        public Fists()
        {
        }

        public override string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override int Damage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override int Durability { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
