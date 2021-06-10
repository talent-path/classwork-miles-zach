using System;
using DeskBooker.Core.Domain;

namespace DeskBooker.Core
{
    public interface IDeskBookingRepository
    {
        void Save(DeskBooking deskBooking);
    }
}
