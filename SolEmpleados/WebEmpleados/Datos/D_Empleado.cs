using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.WebSockets;
using WebEmpleados.Models;

namespace WebEmpleados.Datos
{
    public class D_Empleado
    {
        //Obteniendo cadena de conexion desde el webconfig
        protected string CadenaConexion = ConfigurationManager.ConnectionStrings["sql"].ConnectionString;
        public void AbrirConexion()
        {

            SqlConnection conexion = new SqlConnection(CadenaConexion);

            try
            {
                conexion.Open();
            }
            catch (Exception ex)
            {

                throw ex; //Lanzamos la excepcion
            }
            finally //Este bloque se ejecuta siempre, haya error o no.
            {
                conexion.Close();
            }
        }

        public void Agregar(E_Empleado empleado)
        {
            SqlConnection conexion = new SqlConnection(CadenaConexion);
            try
            {
                conexion.Open();
                string query = "INSERT INTO	Empleados(nombre, numeroEmpleado,sueldo, fechaNacimiento, tiempoCompleto) " +
                "VALUES (@Nombre, @NumeroEmpleado, @Sueldo, @FechaNacimiento, @TiempoCompleto)";

                SqlCommand comando = new SqlCommand(query, conexion);

                comando.Parameters.AddWithValue("@Nombre", empleado.Nombre);
                comando.Parameters.AddWithValue("@NumeroEmpleado", empleado.NumeroEmpleado);
                comando.Parameters.AddWithValue("@Sueldo", empleado.Sueldo);
                comando.Parameters.AddWithValue("@FechaNacimiento", empleado.FechaNacimiento);
                comando.Parameters.AddWithValue("@TiempoCompleto", empleado.TiempoCompleto);

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }

        public List<E_Empleado> ObtenerTodos()
        {
            SqlConnection conexion = new SqlConnection(CadenaConexion);
            //Declarando la lista de Empleados vacia.
            List<E_Empleado> lista = new List<E_Empleado>();
            try
            {
                conexion.Open();

                string query = "select idEmpleado, nombre, numeroEmpleado, sueldo, fechaNacimiento, tiempoCompleto from Empleados";
                SqlCommand comando = new SqlCommand(query, conexion);
                //Objeto SqlDataReader para leer el conjunto de resultados que devuelve el SELECT
                SqlDataReader reader = comando.ExecuteReader();
                //Recorremos el conjunto de resultados para llenar la lista

                while (reader.Read())
                {
                    //Creando un objeto de la clase empleado
                    E_Empleado obj = new E_Empleado();
                    //Asignamos sus propiedades 
                    obj.IdEmpleado = Convert.ToInt32(reader["idEmpleado"]);//Convierte el tipo object a int
                    obj.Nombre = reader["nombre"].ToString();//Convierte el tipo object a string 
                    obj.NumeroEmpleado = reader["numeroEmpleado"].ToString();//Convierte el tipo object a string 
                    obj.Sueldo = Convert.ToDecimal(reader["sueldo"]);//Convierte el tipo object a decimal 
                    obj.FechaNacimiento = Convert.ToDateTime(reader["fechaNacimiento"]);//Convierte el tipo object a DateTime 
                    obj.TiempoCompleto = Convert.ToBoolean(reader["tiempoCompleto"]);//Convierte el tipo object a string 

                    //Agregando el objeto a la lista
                    lista.Add(obj);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return lista;
        }

        public bool ExisteNumeroEmpleado(string numeroEmpleado)
        {
            SqlConnection conexion = new SqlConnection(CadenaConexion);
            try
            {
                conexion.Open();
                string query = "select numeroEmpleado FROM Empleados WHERE numeroEmpleado = @numeroEmpleado";

                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@numeroEmpleado", numeroEmpleado);

                SqlDataReader reader = comando.ExecuteReader();
                /*if (reader.HasRows == true)
                    return true;
                else
                    return false;*/
                return reader.HasRows;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }
        public void Eliminar (int idEmpleado)
        {
            SqlConnection conexion = new SqlConnection(CadenaConexion);
            try
            {
                conexion.Open();
                string query = "DELETE FROM Empleados WHERE idEmpleado = @idEmpleado";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@idEmpleado", idEmpleado);
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public E_Empleado obtenerEmpleadoPorId(int idEmpleado) 
        {
            SqlConnection conexion = new SqlConnection(CadenaConexion);
            //Creando un objeto de la clase empleado
            E_Empleado obj = new E_Empleado();
            try
            {
                conexion.Open();
                string query = "SELECT idEmpleado, nombre, numeroEmpleado, sueldo, fechaNacimiento, tiempoCompleto " +
                    "FROM Empleados WHERE idEmpleado= @idEmpleado";

                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@idEmpleado", idEmpleado);

                SqlDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    
                        //Asignamos sus propiedades 
                        obj.IdEmpleado = Convert.ToInt32(reader["idEmpleado"]);//Convierte el tipo object a int
                        obj.Nombre = reader["nombre"].ToString();//Convierte el tipo object a string 
                        obj.NumeroEmpleado = reader["numeroEmpleado"].ToString();//Convierte el tipo object a string 
                        obj.Sueldo = Convert.ToDecimal(reader["sueldo"]);//Convierte el tipo object a decimal 
                        obj.FechaNacimiento = Convert.ToDateTime(reader["fechaNacimiento"]);//Convierte el tipo object a DateTime 
                        obj.TiempoCompleto = Convert.ToBoolean(reader["tiempoCompleto"]);//Convierte el tipo object a string 

                }
                return obj;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }

        public void Editar(E_Empleado empleado)
        {
            SqlConnection conexion = new SqlConnection(CadenaConexion);
            try
            {
                conexion.Open();
                string query = "UPDATE Empleados SET nombre = @nombre, numeroEmpleado=@numeroEmpleado,  " +
                    "sueldo = @sueldo, fechaNacimiento= @fechaNacimiento, tiempoCompleto= @tiempoCompleto "+
                    "WHERE idEmpleado=@idEmpleado";

                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@nombre", empleado.Nombre);
                comando.Parameters.AddWithValue("@numeroEmpleado", empleado.NumeroEmpleado);
                comando.Parameters.AddWithValue("@sueldo", empleado.Sueldo);
                comando.Parameters.AddWithValue("@fechaNacimiento", empleado.FechaNacimiento);
                comando.Parameters.AddWithValue("@tiempoCompleto", empleado.TiempoCompleto);
                comando.Parameters.AddWithValue("@idEmpleado", empleado.IdEmpleado);

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }

        public  List<E_Empleado> Buscar(string texto)
        {
            SqlConnection conexion = new SqlConnection(CadenaConexion);
            List<E_Empleado> lista = new List<E_Empleado>();
            try
            {
                conexion.Open();
                //Para un stored Procedure tenemos que pasar el NOMBRE del procedure y la conexion
                SqlCommand comando = new SqlCommand("buscarEmpleados", conexion);
                //Indicador que es un stored procedure
                comando.CommandType = CommandType.StoredProcedure;
                //Si el stored procedure necesita parametros, hay agregarlos
                comando.Parameters.AddWithValue("@texto", texto);

                //Objeto SQLDataReader para leer el conjunto de resultados que devuelve el SELECT
                SqlDataReader reader = comando.ExecuteReader();
                //Recorremos el conjunto de resultados par llenar la lista
                while (reader.Read())
                {
                    //Creando un objeto de la clase empleado
                    E_Empleado obj = new E_Empleado();
                    //Asignamos sus propiedades 
                    obj.IdEmpleado = Convert.ToInt32(reader["idEmpleado"]);//Convierte el tipo object a int
                    obj.Nombre = reader["nombre"].ToString();//Convierte el tipo object a string 
                    obj.NumeroEmpleado = reader["numeroEmpleado"].ToString();//Convierte el tipo object a string 
                    obj.Sueldo = Convert.ToDecimal(reader["sueldo"]);//Convierte el tipo object a decimal 
                    obj.FechaNacimiento = Convert.ToDateTime(reader["fechaNacimiento"]);//Convierte el tipo object a DateTime 
                    obj.TiempoCompleto = Convert.ToBoolean(reader["tiempoCompleto"]);//Convierte el tipo object a string 

                    //Agregando el objeto a la lista
                    lista.Add(obj);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally {
                conexion.Close();
            }
         }
    }
}