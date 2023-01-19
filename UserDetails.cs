using System;
namespace TestEvaluation
{
    public class UserLoginRequest
    {
      public string email{get;set;}
      public string password{get;set;}
    }
    public class UserDetailRequest
    {
        public int userid{get;set;}
        public string username{get;set;}
        public string email{get;set;}
        public string password{get;set;}
        public string phoneNo{get;set;}
        public string address{get;set;}
       // public string rolename{get;set;}
        public string roleid{get;set;}
        
    }
    public class UserDetailResponse
    {
        public int userid{get;set;}
        public string username{get;set;}
        public string email{get;set;}
        public string password{get;set;}
        public string address{get;set;}
        public string phoneNo{get;set;}
       // public string rolename{get;set;}
        public string roleid{get;set;}
        
    }
    public class Response
    {
        public int status{get;set;}
        public string Message{get;set;}
    }
    public class ProductDetailRequest
    {
        public int productid{get;set;}
        public string productname{get;set;}
        public string actualprice{get;set;}
        public string productdescription {get;set;}
    }
    public class ProductDetailResponse 
    {
      public int productid{get;set;}
        public string productname{get;set;}
        public string actualprice{get;set;}
        public string productdescription {get;set;}
    }
    public class ShopDetailRequest
    {
        public int shopid{get;set;}
        public string shopname{get;set;}
        public string shopaddress{get;set;}
    }
    public class ShopDetailResponse
    {
        public int shopid{get;set;}
        public string shopname{get;set;}
        public string shopaddress{get;set;}
    }
    public class rolerequest
    {

//public int mapid{get;set;}
        public int roleid{get;set;}
        public string rolename{get;set;}
    }
    public class roleresponse
    {

//public int mapid{get;set;}
        public int roleid{get;set;}
        public string rolename{get;set;}
    }
    public class orderRequest
    {
        public int orderid{get;set;}
        public string sellingamount{get;set;}
        public string sellingdate{get;set;}
    }
 
 public class orderResponse
    {
        public int orderid{get;set;}
        public string sellingamount{get;set;}
        public string sellingdate{get;set;}
    }

}