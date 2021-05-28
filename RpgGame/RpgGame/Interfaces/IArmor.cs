using System;
namespace RpgGame.Interfaces
{
    public interface IArmor : INamed
    {
        int ReduceDamage(int incomingDamage);
        int Durability { get; set; }
    }
}
