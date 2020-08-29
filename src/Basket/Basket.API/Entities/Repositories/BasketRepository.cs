using Basket.API.Data.Interfaces;
using Basket.API.Entities.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Basket.API.Entities.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IBasketContext _context;

        public BasketRepository(IBasketContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<BasketCart> GetBasketAsync(string userName)
        {
            var basket = await _context.Redis.StringGetAsync(userName);
            if(basket.IsNullOrEmpty)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<BasketCart>(basket);
        }

        public async Task<BasketCart> UpdateBasketAsync(BasketCart basket)
        {
            var updated = await _context.Redis.StringSetAsync(basket.UserName, JsonConvert.SerializeObject(basket));
            
            if (!updated)
            {
                return null;
            }

            return await GetBasketAsync(basket.UserName);
        }

        public async Task<bool> DeleteBasketAsync(string userName)
        {
            return await _context.Redis.KeyDeleteAsync(userName);
        }

    }
}
