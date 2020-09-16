using AspnetRunBasics.ApiCollection.Infrastructure;
using AspnetRunBasics.ApiCollection.Interfaces;
using AspnetRunBasics.Models;
using AspnetRunBasics.Settings;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AspnetRunBasics.ApiCollection
{
    public class BasketApi : BaseHttpClientWithFactory, IBasketApi
    {
        private readonly IApiSettings _settings;

        public BasketApi(IHttpClientFactory factory, IApiSettings setting)
            : base(factory)
        {
            _settings = setting ?? throw new ArgumentNullException(nameof(setting));
        }

        public async Task CheckoutBasket(BasketCheckoutModel model)
        {
            var message = new HttpRequestBuilder(_settings.BaseAddress)
                .SetPath(_settings.BasketPath)
                .AddToPath("Checkout")
                .HttpMethod(HttpMethod.Post)
                .GetHttpMessage();

            var json = JsonConvert.SerializeObject(model);
            message.Content = new StringContent(json, Encoding.UTF8, "application/json");


            await SendRequest<BasketCheckoutModel>(message);
        }

        public async Task<BasketModel> GetBasketAsync(string userName)
        {
            var message = new HttpRequestBuilder(_settings.BaseAddress)
                .SetPath(_settings.BaseAddress)
                .AddQueryString("username", userName)
                .HttpMethod(HttpMethod.Get)
                .GetHttpMessage();

            return await SendRequest<BasketModel>(message);
        }

        public override HttpRequestBuilder GetHttpRequestBuilder(string path)
        {
            throw new NotImplementedException();
        }

        public async Task<BasketModel> UpdateBasketAsync(BasketModel model)
        {
            var message = new HttpRequestBuilder(_settings.BaseAddress)
                            .SetPath(_settings.BasketPath)
                            .HttpMethod(HttpMethod.Post)
                            .GetHttpMessage();

            var json = JsonConvert.SerializeObject(model);
            message.Content = new StringContent(json, Encoding.UTF8, "application/json");


            return await SendRequest<BasketModel>(message);
        }
    }
}
