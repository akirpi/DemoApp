using System.Collections.Generic;
using DemoApp.Data.Entities;

namespace DemoApp.Data
{
    public interface IDemoAppRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string category);

        IEnumerable<Order> GetAllOrders(bool includeItems);
        Order GetOrderById(int id);
        void AddEntity(object model);

        bool SaveAll();
        
    }
}