using ASP.Net.Data;
using ASP.Net.DataAccess.Repository;
using ASP.Net.DataAccess.Repository.IRepository;
using ASP.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Net.DataAccess.Repository
{

    public class ProductRepository : Repository<Product>, IProductRepository
    {

        private ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Product obj)
        {
            var objFromDb = _db.Products.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Title = obj.Title;
                obj.ISBN = objFromDb.ISBN;
                objFromDb.Price = objFromDb.Price;
                objFromDb.ListPrice = objFromDb.ListPrice;
                obj.BulkPrice= objFromDb.BulkPrice;
                obj.Author = objFromDb.Author;                
                objFromDb.Description = obj.Description;
                objFromDb.Category = obj.Category;
                objFromDb.CategoryId = obj.CategoryId;
                if (obj.ImageURL != null)
                {
                    objFromDb.ImageURL = obj.ImageURL;
                }
            }
        }
    }
}
