using DataLibrary.InternalDataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Data
{
    public class FoodData : IFoodData
    {
        private readonly IDataAccess _db;

        public FoodData(IDataAccess db)
        {
            _db = db;
        }

        public Task<List<FoodModel>> GetAllMeals(string databaseName = "Default")
        {
            string sql = "spFood_GetAll";
            return _db.LoadDataAsync<FoodModel, dynamic>(sql, new { }, databaseName);
        }
    }
}
