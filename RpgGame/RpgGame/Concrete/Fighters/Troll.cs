using System;
using RpgGame.Abstractions;
using RpgGame.Interfaces;

namespace RpgGame.Concrete
{
    public class Troll : Fighter
    {
        public Troll()
        {
        }

        public override int Health { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override IArmor Armor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override IWeapon Weapon { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void Attack(IFighter toAttack)
        {
            throw new NotImplementedException();
        }

        public override void Defend(IFighter attacker)
        {
            throw new NotImplementedException();
        }
    }
}
