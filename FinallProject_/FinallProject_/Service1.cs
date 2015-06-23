using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace FinallProject_
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public Service1()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }
        FinallProject_Entities db = new FinallProject_Entities();
        //method who getting a user by his id
        public User GetUser(int id)
        {
            return db.User.FirstOrDefault(u => u.Id == id);
        }
        //method who gets  Category by  id
        public Category GetCategory(int id)
        {
            return db.Categories.FirstOrDefault(c => c.Id == id);
        }
        //method who gets  SubCategory by  id
        public SubCategory SubCategory(int id)
        {
            return db.SubCategories.FirstOrDefault(sc => sc.id == id);
        }
        //method who gets product by  id
        public Product GetProduct(int id)
        {

            return db.Product.FirstOrDefault(p => p.Id == id);
        }
        public void AddProduct(Product product)
        {

            db.Product.Add(product);
            db.SaveChanges();
        }

        //method who gets  orderProduct by  id
        public OrderProduct GetOrderProduct(int id)
        {

            return db.OrderProduct.FirstOrDefault(op => op.Id == id);
        }
        //method who gets  order by  id
        public Order GetOrder(int id)
        {

            return db.Order.FirstOrDefault(o => o.Id == id);
        }
        //method who gets  image by  id
        public Image GetImage(int id)
        {

            return db.Images.FirstOrDefault(img => img.Id == id);
        }
        //method who gets  image by  id
        public Shipping_Company GetShipping_Company(int id)
        {

            return db.Shipping_Company.FirstOrDefault(s => s.Id == id);
        }


        public List<Category> GetCategories()
        {
            return db.Categories.ToList();
        }

        public List<SubCategory> SubCategory()
        {
            return db.SubCategories.ToList();
        }

        public List<Product> GetProducts()
        {

            return db.Product.ToList();
        }

        public List<OrderProduct> GetOrderProducts()
        {
            return db.OrderProduct.ToList();
        }

        public List<Order> GetOrders()
        {
            return db.Order.ToList();
        }

        public List<Image> GetImages()
        {
            return db.Images.ToList();
        }

        public List<Shipping_Company> GetShipping_Companys()
        {
            return db.Shipping_Company.ToList();
        }

        public void Delete_User(int id)
        {
            User user = db.User.FirstOrDefault(u => u.Id == id);
            db.User.Remove(user);
            db.SaveChanges();

        }

        public void Edit_User(int id, User editUser)
        {
            User user = db.User.FirstOrDefault(u => u.Id == id);
            user = editUser;
            db.SaveChanges();
        }

        public void Delete_Category(int id)
        {
            Category cat = db.Categories.FirstOrDefault(i => i.Id == id);
            db.Categories.Remove(cat);
            db.SaveChanges();
        }

        public void Edit_Category(int id, string name)
        {
            db.Categories.FirstOrDefault(i => i.Id == id).Name = name;

            db.SaveChanges();

        }

        public List<SubCategory> SubCategories()
        {
            return db.SubCategories.ToList();
        }

        public void Delete_SubCategory(int id)
        {
            SubCategory subCat = db.SubCategories.FirstOrDefault(s => s.id == id);
            db.SubCategories.Remove(subCat);
            db.SaveChanges();
        }

        public void Edit_SubCategory(int id, string name)
        {
            db.SubCategories.FirstOrDefault(s => s.id == id).Name = name;
            db.SaveChanges();

        }

        public void Delete_Product(int id)
        {
            db.Product.Remove(db.Product.FirstOrDefault(p => p.Id == id));
            db.SaveChanges();
        }

        public void Edit_Product(int id, Product editProduct)
        {
            Product product = db.Product.FirstOrDefault(s => s.Id == id);
            product = editProduct;
            db.SaveChanges();
        }

        public void Delete_OrderProduct(int id)
        {
            db.OrderProduct.Remove(db.OrderProduct.FirstOrDefault(p => p.Id == id));
            db.SaveChanges();
        }

        public void Edit_OrderProduct(int id, OrderProduct editOd)
        {
            OrderProduct od = db.OrderProduct.FirstOrDefault(p => p.Id == id);
            od = editOd;
            db.SaveChanges();
        }

        public void Delete_Order(int id)
        {
            db.Order.Remove(db.Order.FirstOrDefault(p => p.Id == id));
            db.SaveChanges();
        }

        public void Edit_Order(int id, Order editO)
        {
            Order o = db.Order.FirstOrDefault(p => p.Id == id);
            o = editO;
            db.SaveChanges();
        }

        public void Delete_Image(int id)
        {
            db.Images.Remove(db.Images.FirstOrDefault(p => p.Id == id));
            db.SaveChanges();
        }

        public void Edit_Image(int id, Image image)
        {
            Image i = db.Images.FirstOrDefault(p => p.Id == id);
            i = image;
            db.SaveChanges();
        }

        public void Delete_Shipping_Company(int id)
        {
            db.Shipping_Company.Remove(db.Shipping_Company.FirstOrDefault(p => p.Id == id));
            db.SaveChanges();
        }

        public void Edit_Shipping_Company(int id, Shipping_Company editShipp)
        {
            Shipping_Company ship = db.Shipping_Company.FirstOrDefault(p => p.Id == id);
            ship = editShipp;
            db.SaveChanges();
        }
    }
}
