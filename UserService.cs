using TestEvaluation.Config;
using TestEvaluation;
using Dapper;

namespace Evaluation.Sales
{
    public class UserService{
        
        private readonly DevdbContext _context;

    public UserService(DevdbContext context)
    {
        _context = context;
    }

        public async Task<dynamic> createUser(UserDetailResponse userreg)
        {
            bool result = true;
            var query = "INSERT INTO evaluation_sales.userdetails(userid, username, phoneno ,email , address , password,roleid) VALUES('" + userreg.userid + "', '" + userreg.username + "', '" + userreg.phoneNo + "','"+userreg.email+"','" + userreg.address + "','"+userreg.password+"','"+userreg.roleid+"')";

            Console.WriteLine("in query");
            Console.WriteLine(query);
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
         public async Task<dynamic> createrole(roleresponse role)
        {
            bool result = true;
            var query = "INSERT INTO evaluation_sales.role(roleid,rolename)VALUES('"+role.roleid+"','"+role.rolename+"')";
            Console.WriteLine("in query");
            Console.WriteLine(query);
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
        public async Task<dynamic> createproduct(ProductDetailResponse product)
        {
            bool result = true;
            var query = "INSERT INTO evaluation_sales.productdetails(productid, productname, actualprice , productdescription) VALUES('" + product.productid + "', '" + product.productname + "', '" + product.actualprice+ "','"+product.productdescription+"')";

            Console.WriteLine("in query");
            Console.WriteLine(query);
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
        

       public async Task<dynamic>createshop(ShopDetailRequest shop)
        {
            bool result = true;
            var query = "INSERT INTO evaluation_sales.shopdetails(shopid, shopname, shopaddress) VALUES('" + shop.shopid + "', '" + shop.shopname + "', '" + shop.shopaddress + "')";

            Console.WriteLine("in query");
            Console.WriteLine(query);
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
    public async Task<dynamic> createorder(orderResponse order)
        {
            bool result = true;
            var query = "INSERT INTO evaluation_sales.order(orderid,sellingamount,sellingdate)VALUES('"+order.orderid+"','"+ order.sellingamount +"','"+ order.sellingdate +"')";

            Console.WriteLine("in query");
            Console.WriteLine(query);
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
    }
}