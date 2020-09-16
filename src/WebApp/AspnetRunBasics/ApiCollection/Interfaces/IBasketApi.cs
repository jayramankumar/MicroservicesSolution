using AspnetRunBasics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetRunBasics.ApiCollection.Interfaces
{
    public interface IBasketApi
    {
        Task<BasketModel> GetBasketAsync(string userName);
        Task<BasketModel> UpdateBasketAsync(BasketModel model);
        Task CheckoutBasket(BasketCheckoutModel model);
    }
}
