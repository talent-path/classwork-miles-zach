using System;
using RpgGame.Abstractions;

namespace RpgGame
{
    public interface IFighter : IHealthy, INamed
    {
        void Attack(IFighter defender);
        void Defend(IFighter attacker, int incomingDamage);
    }
}
