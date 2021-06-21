using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text.Json.Serialization;
using Zaretskaya_Html_Intro.DAL.Entities;
using Zaretskaya_Html_Intro.Extensions;
using Zaretskaya_Html_Intro.Models;

namespace Zaretskaya_Html_Intro.Services
{
    public class CartService : Cart
    {
        private static string sessionKey = "cart";

        /// <summary>
        /// Объект сессии
        /// Не записывается в сессию вместе с CartService
        /// </summary>
        [JsonIgnore]
        ISession Session { get; set; }

        /// <summary>
        /// Получение объекта класса CartService
        /// </summary>
        /// <param name="sp">объект IServiceProvider</param>
        /// <returns>объект класса Cartservice, приведенный к типу Cart</returns>
        public static Cart GetCart(IServiceProvider sp)
        {
            // получить объект сессии
            var session = sp
                .GetRequiredService<IHttpContextAccessor>()
                .HttpContext
                .Session;
            // получить CartService из сессии
            // или создать новый для возможности тестирования
            var cart = session?.Get<CartService>(sessionKey)
                ?? new CartService();
            cart.Session = session;
            return cart;
        }


        public override void AddToCart(Drug drug)
        {
            base.AddToCart(drug);
            Session?.Set<CartService>(sessionKey, this);
        }

        public override void RemoveFromCart(int id)
        {
            base.RemoveFromCart(id);
            Session?.Set<CartService>(sessionKey, this);
        }

        public override void CrearAll()
        {
            base.CrearAll();
            Session?.Set<CartService>(sessionKey, this);

        }
    }
}