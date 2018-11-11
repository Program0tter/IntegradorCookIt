using Persistencia;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Dominio.BD
{
    public class MapeadorReceta
    {/*
        Receta _Receta { set; get; }

        public bool Actualizar()
        {
            throw new NotImplementedException();
        }

        public void Borrar()
        {
            throw new NotImplementedException();
        }

        public void GenerarObjetoPrincipal()
        {
            throw new NotImplementedException();
        }

        public void GenerarObjetoSubordinado()
        {
            throw new NotImplementedException();
        }

        public bool Insertar()
        {
            SqlConnection cn = ManejadorConexion.CrearConexion();
            SqlTransaction trn = null;
            SqlCommand cmd = new SqlCommand(@"INSERT INTO Recetas (momentoDia, estacion, dificultad, tiempoPreparacion,
                                              paisOrigen, foto, idCreador, cantPlatos) VALUES (@MomentoDia, @Estacion, 
                                              @Dificultad, @TiempoPreparacion, @PaisOrigen, @Foto, @IdCreador, @CantPlatos); 
                                              SELECT SCOPE_IDENTITY()", cn);
            ManejadorConexion.AbrirConexion(cn);
            trn = cn.BeginTransaction();

            cmd.Parameters.Add(new SqlParameter("@MomentoDia", (int)_Receta._MomentoDia));
            cmd.Parameters.Add(new SqlParameter("@Estacion", (int)_Receta._Estacion));
            cmd.Parameters.Add(new SqlParameter("@Dificultad", _Receta._Dificultad));
            cmd.Parameters.Add(new SqlParameter("@TiempoPreparacion", _Receta._TiempoPreparacion));
            cmd.Parameters.Add(new SqlParameter("@PaisOrigen", (int) _Receta._PaisOrigen));
            cmd.Parameters.Add(new SqlParameter("@Foto", _Receta._Foto));
            cmd.Parameters.Add(new SqlParameter("@IdCreador", _Receta._Creador._Id));
            cmd.Parameters.Add(new SqlParameter("@CantPlatos", _Receta._CantPlatos));
            try
            {
                ManejadorConexion.AbrirConexion(cn);
                int idReceta = (int) cmd.ExecuteScalar();
                return true;
            }
            catch (SqlException ex)
            {
                System.Diagnostics.Debug.Assert(false, ex.Message);
                trn.Rollback();
                return false;
            }
            finally
            {
                trn.Dispose();
                ManejadorConexion.CerrarConexion(cn);
            }
        }
            */
    }
}
