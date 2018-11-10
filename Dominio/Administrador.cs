using Dominio.BD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;

namespace Dominio
{
    public class Administrador : Usuario
    {
        public Administrador() { }

        public Administrador(int Id, string Email, byte[] Foto, string NombreUsuario, string Nombre, string Apellido) : 
            base(Id, Email, Foto, NombreUsuario, Nombre, Apellido)
        {
        }

        public Administrador(string Email, string Pass, byte[] Foto, string NombreUsuario, string Nombre, string Apellido) : 
            base(Email, Pass, Foto, NombreUsuario, Nombre, Apellido)
        {
        }

        public override string QueSoy()
        {
            return "Administrador";
        }

        public override object Login(string correo, string pass)
        {
            Administrador admin = new Administrador();

            SqlConnection cn = ManejadorConexion.CrearConexion();
            SqlCommand cmd = new SqlCommand(@"EXEC sp_login", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@email", correo));
            cmd.Parameters.Add(new SqlParameter("@pass", pass));
            cmd.Parameters.Add(new SqlParameter("@respuesta", SqlDbType.Bit) { Direction = ParameterDirection.Output });

            try
            {
                ManejadorConexion.AbrirConexion(cn);
                bool resultado = Convert.ToBoolean(cmd.ExecuteScalar());

                if (resultado)
                {
                    SqlCommand cmd2 = new SqlCommand(@"SELECT * FROM Usuario WHERE email = @email", cn);
                    cmd2.Parameters.Add(new SqlParameter("@email", correo));
                    SqlDataReader dr = cmd2.ExecuteReader();

                    admin._Id = Convert.ToInt32(dr["id"]);
                    admin._Email = correo;
                    admin._Nombre = dr["nombre"].ToString();
                    admin._Apellido = dr["apellido"].ToString();
                    admin._NombreUsuario = dr["nombreUsuario"].ToString();
                    admin._Foto = null;

                    return admin;
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

    }
}
