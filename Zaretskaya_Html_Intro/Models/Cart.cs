using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zaretskaya_Html_Intro.DAL.Entities;

namespace Zaretskaya_Html_Intro.Models
{
    public class Cart
    {
        public Dictionary<int, CartItem> Items { get; set; }

        public Cart()
        {
            Items = new Dictionary<int, CartItem>();
        }

        /// <summary>
        /// Количество объектов в корзине
        /// </summary>
        public int Count
        {
            get
            {
                return Items.Sum(item => item.Value.Quantity);
            }
        }


        public int TotalPrice
        {
            get
            {
                return Items.Sum(item => item.Value.Quantity * item.Value.Drug.Price);
            }
        }

        public virtual void AddToCart(Drug drug)
        {
            //если объкт есть в корзине, то увеличить количество
            if (Items.ContainsKey(drug.Id))
            {
                Items[drug.Id].Quantity++;
            }
            else
            {
                Items.Add(drug.Id, new CartItem { Drug = drug, Quantity = 1 });
            }
        }

        public virtual void RemoveFromCart(int id)
        {
            Items.Remove(id);
        }

        public virtual void CrearAll()
        {
            Items.Clear();
        }
    }

    /// <summary>
    /// Класс описывает одну позицию в корзине
    /// </summary>
    public class CartItem
    {
        public Drug Drug { get; set; }
        public int Quantity { get; set; }
    }
}
