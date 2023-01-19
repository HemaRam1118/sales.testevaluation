using System;
using Dapper;
using TestEvaluation.Config;
using Evaluation.Sales;
using Microsoft.AspNetCore.Mvc;
using TestEvaluation;

namespace TestEvaluation.Controllers
{
    [ApiController]
    public class LoginController :ControllerBase
    {

private readonly DbContext _context;
    private readonly UserService userService;

    public LoginController(DbContext context)
    {
        _context = context;
        userService = new UserService(_context);
    }


    [HttpPost("registeruser")]
    [ProducesResponseType(typeof(Response), 200)]
    public async Task<Response> registerUser([FromBody] UserDetailRequest details)
    {
      UserDetailResponse Userreg = new UserDetailResponse();
      Response responseObj = new Response();
      Userreg.userid = details.userid;
      Userreg.username=details.username;
      Userreg.email=details.email;
      Userreg.address=details.address;
      Userreg.password=details.password;
      Userreg.phoneNo=details.phoneNo;
      //Userreg.rolename=details.rolename;
      Userreg.roleid=details.roleid;
      userService.createUser(Userreg);

        responseObj.status = 200;
        responseObj.Message = "Success";
        
        return responseObj;    
    }

    [HttpPost("login")]
    [ProducesResponseType(typeof(Response), 200)]

    public async Task<Response>Login([FromBody] UserLoginRequest userlogin)
    {
    DbContext Context = new DbContext();
     Response response = new Response();
     var sql = "SELECT * FROM evaluation_sales.userdetails WHERE (email = '" + userlogin.email + "',password = '" + userlogin.password + "')";
        Console.WriteLine(sql);
            //Userdetail check = Context.Userdetails.Where(f => f.Email == request.email && f.Password == request.password).FirstOrDefault();
            if (check != null)
            {
             var token = GenerateToken(check);
                return Ok(token);
            }
            else
            {
               return NotFound("User not found");
            }
        }

      
[HttpPost("Role")]
[ProducesResponseType(typeof(Response), 200)]
public async Task <Response>createrole([FromBody]rolerequest details)
{
roleresponse role = new roleresponse(); 
Response responseobj = new Response();
role.roleid = details.roleid;
role.rolename = details.rolename;
userService.createrole(role);
responseobj.status = 200;
responseobj.Message = "Success";
        
return responseobj;  
}
        [HttpGet("Roleid")]
        [ProducesResponseType(typeof(Response), 200)]
        public async Task<Response> setrole(int roleid)
                {
            Response responseobj = new Response();
            var sql = "select evaluation_sales.userdetails.userid,evaluation_sales.userdetails.username,evaluation_sales.role.rolename from evaluation_sales.userdetails left join evaluation_sales.role on evaluation_sales.userdetails.roleid=evaluation_sales.role.roleid";
            Console.WriteLine(sql);
            if (sql == null)
            {
                responseobj.status = 404;
                responseobj.Message = "User Not found";
            }
            else
            {
                responseobj.status = 200;
                responseobj.Message = "Success";


            }
            return responseobj;
        }
        [HttpPost("registerProduct")]
    [ProducesResponseType(typeof(Response), 200)]
    public async Task <Response>registerproduct([FromBody]ProductDetailRequest details)
    {
     ProductDetailResponse product = new ProductDetailResponse();
     Response responseobj = new Response();
     product.productid = details.productid;
     product.productname = details.productname;
     product.actualprice = details.actualprice;
     product.productdescription = details.productdescription;
     userService.createproduct(product);
        responseobj.status = 200;
        responseobj.Message = "Success";
        
        return responseobj;  
    }

    [HttpPost("registershop")]
    [ProducesResponseType(typeof(Response), 200)]
    public async Task<Response> registershop([FromBody]ShopDetailRequest details)
    {
        ShopDetailRequest shop = new ShopDetailRequest();
        Response responseobj = new Response();
        shop.shopid = details.shopid;
        shop.shopname = details.shopname;
        shop.shopaddress = details.shopaddress;
        userService.createshop(shop);
        responseobj.status = 200;
        responseobj.Message = "Success";
        
        return responseobj; 

    }

        [HttpPost("shopid")]
        [ProducesResponseType(typeof(Response), 200)]
        public async Task<Response> setuser(int userid)
        {
         Response responseobj = new Response();
            var sql = "select evaluation_sales.shopdetails.shopid,evaluation_sales.shopdetails.shopname,evaluation_sales.shopdetails.shopaddress,evaluation_sales.userdetails.username from evaluation_sales.shopdetails left join evaluation_sales.userdetails on evaluation_sales.shopdetails.userid=evaluation_sales.userdetails.userid";
            Console.WriteLine(sql);
            if (sql == null)
            {
                responseobj.status = 404;
                responseobj.Message = "User Not found";
            }
            else
            {
                responseobj.status = 200;
                responseobj.Message = "Success";


            }
            return responseobj;
        }   
        [HttpPost("order")]
    [ProducesResponseType(typeof(Response), 200)]
    public async Task<Response>createorder([FromBody]orderRequest details)
    {
    orderResponse order = new orderResponse();
    Response responseobj = new Response();
    order.orderid=details.orderid;
    order.sellingamount=details.sellingamount;
    order.sellingdate=details.sellingdate;
    userService.createorder(order);
        responseobj.status = 200;
        responseobj.Message = "Success";
        
        return responseobj; 
    }
    [HttpPost("orderid/count")]
    [ProducesResponseType(typeof(Response), 200)]
    public async Task<Response>count(int orderid)
    {
        Response responseobj = new Response();
            var sql = "SELECT evaluation_sales.order.sellingdate, evaluation_sales.order.sellingamount,count(*)from evaluation_sales.order group by evaluation_sales.order.sellingdate, evaluation_sales.order.sellingamount";
            Console.WriteLine(sql);
            if (sql == null)
            {
                responseobj.status = 404;
                responseobj.Message = "User Not found";
            }
            else
            {
                responseobj.status = 200;
                responseobj.Message = "Success";
            }
     return responseobj;
    }
        [HttpGet("shopid/Date")]
        //[ProducesResponseType(typeof(Response), 200)]
        public async Task<dynamic> getorderdetails(int shopid)
        {
            bool result = true;
            var query = "select evaluation_sales.order.sellingdate,evaluation_sales.shopdetails.shopname,evaluation_sales.order.sellingamount  from evaluation_sales.order left join evaluation_sales.shopdetails on evaluation_sales.shopdetails.shopid=evaluation_sales.shopdetails.shopid order by sellingdate";
            Console.WriteLine(query);
            //Console.WriteLine("in query");
            using (var connection = _context.CreateConnection())
            {
                try
                {
                    var resultData = await connection.QueryAsync<dynamic>(query);
                    // check result is fine or not
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    throw;
                }
                finally
                {
                    _context.ReleaseServerConnection(connection);
                }
            }
}