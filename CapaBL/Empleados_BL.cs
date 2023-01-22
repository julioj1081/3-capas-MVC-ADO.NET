using CapaDA;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaBL
{
    public class Empleados_BL
    {
        private Empleados_DA empleados_DA = new Empleados_DA();

        public List<Empleados_ET> listaEmpleados()
        {
            return empleados_DA.Listado();
        }
        public bool Registrar(Empleados_ET cls)
        {
            return empleados_DA.RegistroNuevo(cls);
        }

        public object Obtener(int id)
        {
            return empleados_DA.Obtener(Convert.ToInt32(id));
        }

        public Empleados_ET Actualizar(Empleados_ET cls)
        {
            return empleados_DA.Modificar(cls);
        }

        public bool Eliminar(int id)
        {
            return empleados_DA.Eliminar(id);
        }
    }
}
