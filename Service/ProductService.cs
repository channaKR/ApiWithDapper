using ApiWithDapper.Model;
using Dapper;
using System.Data;
using System.Data.Common;

namespace ApiWithDapper.Service
{
    public class ProductService : IProductService
    {   private readonly IDbConnection _connection;
        public ProductService( IDbConnection connection ) 
        {
            
            _connection = connection;
        }

        public async Task<int> InsertMobile( Mobile model)
        {
            var query =
                "INSERT INTO [dbo].[Mobile] (ModelName,BrandID,CategoryID) " +
                "VALUES (@ModelName,@BrandID,@CategoryID)" +
                "SELECT SCOPE_IDENTITY() AS NewIdentity";
            var parameter = new 
            {
                
                ModelName = model.ModelName,
                BrandID = model.BrandID,
                CategoryID = model.CategoryID,
            };
            
            var result = await _connection.ExecuteScalarAsync<int>(query, parameter);


            return result;
        }

        public async Task<int> InsertMobileSp(Mobile model)
        {   //Create Parameters
            var parameters = new DynamicParameters();
            parameters.Add("@ModelName",model.ModelName);
            parameters.Add("@BrandID",model.BrandID);
            parameters.Add("@CategoryID", model.CategoryID);
            parameters.Add("@ID",model.ID,dbType:DbType.Int32,direction:ParameterDirection.Output);

            await _connection.ExecuteAsync("InsertMobile",parameters,commandType:CommandType.StoredProcedure);
            var result = parameters.Get<int>("@ID");

            
            return result;
        }
        public async Task<Mobile> InsertMobileSpGet(Mobile model)
        {   //Create Parameters
            var parameters = new DynamicParameters();
            parameters.Add("@ModelName", model.ModelName);
            parameters.Add("@BrandID", model.BrandID);
            parameters.Add("@CategoryID", model.CategoryID);

           var result= await _connection
                            .QueryAsync<Mobile>
                            ("InsertMobileGetAll", 
                            parameters, commandType: CommandType.StoredProcedure);
             
            return result.FirstOrDefault();
        }

        /*

        IEnumerable<Mobile> is more flexible and better suited for large data sets with lazy loading.
        List<Mobile> is better when you need to have all data in memory for quick access and operations.


*/
        public async Task<IEnumerable<Mobile>> SelectAllProduct() 
        {
            var query = "SELECT * FROM Mobile";
            var result = await _connection.QueryAsync<Mobile>(query);
            return result;
        }

        public async Task<List<Mobile>> SelectAllProductSp()
        {
            var query = "[dbo].[SelectAllMobile]";
            var result = await _connection.QueryAsync<Mobile>(query,commandType:CommandType.StoredProcedure);

            return result.ToList();
        }



    }
}
