using Dominio.BD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Dominio
{
    public abstract class Usuario
    {
        public int _Id { set; get; }
        public string _Email { set; get; }
        public string _Pass { set; get; }
        public string _Foto { set; get; }
        public string _NombreUsuario { set; get; }
        public string _Nombre { set; get; }
        public string _Apellido { set; get; }

        public Usuario(int Id, string Email, string Foto, string NombreUsuario, string Nombre, string Apellido) {
            _Id = Id;
            _Email = Email;
            _Foto = Foto;
            _NombreUsuario = NombreUsuario;
            _Nombre = Nombre;
            _Apellido = Apellido;
        }
        public Usuario(string Email, string Pass, string Foto, string NombreUsuario, string Nombre, string Apellido)
        {
            _Email = Email;
            _Pass = Pass;
            _Foto = Foto;
            _NombreUsuario = NombreUsuario;
            _Nombre = Nombre;
            _Apellido = Apellido;
        }


        public abstract string QueSoy();

        public Usuario Login(string correo, string pass)
        {           
            SqlConnection cn = ManejadorConexion.CrearConexion();
            SqlCommand cmd = new SqlCommand(@"EXEC sp_login", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@email", _Email));
            cmd.Parameters.Add(new SqlParameter("@pass", pass));
            cmd.Parameters.Add(new SqlParameter("@respuesta", SqlDbType.Bit) { Direction = ParameterDirection.Output });
            try
            {
                ManejadorConexion.AbrirConexion(cn);
                SqlTransaction trn = cn.BeginTransaction();
                cmd.Transaction = trn;
                bool resultado = Convert.ToBoolean(cmd.ExecuteScalar());
                if (resultado){

                }
                else
                {
                    throw new Exception("Login incorrecto, por favor intentelo nuevamente.");
                }
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
    }
}
