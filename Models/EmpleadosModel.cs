using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class EmpleadosModel
    {
        public int Id_NumEmp { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Id_Puesto { get; set; }
        public Puestos_ET Puesto { get; set; }
        public EmpleadosModel()
        {
            Puesto = new Puestos_ET();
        }
    }

}
