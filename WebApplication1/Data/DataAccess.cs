using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class DataAccess
    {
        SqlConnection _connection = null;
        SqlCommand _command = null;
        public static IConfiguration Configuration{ get; set;}

        private string GetConnectionString()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            return Configuration.GetConnectionString("DefaultConnection");
        }

        public List<ClientesModel> ListarClientes()
        {
            List<ClientesModel> clientes = new List<ClientesModel>();

            using (_connection = new SqlConnection(GetConnectionString()))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = System.Data.CommandType.StoredProcedure;
                _command.CommandText = "listar_clientes";

                _connection.Open();
 
                SqlDataReader reader = _command.ExecuteReader();
                
                // Enquanto houver registros na tabela usuarios:
                while (reader.Read())
                {
                    ClientesModel cliente = new ClientesModel(); // Cria um usuário

                    // Atribui valores do banco ao usuário
                    cliente.Id = Convert.ToInt32(reader["idCliente"]);
                    cliente.Nome = reader["nome"].ToString();
                    cliente.SaldoConta = Convert.ToDecimal(reader["saldoConta"]);
                    cliente.SaldoContaBTC = Convert.ToDecimal(reader["saldoContaBTC"]);

                    clientes.Add(cliente);
                }
                _connection.Close();


            }


            return clientes;

        }

    }


}
