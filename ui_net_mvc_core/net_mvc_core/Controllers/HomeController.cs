using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using net_mvc_core.Models;

namespace net_mvc_core.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            //public void InsertData()
            //{
            //    var p = new DynamicParameters();
            //    p.Add("VAR1", "John");
            //    p.Add("VAR2", "McEnroe");
            //    p.Add("BASEID", 1);
            //    p.Add("NEWID", dbType: DbType.Int32, direction: ParameterDirection.Output);
            //    connection.Query<int>("SP_MYTESTpROC", p, commandType: CommandType.StoredProcedure);
            //    int newID = p.Get<int>("NEWID");
            //}
//            CREATE PROCEDURE SP_MYTESTpROC
//    @VAR1 VARCHAR(10),
//    @VAR2 VARCHAR(20),
//    @BASEID INT,
//    @NEWID INT OUTPUT
//As Begin
//   INSERT INTO TABLE_NAME(username, firstname)
//      select @VAR1, @VAR2
//      WHERE ID = @BASEID

//   SET @NEWID = SCOPE_IDENTITY() AS INT
//END
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
