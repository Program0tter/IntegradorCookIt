using Persistencia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;

namespace Dominio
{
    public class Cliente : Usuario
    {
        public List<IngredienteUsuario> _MisIngredientes { set; get; }
        public List<RecetaDeHistorial> _HistorialRecetas { set; get; }
        public List<RecetaFavorita> _RecetasFavoritas { set; get; }

        public Cliente() { }

        //Constructor para traer de BD
        public Cliente(int Id, string Email, byte[] Foto, string NombreUsuario, string Nombre, string Apellido,
            List<IngredienteUsuario> MisIng, List<RecetaDeHistorial> HistRec, List<RecetaFavorita> RecFav)
        : base(Id, Email, Foto, NombreUsuario, Nombre, Apellido)
        {
            _MisIngredientes = MisIng;
            _HistorialRecetas = HistRec;
            _RecetasFavoritas = RecFav;
        }


        //Creacion de nuevo Cliente
        public Cliente(string Email, string Pass, byte[] Foto, string NombreUsuario, string Nombre, string Apellido)
        : base(Email, Pass, Foto, NombreUsuario, Nombre, Apellido)
        {
            _MisIngredientes = new List<IngredienteUsuario>();
            _HistorialRecetas = new List<RecetaDeHistorial>();
            _RecetasFavoritas = new List<RecetaFavorita>();
        }

        public override TipoUsuario QueSoy() {
            return TipoUsuario.Cliente;
        }
        public override object Login(string correo, string pass)
        {
            Cliente cli = new Cliente();
            bool RequestStatus = false;

            SqlConnection cn = ManejadorConexion.CrearConexion();
            SqlCommand cmd = new SqlCommand("sp_Login", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@email", correo));
            cmd.Parameters.Add(new SqlParameter("@pass", pass));
            cmd.Parameters.Add(new SqlParameter("@respuesta", SqlDbType.Bit) { Direction = ParameterDirection.Output });

            try
            {
                ManejadorConexion.AbrirConexion(cn);
                cmd.ExecuteNonQuery();
                RequestStatus = (bool)cmd.Parameters["@respuesta"].Value;

                if (RequestStatus)
                {
                    cmd = new SqlCommand(@"SELECT * FROM Usuarios WHERE email = @email", cn);
                    cmd.Parameters.Add(new SqlParameter("@email", correo));
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    { 
                        IDataRecord fila = dr;
                        if (fila != null)
                        {
                            cli._Id = fila.IsDBNull(fila.GetOrdinal("id")) ? 0 : fila.GetInt32(fila.GetOrdinal("id"));
                            cli._Email = correo;
                            cli._Nombre = fila.IsDBNull(fila.GetOrdinal("nombre")) ? "" : fila.GetString(fila.GetOrdinal("nombre"));// dr["nombre"].ToString();
                            cli._Apellido = fila.IsDBNull(fila.GetOrdinal("apellido")) ? "" : fila.GetString(fila.GetOrdinal("apellido"));// dr["apellido"].ToString();
                            cli._NombreUsuario = fila.IsDBNull(fila.GetOrdinal("nombreUsuario")) ? "" : fila.GetString(fila.GetOrdinal("nombreUsuario")); // dr["nombreUsuario"].ToString();
                            cli._Foto = fila.IsDBNull(fila.GetOrdinal("foto")) ? null : (byte[])fila.GetValue(fila.GetOrdinal("foto")); // (byte[])dr["foto"]; (byte [])obj.GetValue(0)                            
                        }
                    }
                    //Tambien hay que rellenar las listas de ingredientes, recetas, etc.

                    //cli.TraerSubordinadas();

                    return cli;
                }
                else
                {
                    throw new Exception("Login incorrecto, por favor intentelo nuevamente.");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Assert(false, ex.Message);
                return null;
            }
            finally
            {
                ManejadorConexion.CerrarConexion(cn);
            }
        }

        public override bool Insertar()
        {
            //if (!this.Validar()) return false;

            SqlConnection cn = ManejadorConexion.CrearConexion();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"INSERT INTO Usuarios (email, pass, nombreUsuario, tipo) VALUES (@email, @pass, @nombreUsuario, @tipo)";
            cmd.Parameters.AddWithValue("@email", this._Email);
            cmd.Parameters.AddWithValue("@pass", this._Pass);                       
            cmd.Parameters.AddWithValue("@nombreUsuario", this._NombreUsuario);          
            cmd.Parameters.AddWithValue("@tipo", this.QueSoy());
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

        public override bool ActualizarPerfil() {

            SqlConnection cn = ManejadorConexion.CrearConexion();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"UPDATE Usuarios 
                                SET nombre = @nombre, apellido = @apellido, nombreUsuario = @nomUsu, foto = @foto
                                WHERE email = @email
                                AND tipo = @tipo";
            cmd.Parameters.AddWithValue("@email", this._Email);
            cmd.Parameters.AddWithValue("@nombre", this._Nombre);
            cmd.Parameters.AddWithValue("@apellido", this._Apellido);
            cmd.Parameters.AddWithValue("@nomUsu", this._NombreUsuario);
            cmd.Parameters.AddWithValue("@foto", null);
            //cmd.Parameters.AddWithValue("@foto", this._Foto);
            cmd.Parameters.AddWithValue("@tipo", this.QueSoy());
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


        private void TraerSubordinadas()
        {
            try {
                this._MisIngredientes = IngredienteUsuario.TraerConIdUsuario(this._Id);
                this._HistorialRecetas = RecetaDeHistorial.TraerConIdUsuario(this._Id);
                this._RecetasFavoritas = RecetaFavorita.TraerConIdUsuario(this._Id);
            }
            catch (Exception ex) {

            }
        }
    }
}
