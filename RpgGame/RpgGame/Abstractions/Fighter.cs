using System;
using RpgGame.Interfaces;

namespace RpgGame.Abstractions
{
    public abstract class Fighter : IFighter
    {
        public Fighter()
        {
        }

        public abstract int Health { get; set; }
        public abstract string Name { get; set; }
        public abstract IArmor Armor { get; set; }
        public abstract IWeapon Weapon { get; set; }

        public abstract void Attack(IFighter defender);
        public abstract void Defend(IFighter attacker, int incomingDamage);
    }
}
