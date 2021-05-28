using System;
namespace RpgGame
{
    public interface IHealthy
    {
        int Health { get; set; }
        bool HasPotion { get; set; }
    }
}
