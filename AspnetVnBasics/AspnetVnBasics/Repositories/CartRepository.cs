using AspnetVnBasics.Data;
using AspnetVnBasics.Entities;
using AspnetVnBasics.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetVnBasics.Repositories
{
    public class CartRepository : ICartRepository
    {
        protected readonly DatabaseContext _dbContext;

        public CartRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public async Task AddItem(string userName, int productId, int quantity = 1, string color = "Black")
        {
            // find cart
            var cart = await GetCartByUserName(userName);

            var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == productId);

            if (product == null)
            {
                throw new Exception("Not found product");
            }

            // Check if the product has Color property exits in carts then increase by 1
            var cartSelected = cart.Items.FirstOrDefault(c => c.ProductId == productId && c.Color == color);

            if (cartSelected != null)
            {
                cartSelected.Quantity += 1;
            }
            else
            {
                cart.Items.Add(new CartItem
                {
                    Color = color,
                    Price = product.Price,
                    ProductId = productId,
                    Quantity = quantity
                });
            }

            _dbContext.Entry<Cart>(cart).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task ClearCart(string userName)
        {
            var cart = await GetCartByUserName(userName);

            cart.Items.Clear();

            _dbContext.Entry(cart).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Cart> GetCartByUserName(string userName)
        {
            var cart = _dbContext.Carts
                        .Include(c => c.Items)
                            .ThenInclude(i => i.Product)
                        .FirstOrDefault(c => c.UserName == userName);

            if (cart != null)
                return cart;

            // if it is first attempt create new
            var newCart = new Cart
            {
                UserName = userName
            };

            _dbContext.Carts.Add(newCart);
            await _dbContext.SaveChangesAsync();
            return newCart;
        }

        public async Task RemoveItem(int cartId, int cartItemId)
        {
            var cart = _dbContext.Carts
                       .Include(c => c.Items)
                       .FirstOrDefault(c => c.Id == cartId);

            if (cart != null)
            {
                var removedItem = cart.Items.FirstOrDefault(x => x.Id == cartItemId);
                cart.Items.Remove(removedItem);

                _dbContext.Entry(cart).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task RemoveItems(int cartId, List<int> cartItemIds)
        {
            var cart = _dbContext.Carts
                        .Include(c => c.Items)
                        .FirstOrDefault(c => c.Id == cartId);

            if (cart != null)
            {
                var removedItems = cart.Items.Any(c => cartItemIds.Contains(c.Id));
                if (removedItems)
                {
                    cart.Items.RemoveAll(c => cartItemIds.Contains(c.Id));

                    _dbContext.Entry(cart).State = EntityState.Modified;
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
