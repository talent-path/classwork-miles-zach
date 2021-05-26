using System;
using RpgGame.Abstractions;

namespace RpgGame.Concrete.Armors
{
    public class Shield : Armor
    {
        public Shield()
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
