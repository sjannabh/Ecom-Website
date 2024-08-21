using Ecom_Website.DataAccess.Data;
using Ecom_Website.DataAccess.Models;
using Ecom_Website.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Ecom_Website.DataAccess.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext _context;

        public CartRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public Task Create(Cart Cart)
        {
            _context.Add(Cart);
            _context.SaveChanges();
            return Task.CompletedTask;

        }
        public Cart GetByCartId(int CartId)
        {
            return _context.Cart.FirstOrDefault(x => x.CartId == CartId);
        }

        public Cart GetByUserId(string UserId)
        {
            var item = _context.Cart.Include(f => f.LineItems).Where(x => x.UserId == UserId).FirstOrDefault();
            return item;
        }

        public int GetCount(string UserId)
        {
            var item = _context.Cart.Include(f => f.LineItems).Where(x => x.UserId == UserId).FirstOrDefault();
            return item.Count;
        }
        //get total using userid
        public double GetTotal(string UserId)
        {
            var item = _context.Cart.Include(f => f.LineItems).Where(x => x.UserId == UserId).FirstOrDefault();
            return item.Total;
        }

        public Task Update(int CartId, Cart c)
        {
            var item = _context.Cart.Include(f => f.LineItems).Where(x => x.CartId == CartId).FirstOrDefault();

            if (item == null)
                return null;

            _context.ChangeTracker.Clear();

            _context.Update(c);
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public Cart DeleteLineItem(int cartId, string productId)
        {
            var item = _context.Cart.Include(f => f.LineItems).Where(x => x.CartId == cartId).FirstOrDefault();

            foreach (var lineitem in item.LineItems)
            {
                if (lineitem.ProductId == productId)
                {
                    int quantity = lineitem.Quantity;
                    double price = lineitem.Price;
                    item.LineItems.Remove(lineitem);
                    item.Count -= quantity;
                    item.Total -= quantity * price;
                    item.SubTotal = item.Total;
                    _context.SaveChanges();
                    break;
                }
            }
            return item;
        }

        public Task Delete(int CartId)
        {
            var item = _context.Cart.Find(CartId);
            _context.Remove(item);
            _context.SaveChanges();
            return Task.CompletedTask;
        }

    }
}
