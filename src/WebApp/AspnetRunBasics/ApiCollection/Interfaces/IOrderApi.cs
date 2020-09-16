﻿using AspnetRunBasics.ApiCollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetRunBasics.ApiCollection.Interfaces
{
    public interface IOrderApi
    {
        Task<IEnumerable<OrderResponeModel>> GetOrderByUserNameAsync(string userName);
    }
}
