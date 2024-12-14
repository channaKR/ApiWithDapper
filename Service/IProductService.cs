using ApiWithDapper.Model;

namespace ApiWithDapper.Service
{
    public interface IProductService
    {
        Task<IEnumerable<Mobile>> SelectAllProduct();
        Task<List<Mobile>> SelectAllProductSp();
        Task<int> InsertMobile(Mobile model);
        Task<int> InsertMobileSp(Mobile model);
        Task<Mobile> InsertMobileSpGet(Mobile model);
    }
}
