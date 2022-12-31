using DataLibrary.InternalDataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Dapper;
using System.Data;

namespace DataLibrary.Data
{
    public class OrderData : IOrderData
    {
        private readonly IDataAccess _db;

        public OrderData(IDataAccess db)
        {
            _db = db;
        }

        public async Task<OrderModel> GetOrderById(int orderId, string databaseName = "Default")
        {
            string sql = "spOrder_GetById";
            var output = await _db.LoadDataAsync<OrderModel, dynamic>(sql, new { Id = orderId }, databaseName);
            return output.FirstOrDefault();
        }

        public async Task<int> CreateOrder(OrderModel order, string databaseName = "Default")
        {
            string sql = "spOrder_Insert";

            DynamicParameters p = new DynamicParameters();           
            p.Add("OrderName", order.OrderName);
            p.Add("OrderDate", order.OrderDate);
            p.Add("FoodId", order.FoodId);
            p.Add("Quantity", order.Quantity);
            p.Add("Total", order.Total);
            p.Add("Id", DbType.Int32, direction: ParameterDirection.Output);

            await _db.SaveDataAsync(sql, p, databaseName);

            return p.Get<int>("Id");
        }

        public Task UpdateOrderName(int orderId, string name, string databaseName = "Default")
        {
            string sql = "spOrder_UpdateName";
            return _db.SaveDataAsync(sql, new { Id = orderId, OrderName = name }, databaseName);
        }

        public Task DeleteOrder(int orderId, string databvaseName = "Default")
        {
            string sql = "spOrder_Delete";
            return _db.SaveDataAsync(sql, new { Id = orderId }, databvaseName);
        }
    }
}
