using System;
using System.Collections.Generic;
using VendingMachineData.Data;
using VendingMachineData.Models;
using VendingMachineData.Services;

namespace VendingMachineData.Controller
{
    public class VendingMachineController
    {

        private IVendingMachineService _service;

        public VendingMachineController(IVendingMachineService service)
        {
            _service = service;
        }

        public void Run()
        {
            while(true)
            {
                decimal funds = _service.GetFunds();
                _service.DisplayCandies();
                break;
            }
        }
    }
}
