using VendingMachineData.Controller;
using VendingMachineData.Data;
using VendingMachineData.Services;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            //Vending Machine Requirements
            //When the application starts, the user should be presented with a list of candies and prices.
            //Users should be able to "enter money"(just type in how much they want to enter).
            //Users should be able to buy items if they've entered enough money
            //Users should not be able to buy items if they have not entered enough money
            //When a user buys an item, it should reduce the quantity stored by one and "return"
            //change(display the money to the user) showing dollars, quarters, dimes, nickles, and pennies
            //Users should not be able to buy items that are out of stock.

            VendingMachineController controller = new VendingMachineController(
                new VendingMachineService(
                    new VendingMachineDao("../../../../VendingMachine/Candy.txt")
                )
            );

            controller.Run();

        }


    }
}
