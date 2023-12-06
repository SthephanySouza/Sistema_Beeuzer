using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Beeuzer.Models
{
    public class Pagamento
    {
        public int NumPaga { get; set; }
        public string FormPaga { get; set; }
        public string NomeTitular { get; set; }
        public List<TipoPaga> NumCartao = new List<TipoPaga>();
    }
}