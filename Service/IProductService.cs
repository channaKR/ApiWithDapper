using ApiWithDapper.Model;

namespace ApiWithDapper.Service
{
    public interface IProductService
    {
        Task<IEnumerable<Mobile>> SelectAllProduct();
    }
}
