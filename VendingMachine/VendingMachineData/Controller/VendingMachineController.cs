using System;
using VendingMachineData.Exceptions;
using VendingMachineData.Models;
using VendingMachineData.Services;
using VendingMachineData.Views;

namespace VendingMachineData.Controller
{
    public class VendingMachineController
    {

        private IVendingMachineService _service;
        private VendingMachineView _view;

        public VendingMachineController(IVendingMachineService service, VendingMachineView view)
        {
            _service = service;
            _view = view;
        }

        public void Run()
        {
            decimal funds = _view.GetFunds();
            while (funds > 0.00M)
            {
                int choice = _view.DisplayCandies(_service.GetCandies()) - 1;
                Change change = new Change(funds);
                try
                {
                    change = _service.PurchaseCandy(_service.GetCandies()[choice], funds);
                    Console.WriteLine(_service.GetCandies()[choice].Name + " dispensed.");
                    
                    funds = change.ToDecimal();
                } catch (InsufficientFundsException ife)
                {
                    Console.WriteLine(ife.Message);
                } catch(OutOfStockException oose)
                {
                    Console.WriteLine(oose.Message);
                }
                finally
                {
                    Console.WriteLine(change.ToString());
                }
                
            }
        }

        
    }
}
