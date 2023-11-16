using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using MySqlX.XDevAPI;
using Org.BouncyCastle.Ocsp;
using System.Globalization;
using System.Text;

namespace Beeuzer.Models
{
    public class Carrinho
    {
        public int IdCar { get; set; }
        public Produto Produto { get; set; }
        public Cliente Cliente { get; set; }
    }
}