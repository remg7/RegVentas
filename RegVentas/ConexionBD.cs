using System;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace RegVentas
{
    public static class ConexionBD
    {
        private static readonly string cadenaConexion;

        static ConexionBD()
        {
            try
            {
                cadenaConexion = ConfigurationManager.ConnectionStrings["ConnRegVentas"]?.ConnectionString;
            }
            catch
            {
                // Fallback silencioso si no se encuentra la cadena de configuración
            }

            if (string.IsNullOrEmpty(cadenaConexion))
            {
                cadenaConexion = "server=localhost;database=regventas;uid=root;password=;";
            }
        }

        /// <summary>
        /// Obtiene una nueva instancia de MySqlConnection conectada a la base de datos MySQL de RegVentas.
        /// </summary>
        public static MySqlConnection ObtenerConexion()
        {
            return new MySqlConnection(cadenaConexion);
        }
    }
}
