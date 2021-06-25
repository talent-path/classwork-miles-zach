using Microsoft.EntityFrameworkCore;
using PizzaDelivery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDelivery.Repos
{
    public class StoreRepo
    {
        private PizzaDeliveryDbContext context;

        public StoreRepo(PizzaDeliveryDbContext context)
        {
            this.context = context;
        }

        internal Store Add(Store store)
        {
            context.Stores.Add(store);
            context.SaveChanges();
            return store;
            //return new Store
            //{
            //    Id = store.Id,
            //    Contact = new Contact(store.Contact),
            //    Inventory = store.Inventory.Select(inventory => new Inventory
            //    {
            //        Id = inventory.Id,
            //        Quantity = inventory.Quantity,
            //        Ingredient = new Ingredient
            //        {
            //            Id = inventory.Ingredient.Id,
            //            Name = inventory.Ingredient.Name,
            //            Items = inventory.Ingredient.Items.Select(item => new Item
            //            {
            //                Id = item.Id,
            //                Name = item.Name
            //            }).ToList()
            //        }
            //    }).ToList(),
            //    Orders = store.Orders.Select(order => new Order { }).ToList()
            //};
        }

        internal Store Update(Store store)
        {
            context.Attach(store);
            context.Entry(store).State = EntityState.Modified;
            context.SaveChanges();
            return store;
        }

        internal void Remove(Store store)
        {
            context.Stores.Remove(store);
            context.SaveChanges();
        }

        internal Store FindById(int id)
        {
            return context.Stores.Find(id);
        }

        internal List<Store> FindAll()
        {
            return context.Stores.ToList();
        }
    }
}
