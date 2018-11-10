using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Persistencia
{
    public class ManejadorConexion
    {

        private static string _CadenaConexion = ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString; 

        public static SqlConnection CrearConexion()
        {
            return new SqlConnection(_CadenaConexion);
        }

        public static bool AbrirConexion(SqlConnection conexion)
        {
            if (conexion == null || conexion.State == ConnectionState.Open) return false;
            conexion.Open();
            return true;
        }

        public static bool CerrarConexion(SqlConnection conexion)

        {
            if (conexion == null || conexion.State != ConnectionState.Open) return false;
            conexion.Close();
            conexion.Dispose();
            return true;
        }


        //public void GenerarStringFiltro(List<Filtro> filtros)
        //{
        //    string filtro = "WHERE ";
        //    for (int i = 0; i < filtros.Count; i++)
        //    {
        //        if (i != 0) filtro += " AND ";
        //        filtro += filtros[i].ToString();
        //    }
        //}

    }
}
