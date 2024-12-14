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

        public async Task<IEnumerable<Mobile>> SelectAllProduct()
        {
            var query = "SELECT * FROM Mobile";
            var result = await _connection.QueryAsync<Mobile>(query);
            return result;
        }

        public async Task<IEnumerable<Mobile>> SelectAllProductSp()
        {
            var query = "InsertMobile";
            var result = await _connection.QueryAsync<Mobile>(query,commandType:CommandType.StoredProcedure);

            return result;
        }



    }
}
