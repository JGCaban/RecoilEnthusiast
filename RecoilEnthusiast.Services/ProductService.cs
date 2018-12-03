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
                    Model = product.Model,
                    Serial = product.Serial,
                    Notes = product.Notes
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Products.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public bool UpdateProduct(ProductEdit product)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Products
                        .Single(e => e.ProductId == product.ProductId && e.OwnerId == _userId);

                entity.TypeOfItem = product.TypeOfItem;
                entity.Name = product.Name;
                entity.Model = product.Model;
                entity.Serial = product.Serial;
                entity.Notes = product.Notes;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteProduct(int productId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Products
                        .Single(e => e.ProductId == productId && e.OwnerId == _userId);

                ctx.Products.Remove(entity);
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
                                    Model = e.Model,
                                }
                        );
                return query.ToArray();
            }
        }
        public ProductDetail GetProductById(int productId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Products
                        .Single(e => e.ProductId == productId && e.OwnerId == _userId);
                return
                    new ProductDetail
                    {
                        ProductId = entity.ProductId,
                        TypeOfItem = entity.TypeOfItem,
                        Name = entity.Name,
                        Model = entity.Model,
                        Serial = entity.Serial,
                        Notes = entity.Notes
                    };
            }
        }
    }
}
