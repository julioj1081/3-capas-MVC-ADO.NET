using CapaDA;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaBL
{
    public class Puestos_BL
    {
        private Puestos_DA materiaDL = new Puestos_DA();

        public List<Puestos_ET> Listar()
        {
            return materiaDL.Listar();
        }

    }
}
