using System;
namespace RpgGame
{
    public interface IWeapon : INamed
    {
        int Damage { get; set; }
        int Durability { get; set; }
    }
}
