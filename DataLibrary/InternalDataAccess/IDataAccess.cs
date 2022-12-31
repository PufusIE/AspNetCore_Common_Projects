namespace DataLibrary.InternalDataAccess
{
    public interface IDataAccess
    {
        Task<List<T>> LoadDataAsync<T, U>(string storedProcedure, U parameters, string connectionStringName = "Default");
       
        Task SaveDataAsync<U>(string storedProcedure, U parameters, string connectionStringName = "Default");
    }
}