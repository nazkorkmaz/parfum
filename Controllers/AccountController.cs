using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System.Data.SqlClient;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        void connectionString()
        {
            con.ConnectionString = "data source= DESKTOP-IEUVMF0; database=kullanicigiris; integrated security=SSPI;" ;
        }
        [HttpPost]
        public ActionResult Verify(Account acc)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from login where kullaniciadi='"+acc.kullaniciadi+"' and sifre='"+acc.sifre+"'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return View("Privacy");
            }
            else
            {
                con.Close();
                return View("Privacy");
            }
        }
    }
}