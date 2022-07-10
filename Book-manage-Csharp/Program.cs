using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Book_manage_Csharp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string connstring = "server=localhost;userid=root;password=phat12112002;database=test;";
            String query = "Select * from cat;";
            MySqlConnection cn;
            try
            {
                cn = new MySqlConnection(connstring);
                Console.WriteLine("success");
                cn.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(query, cn);
                DataSet ds = new DataSet();
                da.Fill(ds, "cat");
                DataTable dt = ds.Tables["cat"];
                Console.WriteLine("No.\tname\towner\tbirth");
                foreach (DataRow row in dt.Rows)
                {
                    foreach (DataColumn col in dt.Columns)
                    {
                        Console.Write(row[col] + "\t");
                    }

                    Console.Write("\n");
                }
                cn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
        }
    }
}
