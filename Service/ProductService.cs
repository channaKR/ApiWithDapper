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
        /*IEnumerable
         
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
