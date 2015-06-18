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
        public Categories GetCategory(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.Categories.FirstOrDefault(c => c.Id == id);
        }
        //method who gets  SubCategory by  id
        public SubCategories SubCategory(int id)
        {

            return db.SubCategories.FirstOrDefault(sc => sc.id == id);
        }
        //method who gets product by  id
        public Product GetProduct(int id)
        {

            return db.Product.FirstOrDefault(p => p.Id == id);
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
        public Images GetImage(int id)
        {

            return db.Images.FirstOrDefault(img => img.Id == id);
        }
        //method who gets  image by  id
        public Shipping_Company GetShipping_Company(int id)
        {

            return db.Shipping_Company.FirstOrDefault(s => s.Id == id);
        }
        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public List<Categories> GetCategories()
        {
            return db.Categories.ToList();
        }

        public List<SubCategories> SubCategories()
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

        public List<Images> GetImages()
        {
            return db.Images.ToList();
        }

        public List<Shipping_Company> GetShipping_Companys()
        {
            return db.Shipping_Company.ToList();
        }

        public void Delete_User(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit_User(int id)
        {
            throw new NotImplementedException();
        }
    }
}
