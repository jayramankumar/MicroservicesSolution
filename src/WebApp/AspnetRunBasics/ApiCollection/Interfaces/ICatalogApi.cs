using AspnetRunBasics.ApiCollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetRunBasics.ApiCollection.Interfaces
{
    public interface ICatalogApi
    {
        Task<IEnumerable<CatalogModel>> GetCatalogAsync();
        Task<IEnumerable<CatalogModel>> GetCatalogByCatagoryAsync(string category);
        Task<CatalogModel> GetCatalogByIdAsync(string id);
        Task<CatalogModel> CreateCatalog(CatalogModel model);

    }
}
