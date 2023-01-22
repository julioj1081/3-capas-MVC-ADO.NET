using Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDA
{
    public class Puestos_DA
    {
        public List<Puestos_ET> Listar()
        {
            var materia = new List<Puestos_ET>();
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BASE"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("SELECT * FROM T_CAT_PUESTO", con);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            materia.Add(new Puestos_ET
                            {
                                Id_Puesto = Convert.ToInt32(dr["Id_Puesto"]),
                                Puesto = dr["Puesto"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception e) { throw e; }
            return materia;
        }
    }
}
