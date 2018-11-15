using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class DalHelper
    {

        internal static List<Ingrediente> GetIngredientes()
        {
            List<Ingrediente> ings = new List<Ingrediente>();
            SqlConnection cn = ManejadorConexion.CrearConexion();

            SqlCommand cmd = new SqlCommand(@"SELECT * FROM Ingredientes", cn);
            try
            {
                ManejadorConexion.AbrirConexion(cn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Ingrediente ing = new Ingrediente();
                        ing._Id = Convert.ToInt32(dr["Id"]);
                        ing._Nombre = dr["Nombre"].ToString();
                        ing._Costo = Convert.ToInt32(dr["Costo"]);
                        ing._Medida = dr["Medida"].ToString();
                        ing._MedidaPromedio = Convert.ToInt32(dr["MedidaPromedio"]);
                        ing._MedidaPorGramo = Convert.ToInt32(dr["MedidaPorGramo"]);
                        ing._CantCaloriasPorMedida = Convert.ToInt32(dr["CantCalorias"]);
                        ing._AptoCeliacos = (bool)dr["aptoCeliacos"];
                        ing._AptoDiabeticos = (bool)dr["aptoDiabeticos"];
                        ing._AptoVegetarianos = (bool)dr["aptoVegetarianos"];
                        ing._AptoVeganos = (bool)dr["aptoVeganos"];
                        ing._Tipo = Convert.ToInt32(dr["tipo"]);
                        ing._Estacion = Convert.ToInt32(dr["tipo"]);
                        ings.Add(ing);
                    }
                }
                return ings;
            }
            catch (SqlException ex)
            {
                System.Diagnostics.Debug.Assert(false, ex.Message);
                return null;
            }
            finally
            {
                ManejadorConexion.CerrarConexion(cn);
            }
        }

        internal static Ingrediente FindIngrediente(int id)
        {
            Ingrediente ing = new Ingrediente();
            SqlConnection cn = ManejadorConexion.CrearConexion();

            SqlCommand cmd = new SqlCommand(@"SELECT * FROM Ingredientes
                                              WHERE @id = id", cn);
            cmd.Parameters.Add(new SqlParameter("@id", id));

            try
            {
                ManejadorConexion.AbrirConexion(cn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    if (dr.Read())
                    {
                        ing._Id = Convert.ToInt32(dr["Id"]);
                        ing._Nombre = dr["Nombre"].ToString();
                        ing._Costo = Convert.ToInt32(dr["Costo"]);
                        ing._Medida = dr["Medida"].ToString();
                        ing._MedidaPromedio = Convert.ToInt32(dr["MedidaPromedio"]);
                        ing._MedidaPorGramo = Convert.ToInt32(dr["MedidaPorGramo"]);
                        ing._CantCaloriasPorMedida = Convert.ToInt32(dr["CantCalorias"]);
                        ing._AptoCeliacos = (bool)dr["aptoCeliacos"];
                        ing._AptoDiabeticos = (bool)dr["aptoDiabeticos"];
                        ing._AptoVegetarianos = (bool)dr["aptoVegetarianos"];
                        ing._AptoVeganos = (bool)dr["aptoVeganos"];
                        ing._Tipo = Convert.ToInt32(dr["tipo"]);
                        ing._Estacion = Convert.ToInt32(dr["tipo"]);
                    }
                }
                return ing;
            }
            catch (SqlException ex)
            {
                System.Diagnostics.Debug.Assert(false, ex.Message);
                return null;
            }
            finally
            {
                ManejadorConexion.CerrarConexion(cn);
            }
        }

        public static bool InsertarIng(Ingrediente ing)
        {
            SqlConnection cn = ManejadorConexion.CrearConexion();

            SqlCommand cmd = new SqlCommand(@"INSERT INTO Ingredientes VALUES (@Nombre, @Costo, @Medida, @MedidaPromedio, @MedidaPorGramo, 
                                             @CantCalorias, @AptoCeliacos, @AptoDiabeticos, @AptoVegetarianos, @AptoVeganos, @Tipo, @Estacion); 
                                             SELECT SCOPE_IDENTITY()", cn);

            cmd.Parameters.Add(new SqlParameter("@Nombre", ing._Nombre));
            cmd.Parameters.Add(new SqlParameter("@Costo", ing._Costo));
            cmd.Parameters.Add(new SqlParameter("@Medida", ing._Medida.ToString()));
            cmd.Parameters.Add(new SqlParameter("@MedidaPromedio", ing._MedidaPromedio));
            cmd.Parameters.Add(new SqlParameter("@MedidaPorGramo", ing._MedidaPorGramo));
            cmd.Parameters.Add(new SqlParameter("@CantCalorias", ing._CantCaloriasPorMedida));
            cmd.Parameters.Add(new SqlParameter("@AptoCeliacos", (bool)ing._AptoCeliacos));
            cmd.Parameters.Add(new SqlParameter("@AptoDiabeticos", (bool)ing._AptoDiabeticos));
            cmd.Parameters.Add(new SqlParameter("@AptoVegetarianos", (bool)ing._AptoVegetarianos));
            cmd.Parameters.Add(new SqlParameter("@AptoVeganos", (bool)ing._AptoVeganos));
            cmd.Parameters.Add(new SqlParameter("@Tipo", Convert.ToInt32(ing._Tipo)));
            cmd.Parameters.Add(new SqlParameter("@Estacion", Convert.ToInt32(ing._Estacion)));
            try
            {
                ManejadorConexion.AbrirConexion(cn);
                ing._Id = Convert.ToInt32(cmd.ExecuteScalar());
                return true;
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

    }
}