using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace FinallProject_
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        //method who gets user by  id
        [OperationContract]
        User GetUser(int id);
        //method who delete user
        [OperationContract]
        void Delete_User(int id);
        [OperationContract]
        void Edit_User(int id);
        //method who gets  Category by  
        [OperationContract]
        Categories GetCategory(int id);
        //method who gets all Category by  
        [OperationContract]
        List<Categories> GetCategories();

        //method who gets  SubCategory by  id
        [OperationContract]
        SubCategories SubCategory(int id);
        //method who gets all  SubCategory by  id
        [OperationContract]
       List< SubCategories> SubCategories();

        //method who gets product by  id
        [OperationContract]
        Product GetProduct(int id);
        //method who gets all product by  id
        [OperationContract]
        List<Product> GetProducts();

        //method who gets  orderProduct by  id
        [OperationContract]
        OrderProduct GetOrderProduct(int id);
        //method who gets all orderProduct by  id
        [OperationContract]
        List<OrderProduct> GetOrderProducts();

        //method who gets  order by  id
        [OperationContract]
        Order GetOrder(int id);
        //method who gets ALL order by  id
        [OperationContract]
        List<Order> GetOrders();

        //method who gets  image by  id
        [OperationContract]
        Images GetImage(int id);
        //method who gets all  image by  id
        [OperationContract]
        List<Images> GetImages();

        //method who gets  GetShipping_Company by  id
        [OperationContract]
        Shipping_Company GetShipping_Company(int id);
        //method who gets all GetShipping_Company by  id
        [OperationContract]
        List<Shipping_Company> GetShipping_Companys();


        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "FinallProject_.ContractType".
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
