using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Configuration;

namespace Biblioteca.CapaDatos
{
    public class BaseDatos
    {

        private DbConnection conexion = null;
        private DbCommand comando = null;
        private string cadenaConexion;
        private static DbProviderFactory factory = null;

        public BaseDatos()
        {
            Configurar();
        }

        private void Configurar()
        {
            try
            {
                string proveedor = ConfigurationManager.AppSettings.Get("PROVEEDOR");
                this.cadenaConexion = ConfigurationManager.AppSettings.Get("CADENA");
                BaseDatos.factory = DbProviderFactories.GetFactory(proveedor);
            }
            catch (ConfigurationException ex)
            {
                throw new Exception("Error al cargar la configuracion de base de datos.", ex);
            }
        }

        public void Conectar()
        {
            if (this.conexion != null && this.conexion.State.Equals(ConnectionState.Open))
            {
                throw new Exception("La conexion se encuentra abierta");
            }

            try
            {
                if (this.conexion == null)
                {
                    this.conexion = factory.CreateConnection();
                    this.conexion.ConnectionString = cadenaConexion;
                }
                this.conexion.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al conectarse a la Base de Datos", ex.InnerException);
            }
        }

        public void Desconectar()
        {
            if (this.conexion.State.Equals(ConnectionState.Open))
                this.conexion.Close();
        }

        public void CrearComando(string sentenciaSQL)
        {
            this.comando = factory.CreateCommand();
            this.comando.Connection = this.conexion;
            this.comando.CommandType = CommandType.Text;
            this.comando.CommandText = sentenciaSQL;
        }

        public int EjecutarEscalar()
        {
            int escalar = 0;

            try
            {
                escalar = int.Parse(this.comando.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar Escalar", ex);
            }

            return escalar;
        }

        public DbDataReader EjecutarConsulta()
        {
            return this.comando.ExecuteReader();
        }

        private void AsignarParametro(string nombre, string separador, string valor)
        {
            int indice = this.comando.CommandText.IndexOf(nombre);
            string prefijo = this.comando.CommandText.Substring(0, indice);
            string sufijo = this.comando.CommandText.Substring(indice + nombre.Length);
            this.comando.CommandText = prefijo + separador + valor + separador + sufijo;
        }

        public void AsignarParametroDecimal(string nombre, decimal valor)
        {
            AsignarParametro(nombre, " ", valor.ToString());
        }

        public void AsignarParametroEntero(string nombre, int valor)
        {
            AsignarParametro(nombre, " ", valor.ToString());
        }

        public void AsignarParametroCadena(string nombre, string valor)
        {
            AsignarParametro(nombre, "'", valor);
        }

    }
}
