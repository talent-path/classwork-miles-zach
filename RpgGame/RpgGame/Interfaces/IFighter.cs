using System;
using RpgGame.Abstractions;

namespace RpgGame
{
    public interface IFighter : IHealthy, INamed
    {
        int Attack(IFighter defender);
        void Defend(int incomingDamage);
    }
}
