using Ecom_Website.DataAccess.Models;

namespace Ecom_Website.DataAccess.Repository.IRepository
{
    public interface ICartRepository
    {
        // creat a cart item
        Task Create(Cart Cart);
        //// get all items in the cart table
        //Task <List<Cart>> GetAll();

        Cart GetByCartId(int CartId);
        //get the cart item using user id
        Cart GetByUserId(string UserId);

        // get count using userid
        int GetCount(string UserId);
        //get total using userid
        double GetTotal(string UserId);
        // update single cart item using cartid
        Task Update(int CartId, Cart Cart);
        //delete using userid and prodcutid and send the remaining cart object
        Cart DeleteLineItem(int cartid, string productId);

        // delete single cart item using cartid
        Task Delete(int CartId);

    }
}
