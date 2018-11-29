using RecoilEnthusiast.Data;
using RecoilEnthusiast.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecoilEnthusiast.Services
{
    public class ProductService
    {
        private readonly Guid _userId;

        public ProductService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateProduct(ProductCreate product)
        {
            var entity =
                new Product()
                {
                    OwnerId = _userId,
                    TypeOfItem = product.TypeOfItem,
                    Name = product.Name,
                    Notes = product.Notes
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Products.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ProductList> GetProducts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Products
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new ProductList
                                {
                                    ProductId = e.ProductId,
                                    TypeOfItem = e.TypeOfItem,
                                    Name = e.Name,
                                }
                        );
                return query.ToArray();
            }
        }
    }
}
