using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class ProductRepository:Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Product obj)
        {
            var objFromdb = _db.products.FirstOrDefault(u => u.Id == obj.Id);
            if(objFromdb != null)
            {
                objFromdb.Title = obj.Title;
                objFromdb.ISBN = obj.ISBN;
                objFromdb.Author = obj.Author;
                objFromdb.ListedPrice = obj.ListedPrice;
                objFromdb.Price = obj.Price;
                objFromdb.Price50 = obj.Price50;
                objFromdb.Price100 = obj.Price100;
                objFromdb.CategoryId= obj.CategoryId;
                objFromdb.CoverTypeId = obj.CoverTypeId;
                objFromdb.ImageUrl = obj.ImageUrl;
            }
        }
    }
}
