using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspnetRunBasics.ApiCollection.Interfaces;
using AspnetRunBasics.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspnetRunBasics
{
    public class OrderModel : PageModel
    {
        private readonly IOrderApi _orderApi;

        public OrderModel(IOrderApi orderApi)
        {
            _orderApi = orderApi ?? throw new ArgumentNullException(nameof(orderApi));
        }

        public IEnumerable<OrderResponeModel> Orders { get; set; } = new List<OrderResponeModel>();

        public async Task<IActionResult> OnGetAsync()
        {
            var userName = "swn";
            Orders = await _orderApi.GetOrderByUserNameAsync(userName);

            return Page();
        }       
    }
}