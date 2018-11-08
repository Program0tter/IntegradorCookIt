using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Dominio.BD
{
    public class MapeadorIngrediente : IMapeador
    {

        Ingrediente _Ing { set; get; }

        public MapeadorIngrediente(Ingrediente ing)
        {
            _Ing = ing;
        }

        public bool Insertar()
        {
            SqlConnection cn = ManejadorConexion.CrearConexion();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"INSERT INTO Ingrediente VALUES (@Nombre, @Costo, @Medida, @MedidaPromedio, @MedidaPorGramo, 
                              @CantCalorias, @AptoCeliacos, @AptoDiabeticos, @AptoVegetarianos, @AptoVeganos, @Tipo, @Estacion)";
            cmd.Parameters.Add(new SqlParameter("@Nombre", _Ing._Nombre));
            cmd.Parameters.Add(new SqlParameter("@Costo", _Ing._Costo));
            cmd.Parameters.Add(new SqlParameter("@Media", _Ing._Medida));
            cmd.Parameters.Add(new SqlParameter("@MedidaPromedio", _Ing._MedidaPromedio));
            cmd.Parameters.Add(new SqlParameter("@MedidaPorGramo", _Ing._MedidaPorGramo));
            cmd.Parameters.Add(new SqlParameter("@CantCalorias", _Ing._CantCaloriasPorMedida));
            cmd.Parameters.Add(new SqlParameter("@AptoCeliacos", _Ing._AptoCeliacos));
            cmd.Parameters.Add(new SqlParameter("@AptoDiabeticos", _Ing._AptoDiabeticos));
            cmd.Parameters.Add(new SqlParameter("@AptoVegetarianos", _Ing._AptoVegetarianos));
            cmd.Parameters.Add(new SqlParameter("@AptoVeganos", _Ing._AptoVeganos));
            cmd.Parameters.Add(new SqlParameter("@Tipo", _Ing._Tipo));
            cmd.Parameters.Add(new SqlParameter("@Estacion", _Ing._Estacion));
            cmd.Connection = cn;
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

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"UPDATE Ingrediente 
                                SET nombre = @Nombre, costo = @Costo, medida = @Medida, medidaPromedio = @MedidaPromedio, medidaPorGramo = @MedidaPorGramo, 
                                   cantCalorias = @CantCalorias, aptoCeliacos = @AptoCeliacos, aptoDiabeticos = @AptoDiabeticos, aptoVegetarianos = @AptoVegetarianos, 
                                   aptoVeganos = @AptoVeganos, tipo = @Tipo, estacion = @Estacion
                                WHERE id = @Id";
            cmd.Parameters.Add(new SqlParameter("@Id", _Ing._Id));
            cmd.Parameters.Add(new SqlParameter("@Nombre", _Ing._Nombre));
            cmd.Parameters.Add(new SqlParameter("@Costo", _Ing._Costo));
            cmd.Parameters.Add(new SqlParameter("@Media", _Ing._Medida));
            cmd.Parameters.Add(new SqlParameter("@MedidaPromedio", _Ing._MedidaPromedio));
            cmd.Parameters.Add(new SqlParameter("@MedidaPorGramo", _Ing._MedidaPorGramo));
            cmd.Parameters.Add(new SqlParameter("@CantCalorias", _Ing._CantCaloriasPorMedida));
            cmd.Parameters.Add(new SqlParameter("@AptoCeliacos", _Ing._AptoCeliacos));
            cmd.Parameters.Add(new SqlParameter("@AptoDiabeticos", _Ing._AptoDiabeticos));
            cmd.Parameters.Add(new SqlParameter("@AptoVegetarianos", _Ing._AptoVegetarianos));
            cmd.Parameters.Add(new SqlParameter("@AptoVeganos", _Ing._AptoVeganos));
            cmd.Parameters.Add(new SqlParameter("@Tipo", _Ing._Tipo));
            cmd.Parameters.Add(new SqlParameter("@Estacion", _Ing._Estacion));
            cmd.Connection = cn;
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

        public void Borrar()
        {
            throw new NotImplementedException();
        }

        public string Select()
        {
            throw new NotImplementedException();
        }

        public void GenerarObjetoPrincipal(SqlDataReader dr)
        {
            throw new NotImplementedException();
        }

        public void GenerarObjetoSubordinado(SqlDataReader dr)
        {
            throw new NotImplementedException();
        }

    }
}
