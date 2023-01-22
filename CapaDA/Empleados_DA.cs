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
    public class Empleados_DA
    {
        public List<Empleados_ET> Listado()
        {
            var ls = new List<Empleados_ET>();
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BASE"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("SELECT * FROM T_EMPLEADOS", con);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var u = new Empleados_ET
                            {
                                Id_NumEmp = Convert.ToInt32(dr["Id_NumEmp"]),
                                Nombre = dr["Nombre"].ToString(),
                                Apellidos = dr["Apellidos"].ToString(),
                                Id_Puesto = Convert.ToInt32(dr["IDPuesto"]),
                            };
                            ls.Add(u);
                        }
                    }
                    //queremos las T_CAT_PUESTO
                    foreach (var m in ls)
                    {
                        query = new SqlCommand("SELECT * FROM T_CAT_PUESTO WHERE Id_Puesto = @Id_Puesto", con);
                        query.Parameters.AddWithValue("@Id_Puesto", m.Id_Puesto);
                        using (var dr = query.ExecuteReader())
                        {
                            dr.Read();
                            if (dr.HasRows)
                            {
                                m.Puesto.Id_Puesto = Convert.ToInt32(dr["Id_Puesto"]);
                                m.Puesto.Puesto = dr["Puesto"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception e) { throw e; }
            return ls;
        }



        public bool RegistroNuevo(Empleados_ET cls)
        {
            bool resp = false;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BASE"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("INSERT INTO T_EMPLEADOS(Nombre, Apellidos, IDPuesto) VALUES(@p0, @p1, @p2)", con);
                    query.Parameters.AddWithValue("@p0", cls.Nombre);
                    query.Parameters.AddWithValue("@p1", cls.Apellidos);
                    query.Parameters.AddWithValue("@p2", cls.Id_Puesto);
                    query.ExecuteNonQuery();
                    resp = true;
                }
            }
            catch (Exception e) {  }
            return resp;
        }

        public Empleados_ET Obtener(int? Id_NumEmp)
        {
            var list = new Empleados_ET();
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BASE"].ToString()))
                {
                    con.Open();
                    var QUERY = new SqlCommand("SELECT * FROM T_EMPLEADOS WHERE Id_NumEmp = @Id_NumEmp", con);
                    QUERY.Parameters.AddWithValue("@Id_NumEmp", Id_NumEmp);
                    using (var dr = QUERY.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows)
                        {
                            list.Id_NumEmp = Convert.ToInt32(dr["Id_NumEmp"]);
                            list.Nombre = dr["Nombre"].ToString();
                            list.Apellidos = dr["Apellidos"].ToString();
                            list.Id_Puesto = Convert.ToInt32(dr["IDPuesto"]);
                        }
                    }
                }
            }
            catch (Exception e) { throw e; }
            return list;
        }

        public Empleados_ET Modificar(Empleados_ET cls)
        {
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BASE"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("UPDATE T_EMPLEADOS SET Nombre = @p1, Apellidos = @p2, IDPuesto = @p3 WHERE Id_NumEmp = @p0", con);
                    query.Parameters.AddWithValue("@p1", cls.Nombre);
                    query.Parameters.AddWithValue("@p2", cls.Apellidos);
                    query.Parameters.AddWithValue("@p3", cls.Id_Puesto);
                    query.Parameters.AddWithValue("@p0", cls.Id_NumEmp);
                    query.ExecuteNonQuery();
                }
            }
            catch (Exception e) { throw e; }
            return cls;
        }

        public bool Eliminar(int id)
        {
            bool resp = false;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BASE"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("DELETE FROM T_EMPLEADOS WHERE Id_NumEmp = @p0", con);
                    query.Parameters.AddWithValue("@p0", id);
                    query.ExecuteNonQuery();
                    resp = true;
                }
            }
            catch (Exception e) { throw e; }
            return resp;
        }
    }
}
