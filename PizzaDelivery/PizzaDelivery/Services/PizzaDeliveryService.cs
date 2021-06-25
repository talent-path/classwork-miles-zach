using PizzaDelivery.Models;
using PizzaDelivery.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDelivery.Services
{
    public class PizzaDeliveryService
    {
        AddressRepo _addressRepo;
        ContactRepo _contactRepo;
        CustomerRepo _customerRepo;
        IngredientRepo _ingredientRepo;
        InventoryRepo _inventoryRepo;
        ItemRepo _itemRepo;
        OrderRepo _orderRepo;
        StoreRepo _storeRepo;

        public PizzaDeliveryService(PizzaDeliveryDbContext context)
        {
            _addressRepo = new AddressRepo(context);
            _contactRepo = new ContactRepo(context);
            _customerRepo = new CustomerRepo(context);
            _ingredientRepo = new IngredientRepo(context);
            _inventoryRepo = new InventoryRepo(context);
            _itemRepo = new ItemRepo(context);
            _orderRepo = new OrderRepo(context);
            _storeRepo = new StoreRepo(context);
        }

        internal Order GetOrderById(int id)
        {
            throw new NotImplementedException();
        }

        internal List<Order> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        internal Store AddStore(Store store)
        {
            return _storeRepo.Add(store);
        }

        internal Store UpdateStore(Store store)
        {
            return _storeRepo.Update(store);
        }

        internal void RemoveStore(int id)
        {
            Store store = _storeRepo.FindById(id);
            if(store == null)
            {
                throw new Exception($"No store found with an Id = {id}");
            }
            _storeRepo.Remove(store);
        }

        internal Store GetStoreById(int id)
        {
            return _storeRepo.FindById(id);
        }

        internal List<Store> GetAllStores()
        {
            return _storeRepo.FindAll();
        }
    }
}
