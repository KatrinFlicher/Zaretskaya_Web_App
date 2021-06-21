using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zaretskaya_Html_Intro.Extensions;
using Zaretskaya_Html_Intro.Models;

namespace Zaretskaya_Html_Intro.Components
{
    public class CartViewComponent : ViewComponent
    {
        private Cart _cart;

        public CartViewComponent(Cart cart)
        {
            _cart = cart;
        }

        public IViewComponentResult Invoke()
        {
            return View(_cart);
        }
    }
}