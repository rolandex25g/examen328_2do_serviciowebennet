using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Npgsql;

namespace WebServiceProject
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }
        [WebMethod]
        public string obtenermaterias(String ci)
        {
            String res = "";
            NpgsqlConnection con;
            String cadena = "Server=localhost;Port=5432;User Id=postgres;Password=root;Database=academico;";
            try
            {
                con = new NpgsqlConnection(cadena);
                con.Open();
                String query = "select M.nombre_materia" +
                " from inscripcion as I, materia as M, alumno as A" +
                " where I.idAlumno=A.idAlumno and I.idMateria=M.idMateria and A.ci='" + ci + "'";
                NpgsqlCommand command = new NpgsqlCommand(query, con);

                NpgsqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    res = res + dr[0] + ",";
                }
                con.Close();
            }
            catch (Exception)
            {
                con = null;

            }
            return res;
        }
    }
}
