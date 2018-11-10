using Dominio.BD;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Dominio
{
    public class Ingrediente : IMapeador
    {
        public enum Tipo { Frutas = 1, Verduras = 2, Lacteos = 3, Carnes = 4,
            PescadosMariscos = 5, Legumbres = 6, FrutosSecosSemillas = 7,
            Cereales = 8, SalsasAderezos = 9, AceitesGrasas = 10, ParaHornear = 11,
            EspeciasHierbas = 12 }
        public enum Estacion { Verano = 1, Otono = 2, Invierno = 3, Primavera = 4, Varios = 5}

        //1 = mg, 2 = ml
        public enum TipoMedida { Mg = 1, Ml = 2 }


        public int _Id { set; get; }
        public string _Nombre { set; get; }
        public int _Costo { set; get; }
        public TipoMedida _Medida { set; get; }
        public int _MedidaPromedio { set; get; }
        public int _MedidaPorGramo { set; get; }
        public int _CantCaloriasPorMedida { set; get; }
        public bool _AptoCeliacos { set; get; }
        public bool _AptoDiabeticos{ set; get; }
        public bool _AptoVegetarianos { set; get; }
        public bool _AptoVeganos { set; get; }
        public Estacion _Estacion { set; get; }
        public Tipo _Tipo { set; get; }

        public Ingrediente(int id, string nombre, int costo, int tipoMedida, int medidaProm, int medidaGramo, int caloriasMedida, 
            bool aptoCel, bool aptoDia, bool aptoVegetariano, bool aptoVegano, int idTipo, int idEstacion) {
            _Id = id;
            _Nombre = nombre;
            _Costo = costo;
            _Medida = (TipoMedida) tipoMedida;
            _Estacion = (Estacion) idEstacion;
            _Tipo = (Tipo) idTipo;
            _MedidaPromedio = medidaProm;
            _MedidaPorGramo = medidaGramo;
            _CantCaloriasPorMedida = caloriasMedida;
            _AptoCeliacos = aptoCel;
            _AptoDiabeticos = aptoDia;
            _AptoVegetarianos = aptoVegetariano;
            _AptoVeganos = _AptoVeganos;
        }

        public Ingrediente(string nombre, int costo, int tipoMedida, int medidaProm, int medidaGramo, int caloriasMedida,
            bool aptoCel, bool aptoDia, bool aptoVegetariano, bool aptoVegano, int idTipo, int idEstacion){
            _Nombre = nombre;
            _Costo = costo;
            _Medida = (TipoMedida)tipoMedida;
            _Estacion = (Estacion)idEstacion;
            _Tipo = (Tipo)idTipo;
            _MedidaPromedio = medidaProm;
            _MedidaPorGramo = medidaGramo;
            _CantCaloriasPorMedida = caloriasMedida;
            _AptoCeliacos = aptoCel;
            _AptoDiabeticos = aptoDia;
            _AptoVegetarianos = aptoVegetariano;
            _AptoVeganos = _AptoVeganos;
        }

        public bool Insertar()
        {
            SqlConnection cn = ManejadorConexion.CrearConexion();

            SqlCommand cmd = new SqlCommand(@"INSERT INTO Ingredientes VALUES (@Nombre, @Costo, @Medida, @MedidaPromedio, @MedidaPorGramo, 
                                             @CantCalorias, @AptoCeliacos, @AptoDiabeticos, @AptoVegetarianos, @AptoVeganos, @Tipo, @Estacion)", cn);
            cmd.Parameters.Add(new SqlParameter("@Nombre", _Nombre));
            cmd.Parameters.Add(new SqlParameter("@Costo", _Costo));
            cmd.Parameters.Add(new SqlParameter("@Media", _Medida));
            cmd.Parameters.Add(new SqlParameter("@MedidaPromedio", _MedidaPromedio));
            cmd.Parameters.Add(new SqlParameter("@MedidaPorGramo", _MedidaPorGramo));
            cmd.Parameters.Add(new SqlParameter("@CantCalorias", _CantCaloriasPorMedida));
            cmd.Parameters.Add(new SqlParameter("@AptoCeliacos", _AptoCeliacos));
            cmd.Parameters.Add(new SqlParameter("@AptoDiabeticos", _AptoDiabeticos));
            cmd.Parameters.Add(new SqlParameter("@AptoVegetarianos", _AptoVegetarianos));
            cmd.Parameters.Add(new SqlParameter("@AptoVeganos", _AptoVeganos));
            cmd.Parameters.Add(new SqlParameter("@Tipo", _Tipo));
            cmd.Parameters.Add(new SqlParameter("@Estacion", _Estacion));
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
            cmd.CommandText = @"UPDATE Ingredientes 
                                SET nombre = @Nombre, costo = @Costo, medida = @Medida, medidaPromedio = @MedidaPromedio, 
                                   medidaPorGramo = @MedidaPorGramo, 
                                   cantCalorias = @CantCalorias, aptoCeliacos = @AptoCeliacos, aptoDiabeticos = @AptoDiabeticos,
                                   aptoVegetarianos = @AptoVegetarianos, 
                                   aptoVeganos = @AptoVeganos, tipo = @Tipo, estacion = @Estacion
                                WHERE id = @Id";
            cmd.Parameters.Add(new SqlParameter("@Id", _Id));
            cmd.Parameters.Add(new SqlParameter("@Nombre", _Nombre));
            cmd.Parameters.Add(new SqlParameter("@Costo", _Costo));
            cmd.Parameters.Add(new SqlParameter("@Media", _Medida));
            cmd.Parameters.Add(new SqlParameter("@MedidaPromedio", _MedidaPromedio));
            cmd.Parameters.Add(new SqlParameter("@MedidaPorGramo", _MedidaPorGramo));
            cmd.Parameters.Add(new SqlParameter("@CantCalorias", _CantCaloriasPorMedida));
            cmd.Parameters.Add(new SqlParameter("@AptoCeliacos", _AptoCeliacos));
            cmd.Parameters.Add(new SqlParameter("@AptoDiabeticos", _AptoDiabeticos));
            cmd.Parameters.Add(new SqlParameter("@AptoVegetarianos", _AptoVegetarianos));
            cmd.Parameters.Add(new SqlParameter("@AptoVeganos", _AptoVeganos));
            cmd.Parameters.Add(new SqlParameter("@Tipo", _Tipo));
            cmd.Parameters.Add(new SqlParameter("@Estacion", _Estacion));
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

        public bool Borrar()
        {
            return false;
        }

    }
}
