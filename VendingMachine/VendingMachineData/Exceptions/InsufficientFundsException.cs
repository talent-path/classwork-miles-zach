using System;
namespace VendingMachineData.Exceptions
{
    public class InsufficientFundsException : Exception
    {
        public InsufficientFundsException(string message) : base(message)
        {
        }

        public InsufficientFundsException(string message, Exception ex) : base(message, ex)
        {

        }
    }
}
