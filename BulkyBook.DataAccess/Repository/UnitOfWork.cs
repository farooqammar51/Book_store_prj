using BulkyBook.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private BulkyBookWebDbContext _db;

        public UnitOfWork(BulkyBookWebDbContext db)
        {
            _db= db;
            Category = new CategoryRepository(_db);
            CoverType= new CoverTypeRepository(_db);
            Product = new ProductRepository(_db);
        }
        public ICategoryRepository Category { get; private set; }

        public ICoverType CoverType { get; private set; }

        public IProduct Product { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
