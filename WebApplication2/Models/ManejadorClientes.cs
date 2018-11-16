using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class ManejadorClientes
    {
        internal static Cliente Login(string correo, string pass)
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
                RequestStatus = (bool) cmd.Parameters["@respuesta"].Value;

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

        internal static List<Cliente> GetAll()
        {
            List<Cliente> lisCli = new List<Cliente>();
            SqlConnection cn = ManejadorConexion.CrearConexion();
            SqlCommand cmd = new SqlCommand(@"SELECT * FROM Usuarios", cn);
            try
            {
                ManejadorConexion.AbrirConexion(cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    IDataRecord fila = dr;
                    if (fila != null)
                    {
                        Cliente cli = new Cliente();
                            cli._Id = fila.IsDBNull(fila.GetOrdinal("id")) ? 0 : fila.GetInt32(fila.GetOrdinal("id"));
                            cli._Email = fila.IsDBNull(fila.GetOrdinal("email")) ? "" : fila.GetString(fila.GetOrdinal("email"));// dr["nombre"].ToString();
                            cli._Nombre = fila.IsDBNull(fila.GetOrdinal("nombre")) ? "" : fila.GetString(fila.GetOrdinal("nombre"));// dr["nombre"].ToString();
                            cli._Apellido = fila.IsDBNull(fila.GetOrdinal("apellido")) ? "" : fila.GetString(fila.GetOrdinal("apellido"));// dr["apellido"].ToString();
                            cli._NombreUsuario = fila.IsDBNull(fila.GetOrdinal("nombreUsuario")) ? "" : fila.GetString(fila.GetOrdinal("nombreUsuario")); // dr["nombreUsuario"].ToString();
                            cli._Foto = fila.IsDBNull(fila.GetOrdinal("foto")) ? null : (byte[])fila.GetValue(fila.GetOrdinal("foto")); // (byte[])dr["foto"]; (byte [])obj.GetValue(0)                            
                            lisCli.Add(cli);
                    }
                }
                return lisCli;
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

        internal static bool Registrar(Cliente cli)
        {
            //if (!this.Validar()) return false;

            SqlConnection cn = ManejadorConexion.CrearConexion();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"INSERT INTO Usuarios (email, pass, nombreUsuario, tipo) VALUES (@email, @pass, @nombreUsuario, @tipo)";
            cmd.Parameters.AddWithValue("@email", cli._Email);
            cmd.Parameters.AddWithValue("@pass", cli._Pass);
            cmd.Parameters.AddWithValue("@nombreUsuario", cli._NombreUsuario);
            cmd.Parameters.AddWithValue("@tipo", 2);
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

        public static bool ActualizarPerfil(Cliente cli)
        {
            SqlConnection cn = ManejadorConexion.CrearConexion();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"UPDATE Usuarios 
                                SET nombre = @nombre, apellido = @apellido, nombreUsuario = @nomUsu, foto = @foto
                                WHERE email = @email
                                AND tipo = @tipo";
            cmd.Parameters.AddWithValue("@email", cli._Email);
            cmd.Parameters.AddWithValue("@nombre", cli._Nombre);
            cmd.Parameters.AddWithValue("@apellido", cli._Apellido);
            cmd.Parameters.AddWithValue("@nomUsu", cli._NombreUsuario);
            cmd.Parameters.AddWithValue("@foto", null);
            //cmd.Parameters.AddWithValue("@foto", cli._Foto);
            cmd.Parameters.AddWithValue("@tipo", 2);
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
    }
}