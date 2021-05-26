using System;
using RpgGame.Abstractions;

namespace RpgGame.Concrete.Armors
{
    public class Shirt : Armor
    {
        public Shirt()
        {
        }

        public override int Durability { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void ReduceDamage(int incomingDamage)
        {
            throw new NotImplementedException();
        }
    }
}
