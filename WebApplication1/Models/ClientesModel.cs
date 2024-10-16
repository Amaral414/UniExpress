using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class ClientesModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string DataNascimento { get; set; }
        public string DataCadastro { get; set; }
        public string Senha { get; set; }
        public decimal SaldoConta { get; set; }
        public decimal SaldoContaBTC { get; set; }
    }
}
