﻿using Persistencia;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Dominio
{
    public class IngredienteReceta : IngredienteConCantidad, IMapeador
    {
        public int _IdReceta { set; get; }
        public IngredienteReceta(Ingrediente Ing, int Cantidad, int IdReceta) : base(Ing, Cantidad)
        {
            _IdReceta = IdReceta;
        }

        public bool Insertar()
        {
            SqlConnection cn = ManejadorConexion.CrearConexion();
            SqlCommand cmd = new SqlCommand(@"INSERT INTO IngredientesRecetas VALUES (@IdReceta, @IdIngrediente, @Cantidad)", cn);
            cmd.Parameters.Add(new SqlParameter("@IdReceta", _IdReceta));
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

            SqlCommand cmd = new SqlCommand(@"UPDATE IngredientesRecetas 
                                SET Cantidad = @Cantidad                                
                                WHERE IdReceta = @IdReceta AND IdIngrediente = @IdIngrediente", cn);
            cmd.Parameters.Add(new SqlParameter("@IdReceta", _IdReceta));
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

            SqlCommand cmd = new SqlCommand(@"DELETE FROM IngredientesRecetas 
                                WHERE IdReceta = @IdReceta AND IdIngrediente = @IdIngrediente", cn);
            cmd.Parameters.Add(new SqlParameter("@IdReceta", _IdReceta));
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
    }
}
