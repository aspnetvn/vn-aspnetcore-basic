using AspnetVnBasics.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetVnBasics.Repositories.Interfaces
{
    public interface ICartRepository
    {
        Task<Cart> GetCartByUserName(string userName);
        Task AddItem(string userName, int productId, int quantity = 1, string color = "Black");
        Task RemoveItem(int cartId, int cartItemId);
        Task RemoveItems(int cartId, List<int> cartItemIds);
        Task ClearCart(string userName);
    }
}
