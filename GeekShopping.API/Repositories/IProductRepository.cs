using GeekShopping.API.Data.ValueObjects;

namespace GeekShopping.API.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductVO>> GetAll();
        Task<ProductVO> GetById(long id);
        Task<ProductVO> Create(ProductVO vo);
        Task<ProductVO> Update(ProductVO vo);
        Task<ProductVO> Delete(long id);
    }
}
