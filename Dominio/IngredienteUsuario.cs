using Dominio.BD;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Dominio
{
    public class IngredienteUsuario : IngredienteConCantidad, IMapeador
    {
        public int _IdUsuario;
        public IngredienteUsuario(Ingrediente Ing, int Cantidad, int IdUsuario) : base(Ing, Cantidad)
        {
            _IdUsuario = IdUsuario;
        }

        public bool Insertar()
        {
            SqlConnection cn = ManejadorConexion.CrearConexion();
            SqlCommand cmd = new SqlCommand(@"INSERT INTO IngredientesUsuarios VALUES (@IdUsuario, @IdIngrediente, @Cantidad)", cn);
            cmd.Parameters.Add(new SqlParameter("@IdUsuario", _IdUsuario));
            cmd.Parameters.Add(new SqlParameter("@IdIngrediente", _Ingrediente._Id));
            cmd.Parameters.Add(new SqlParameter("@Cantidad", _Cantidad));
            try
            {
                ManejadorConexion.AbrirConexion(cn);
                int filas = cmd.ExecuteNonQuery();
                return filas == 1;
            }
            catch (SqlException ex)
            {
                System.Diagnostics.Debug.Assert(false, ex.Message);
                return false;
            }
            finally
            {
                ManejadorConexion.CerrarConexion(cn);
            }
        }

        public bool Actualizar()
        {
            SqlConnection cn = ManejadorConexion.CrearConexion();

            SqlCommand cmd = new SqlCommand(@"UPDATE IngredientesUsuarios 
                                SET Cantidad = @Cantidad                                
                                WHERE IdUsuario = @IdUsuario AND IdIngrediente = @IdIngrediente", cn);
            cmd.Parameters.Add(new SqlParameter("@IdUsuario", _IdUsuario));
            cmd.Parameters.Add(new SqlParameter("@IdIngrediente", _Ingrediente._Id));
            cmd.Parameters.Add(new SqlParameter("@Cantidad", _Cantidad));
            try
            {
                ManejadorConexion.AbrirConexion(cn);
                int filas = cmd.ExecuteNonQuery();
                return filas == 1;
            }
            catch (SqlException ex)
            {
                System.Diagnostics.Debug.Assert(false, ex.Message);
                return false;
            }
            finally
            {
                ManejadorConexion.CerrarConexion(cn);
            }
        }

        public bool Borrar()
        {
            SqlConnection cn = ManejadorConexion.CrearConexion();

            SqlCommand cmd = new SqlCommand(@"DELETE FROM IngredientesUsuarios 
                                WHERE IdUsuario = @IdUsuario AND IdIngrediente = @IdIngrediente", cn);
            cmd.Parameters.Add(new SqlParameter("@IdUsuario", _IdUsuario));
            cmd.Parameters.Add(new SqlParameter("@IdIngrediente", _Ingrediente._Id));
            try
            {
                ManejadorConexion.AbrirConexion(cn);
                int filas = cmd.ExecuteNonQuery();
                return filas == 1;
            }
            catch (SqlException ex)
            {
                System.Diagnostics.Debug.Assert(false, ex.Message);
                return false;
            }
            finally
            {
                ManejadorConexion.CerrarConexion(cn);
            }
        }

        internal static List<IngredienteUsuario> TraerConIdUsuario(int id)
        {
            throw new NotImplementedException();
        }
    }
   
}
