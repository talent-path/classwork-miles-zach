using Microsoft.EntityFrameworkCore;
using PizzaDelivery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDelivery.Repos
{
    public class ItemRepo
    {
        private PizzaDeliveryDbContext context;

        public ItemRepo(PizzaDeliveryDbContext context)
        {
            this.context = context;
        }

        internal void Remove(Item item)
        {
            context.Items.Remove(item);
            context.SaveChanges();
        }

        internal Item FindById(int id)
        {
            return context.Items
                .Where(item => item.Id == id)
                .Include(item => item.ItemIngredients)
                .FirstOrDefault();
        }

        internal Item Update(Item item)
        {
            context.Attach(item);
            context.Entry(item).State = EntityState.Modified;
            context.SaveChanges();
            return item;
        }

        internal List<Item> FindAll()
        {
            return context.Items
                .Include(i => i.ItemIngredients)
                .ToList();
        }

        internal List<Item> FindItemsForOrder(int orderId)
        {
            return context.OrderItems
                .Where(oi => oi.OrderId == orderId)
                .Include(oi => oi.Item)
                .Select(oi => new Item(oi.Item))
                .ToList();
        }

        internal Item Add(Item item)
        {
            context.Items.Add(item);
            context.SaveChanges();
            return item;
        }
    }
}
