using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Biblioteca.CapaDatos;

namespace Biblioteca.CapaNegocio
{
    public class BusquedaAvanzada
    {
        /// <summary>
        /// CAMPO IDENTIFICADOR DE LA TABLA
        /// </summary>
        public int Autor { get; set; }

        /// <summary>
        /// CAMPO DESCRIPCIÓN DE LA TABLA
        /// </summary>
        public string Titulo { get; set; }

        /// <summary>
        /// CAMPO MONTO DE LA TABLA
        /// </summary>
        public decimal Editor { get; set; }

        /// <summary>
        /// CAMPO DESCRIPCIÓN DE LA TABLA
        /// </summary>
        public string Materias { get; set; }

        /// <summary>
        /// CAMPO DESCRIPCIÓN DE LA TABLA
        /// </summary>
        public string Descriptores { get; set; }

        /// <summary>
        /// CAMPO DESCRIPCIÓN DE LA TABLA
        /// </summary>
        public string Cumplir { get; set; }

        BaseDatos objetoBD = new BaseDatos();

    }
}
