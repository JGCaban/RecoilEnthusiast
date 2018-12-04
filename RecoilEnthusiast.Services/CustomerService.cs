using RecoilEnthusiast.Data;
using RecoilEnthusiast.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecoilEnthusiast.Services
{
    public class CustomerService
    {
        private readonly Guid _userId;

        public CustomerService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCustomer(CustomerCreate customer)
        {
            var entity =
                new Customer()
                {
                    OwnerId = _userId,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    DateOfBirth = customer.DateOfBirth,
                    HasFelony = customer.HasFelony,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Customers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool UpdateCustomer(CustomerEdit customer)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Customers
                        .Single(e => e.CustomerId == customer.CustomerId && e.OwnerId == _userId);

                entity.FirstName = customer.FirstName;
                entity.LastName = customer.LastName;
                entity.DateOfBirth = customer.DateOfBirth;
                entity.HasFelony = customer.HasFelony;

                return ctx.SaveChanges() == 1;

            }
        }

        public bool DeleteCustomer(int customerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Customers
                        .Single(e => e.CustomerId == customerId && e.OwnerId == _userId);

                ctx.Customers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CustomerList> GetCustomers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Customers
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new CustomerList
                                {
                                    CustomerId = e.CustomerId,
                                    FirstName = e.FirstName,
                                    LastName = e.LastName,
                                    DateOfBirth = e.DateOfBirth,
                                    HasFelony = e.HasFelony
                                }
                        );
                return query.ToArray();
            }
        }

        public CustomerDetail GetCustomerById(int customerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Customers
                        .Single(e => e.CustomerId == customerId && e.OwnerId == _userId);
                return
                    new CustomerDetail
                    {
                        CustomerId = entity.CustomerId,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        DateOfBirth = entity.DateOfBirth,
                        HasFelony = entity.HasFelony
                    };
            }
        }
    }
}
