using AutoMapper;
using GeekShopping.API.Data.ValueObjects;
using GeekShopping.API.Model;
using GeekShopping.API.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductVO>> GetAll()
        {
            IEnumerable<Product> product = await _context.Products
                .ToListAsync();

            return _mapper.Map<IEnumerable<ProductVO>>(product);
        }

        public async Task<ProductVO> GetById(long id)
        {
            Product product = await _context.Products
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync() ?? new Product();

            return _mapper.Map<ProductVO>(product);
        }

        public async Task<ProductVO> Create(ProductVO vo)
        {
            Product product = _mapper.Map<Product>(vo);
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return _mapper.Map<ProductVO>(product);

        }

        public async Task<ProductVO> Update(ProductVO vo)
        {
            Product product = _mapper.Map<Product>(vo);
            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return _mapper.Map<ProductVO>(product);
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                Product product = await _context.Products
                    .Where(x => x.Id == id)
                    .FirstOrDefaultAsync() ?? new Product();

                if(product.Id <= 0)
                {
                    return false;
                }

                _context.Products.Remove(product);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
  
    }
}
