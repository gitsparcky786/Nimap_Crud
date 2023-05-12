using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CRUD1.Models
{
    public class Customer:DatabaseManager
    {
        public int PID { get; set; }
        public string ProductName { get; set; }
        public int CID { get; set; }
        public string CategoryName { get; set; }
        public string Date_of_Reg { get; set; }
        private bool status;
        private string Response;

        internal string AddProductCategory(string ProductName)
        {
            Date_of_Reg = DateTime.Now.ToString("dd/MM/yyy hh:mm:ss tt");
            MyCommandText = "insert into ProductCategory values('" + ProductName + "')";
            status = InsertedUpdatedOrDeleted();
            Response = status ? "Product Category Succesfully Added" : "Record not inserted";
            return Response;
        }
        internal string AddProductName(string CategoryName)
        {
            Date_of_Reg = DateTime.Now.ToString("dd/MM/yyy hh:mm:ss tt");
            MyCommandText = "insert into ProductName values('" + CategoryName + "',1)";
            status = InsertedUpdatedOrDeleted();
            Response = status ? "Product Name Succesfully Added" : "Record not inserted";
            return Response;
        }
        internal List<Customer> GetAllCategory()
        {
            MyCommandText = "Select *from ProductCategory";
            DataTable dt = GetQueriedData();
            List<Customer> LstCm = new List<Customer>();
            foreach (DataRow dr in dt.Rows)
            {
                Customer c = new Customer();
                c.PID = (int)dr["PID"];
                c.ProductName = dr["ProductName"].ToString();
                LstCm.Add(c);
            }
            return LstCm;
        }
    }
}