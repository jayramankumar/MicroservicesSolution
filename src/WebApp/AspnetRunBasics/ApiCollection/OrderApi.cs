using AspnetRunBasics.ApiCollection.Infrastructure;
using AspnetRunBasics.ApiCollection.Interfaces;
using AspnetRunBasics.Models;
using AspnetRunBasics.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AspnetRunBasics.ApiCollection
{
    public class OrderApi : BaseHttpClientWithFactory, IOrderApi
    {
        private readonly IApiSettings _settings;

        public OrderApi(IHttpClientFactory factory, IApiSettings setting)
            : base(factory)
        {
            _settings = setting ?? throw new ArgumentNullException(nameof(setting));
        }

        public override HttpRequestBuilder GetHttpRequestBuilder(string path)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<OrderResponeModel>> GetOrderByUserNameAsync(string userName)
        {
            var message = new HttpRequestBuilder(_settings.BaseAddress)
                .SetPath(_settings.OrderPath)
                .AddQueryString("username", userName)
                .HttpMethod(HttpMethod.Get)
                .GetHttpMessage();

            return await SendRequest<IEnumerable<OrderResponeModel>>(message);
        }
    }
}
