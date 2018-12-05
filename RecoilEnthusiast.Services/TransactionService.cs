using RecoilEnthusiast.Data;
using RecoilEnthusiast.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecoilEnthusiast.Services
{
    public class TransactionService
    {
        private readonly Guid _userId;

        public TransactionService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateTransaction(TransactionCreate transaction)
        {
            var entity =
                new Transaction()
                {
                    OwnerId = _userId,
                    Designation = transaction.Designation,
                    IssuerName = transaction.IssuerName,
                    TransactionDate = transaction.TransactionDate
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Transactions.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool UpdateTransaction(TransactionEdit transaction)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Transactions
                        .Single(e => e.TransactionID == transaction.TransactionId && e.OwnerId == _userId);

                entity.Designation = transaction.Designation;
                entity.IssuerName = transaction.IssuerName;
                entity.TransactionDate = transaction.TransactionDate;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteTransaction(int transactionId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Transactions
                        .Single(e => e.TransactionID == transactionId && e.OwnerId == _userId);

                ctx.Transactions.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<TransactionList> GetTransactions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Transactions
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                            new TransactionList
                            {
                                TransactionId = e.TransactionID,
                                Designation = e.Designation,
                                IssuerName = e.IssuerName,
                                TransactionDate = e.TransactionDate
                            }
                        );
                return query.ToArray();
            }
        }

        public TransactionDetail GetTransactionById(int transactionId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Transactions
                        .Single(e => e.TransactionID == transactionId && e.OwnerId == _userId);
                return
                    new TransactionDetail
                    {
                        TransactionId = entity.TransactionID,
                        Designation = entity.Designation,
                        IssuerName = entity.IssuerName,
                        TransactionDate = entity.TransactionDate
                    };
            }
        }
    }
}
