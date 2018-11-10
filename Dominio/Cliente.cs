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

        public override string QueSoy() {
            return "Cliente";
        }
        public override object Login(string correo, string pass)
        {
            Cliente cli = new Cliente();
            int RequestStatus = -1;

            SqlConnection cn = ManejadorConexion.CrearConexion();
            SqlCommand cmd = new SqlCommand("sp_login", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@email", correo));
            cmd.Parameters.Add(new SqlParameter("@pass", pass));
            //cmd.Parameters.Add(new SqlParameter("@respuesta", SqlDbType.Bit) { Direction = ParameterDirection.Output });

            //SqlParameter ReturnValue = new SqlParameter("@respuesta", SqlDbType.Bit);
            //ReturnValue.Direction = ParameterDirection.Output;
            //cmd.Parameters.Add(ReturnValue);

            cmd.Parameters.Add(new SqlParameter("@respuesta", SqlDbType.Bit) { Direction = ParameterDirection.ReturnValue });

            try
            {
                ManejadorConexion.AbrirConexion(cn);
                cmd.ExecuteNonQuery();
                RequestStatus = (int)cmd.Parameters["@respuesta"].Value;

                //int retorno = (int)cmd.ExecuteScalar();

                //bool resultado = Convert.ToBoolean(retorno);

                if (RequestStatus.Equals(1))
                {
                    SqlCommand cmd2 = new SqlCommand(@"SELECT * FROM Usuario WHERE email = @email", cn);
                    cmd2.Parameters.Add(new SqlParameter("@email", correo));
                    SqlDataReader dr = cmd2.ExecuteReader();

                    cli._Id = Convert.ToInt32(dr["id"]);
                    cli._Email = correo;
                    cli._Nombre = dr["nombre"].ToString();
                    cli._Apellido = dr["apellido"].ToString();
                    cli._NombreUsuario = dr["nombreUsuario"].ToString();
                    cli._Foto = (byte[]) dr["foto"];

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
