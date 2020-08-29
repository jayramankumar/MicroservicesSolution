using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Entities.Repositories.Interfaces
{
    public interface IBasketRepository
    {
        Task<BasketCart> GetBasketAsync(string userName);
        Task<BasketCart> UpdateBasketAsync(BasketCart basket);
        Task<bool> DeleteBasketAsync(string userName);
    }
}
