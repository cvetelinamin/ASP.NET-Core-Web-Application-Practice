using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyStore.Pages.Clients
{
    public class IndexModel : PageModel
    {
        public List<ClientInfo> listCLients = new List<ClientInfo>();
        public void OnGet()
        {
            try
            {
                string connectionString = "Data Source=LAPTOP-7QT45Q3P;Initial Catalog=MyStore;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM Clients";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ClientInfo clientInfo = new ClientInfo();
                                clientInfo.Id = "" + reader.GetInt32(0);
                                clientInfo.Name = reader.GetString(1);
                                clientInfo.Email = reader.GetString(2);
                                clientInfo.Phone = reader.GetString(3);
                                clientInfo.Address = reader.GetString(4);
                                clientInfo.Created_at = reader.GetDateTime(5).ToString();

                                listCLients.Add(clientInfo); 
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Exception: " + ex.ToString());
            }
        }
    }

    public class ClientInfo
    {
        public string Id;
        public string Name;
        public string Email;
        public string Phone;
        public string Address;
        public string Created_at;
    }
}
