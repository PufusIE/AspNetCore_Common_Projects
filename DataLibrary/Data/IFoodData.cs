using DataLibrary.Models;

namespace DataLibrary.Data
{
    public interface IFoodData
    {
        Task<List<FoodModel>> GetAllMeals(string databaseName = "Default");
    }
}