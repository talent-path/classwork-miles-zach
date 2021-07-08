using Microsoft.EntityFrameworkCore;
using PizzaDelivery.Exceptions;
using PizzaDelivery.Models;
using PizzaDelivery.Repos;
using PizzaDelivery.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDelivery.Services
{
    public class PizzaDeliveryService
    {
        CustomerRepo _customerRepo;
        IngredientRepo _ingredientRepo;
        InventoryRepo _inventoryRepo;
        ItemRepo _itemRepo;
        OrderRepo _orderRepo;
        StoreRepo _storeRepo;

        public PizzaDeliveryService(PizzaDeliveryDbContext context)
        {
            _customerRepo = new CustomerRepo(context);
            _ingredientRepo = new IngredientRepo(context);
            _inventoryRepo = new InventoryRepo(context);
            _itemRepo = new ItemRepo(context);
            _orderRepo = new OrderRepo(context);
            _storeRepo = new StoreRepo(context);
        }

        internal Ingredient GetIngredientById(int id)
        {
            return _ingredientRepo.FindById(id);
        }

        internal List<Item> GetItemsForOrder(int orderId)
        {
            return _itemRepo.FindItemsForOrder(orderId);
        }

        internal Customer GetPreviousCustomerInfo(PreviousCustomerRequest request)
        {
            return _customerRepo.FindCustomerInfo(request.Name, request.Phone);
        }

        internal List<Order> GetOrdersByCustomer(int customerId)
        {
            return _orderRepo.FindOrdersByCustomer(customerId);
        }

        internal List<Order> GetStoreOrders(int storeId)
        {
            return _orderRepo.FindStoreOrders(storeId);
        }

        internal List<Ingredient> GetIngredientsForItem(int itemId)
        {
            return _ingredientRepo.FindIngredientsForItem(itemId);
        }

        internal List<Ingredient> GetAllIngredients()
        {
            return _ingredientRepo.FindAll();
        }

        internal object GetInventoryByStore(int storeId)
        {
            return _inventoryRepo.FindInventoryForStore(storeId);
        }

        internal Ingredient CreateIngredient(Ingredient ingredient)
        {
            return _ingredientRepo.Add(ingredient);
        }

        internal Ingredient UpdateIngredient(Ingredient ingredient)
        {
            return _ingredientRepo.Update(ingredient);
        }

        internal void DeleteIngredient(int id)
        {
            Ingredient ingredient = new Ingredient { Id = id };
            _ingredientRepo.Remove(ingredient);
        }

        internal Item GetItemById(int id)
        {
            return _itemRepo.FindById(id);
        }

        internal Item CreateItem(Item item)
        {
            return _itemRepo.Add(item);
        }

        internal List<Item> GetAllItems()
        {
            return _itemRepo.FindAll();
        }

        internal Item UpdateItem(Item item)
        {
            return _itemRepo.Update(item);
        }

        internal void DeleteItem(int id)
        {
            Item item = new Item { Id = id };
            _itemRepo.Remove(item);
        }

        internal Inventory GetInventoryById(int id)
        {
            return _inventoryRepo.FindById(id);
        }

        internal List<Inventory> GetAllInventory()
        {
            return _inventoryRepo.FindAll();
        }

        internal Inventory CreateInventory(Inventory inventory)
        {
            return _inventoryRepo.Add(inventory);
        }

        internal Inventory UpdateInventory(Inventory inventory)
        {
            return _inventoryRepo.Update(inventory);
        }

        internal Customer GetCustomerById(int id)
        {
            return _customerRepo.FindById(id);
        }

        internal void DeleteInventory(int id)
        {
            Inventory inventory = new Inventory { Id = id };
            _inventoryRepo.Remove(inventory);
        }

        internal List<Customer> GetAllCustomers()
        {
            return _customerRepo.FindAll();
        }

        internal Customer CreateCustomer(Customer customer)
        {
            return _customerRepo.Add(customer);
        }

        internal Customer UpdateCustomer(Customer customer)
        {
            return _customerRepo.Update(customer);
        }

        internal void DeleteCustomer(int id)
        {
            Customer customer = new Customer { Id = id };
            _customerRepo.Remove(customer);
        }

        internal Order CreateOrder(Order order)
        {
            List<Store> nearestByZip = _storeRepo.FindByZip(order.Customer.Zip);
            if(nearestByZip.Count == 0)
            {
                List<Store> nearestByCity = _storeRepo.FindByCity(order.Customer.City);
                order.StoreId = nearestByCity[0].Id;
            } 
            else
            {
                order.StoreId = nearestByZip[0].Id;
            }
            // Check to see if store has enough ingredients to make order items
            return _orderRepo.Add(order);
        }

        internal Order UpdateOrder(Order order)
        {
            return _orderRepo.Update(order);
        }

        internal void DeleteOrder(int id)
        {
            Order order = new Order { Id = id };
            _orderRepo.Remove(order);
        }

        internal Order GetOrderById(int id)
        {
            return _orderRepo.FindById(id);
        }

        internal List<Order> GetAllOrders()
        {
            return _orderRepo.FindAll();
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
            Store store = new Store { Id = id };
            try
            {
                _storeRepo.Remove(store);
            } 
            catch(DbUpdateConcurrencyException e)
            {
                throw new StoreNotFoundException($"Store with Id of {id} does not exist.", e);
            }
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
