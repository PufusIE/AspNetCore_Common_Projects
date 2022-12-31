using DataLibrary.Models;

namespace DataLibrary.Data
{
    public interface IOrderData
    {
        Task<int> CreateOrder(OrderModel order, string databaseName = "Default");
        Task DeleteOrder(int orderId, string databvaseName = "Default");
        Task<OrderModel> GetOrderById(int orderId, string databaseName = "Default");
        Task UpdateOrderName(int orderId, string name, string databaseName = "Default");
    }
}