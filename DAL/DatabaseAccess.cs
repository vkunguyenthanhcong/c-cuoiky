using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace DAL
{
    public class DBConnect
    {
        protected SqlConnection conn = new SqlConnection("Data Source=NGUYENTHANHCONG\\SQLEXPRESS;Initial Catalog=QLSV;Integrated Security=True; MultipleActiveResultSets=true");
    }

}