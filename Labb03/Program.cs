//Librerias del ADO .NET
using System.Data.SqlClient;
using System.Data;

using Labb03;

class Program
{
    // Cadena de conexión a la base de datos
    public static string connectionString = "Data Source=LAB1504-09\\SQLEXPRESS;User ID=usertecsup;Password=123456";


    static void Main()
    {
        List<Trabajador> trabajadores = ListarTrabajadoresListaObjetos();

        if (trabajadores != null && trabajadores.Count > 0)
        {
            Console.WriteLine("Lista de Trabajadores:");

            foreach (var trabajador in trabajadores)
            {
                Console.WriteLine(trabajador.ToString());
            }
        }
        else
        {
            Console.WriteLine("No se encontraron trabajadores");
        }

        Console.ReadLine();
    }

    //De forma desconectada
    private static DataTable ListarTrabajadoresDataTable()
    {
        // Crear un DataTable para almacenar los resultados
        DataTable dataTable = new DataTable();
        // Crear una conexión a la base de datos
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            // Abrir la conexión
            connection.Open();

            // Consulta SQL para seleccionar datos
            string query = "SELECT * FROM Trabajadores";

            // Crear un adaptador de datos
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);


            // Llenar el DataTable con los datos de la consulta
            adapter.Fill(dataTable);

            // Cerrar la conexión
            connection.Close();

        }
        return dataTable;
    }

    //De forma conectada
    private static List<Trabajador> ListarTrabajadoresListaObjetos()
    {
        List<Trabajador> trabajadores = new List<Trabajador>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            // Abrir la conexión
            connection.Open();

            // Consulta SQL para seleccionar datos
            string query = "SELECT IdTrabajador,Nombre,Apellido,Sueldo,Fecha_nac FROM Trabajadores";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Verificar si hay filas
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            // Leer los datos de cada fila

                            trabajadores.Add(new Trabajador
                            {
                                Id = (int)reader["IdTrabajador"],
                                Nombre = reader["Nombre"].ToString(),
                                Apellido = reader["Apellido"].ToString(),
                                Sueldo = (int)reader["Sueldo"],
                                Fecha_nac = (DateTime)reader["Fecha_nac"]                            
                            });
                        }
                    }
                }
            }

            // Cerrar la conexión
            connection.Close();


        }
        return trabajadores;

    }


}
