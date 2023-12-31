using Boletin.Entities;
using Newtonsoft.Json;

namespace Boletin;

public class MisFunciones
{
    public static byte MenuNotas()
    {
        Console.WriteLine("---MENU REGISTRO DE NOTAS---\n");
        Console.WriteLine("1. Registro quices");
        Console.WriteLine("2. Registro trabajos");
        Console.WriteLine("3. Registro parciales");
        Console.WriteLine("\n0. Regresar al menu principal");
        Console.Write("\nIngrese una opcion: ");
        return Convert.ToByte(Console.ReadLine());
    }
    public static byte Reportes()
    {
        Console.WriteLine("--------MENU REPORTES--------\n");
        Console.WriteLine("1. Notas del grupo");
        Console.WriteLine("2. Notas Finales");
        Console.WriteLine("\n0. Regresar al menu principal");
        Console.Write("\nIngrese una opcion: ");
        return Convert.ToByte(Console.ReadLine());
    }

    // !la serialización consiste en convertir la informacion en Json y viseversa.
    /*Esta funcion esta diseñada para guardar una lista de objetos en formato Json.
        public: significa que es accesible desde cualquier parte del codigo.
        static: significa que se puede llamar sin necesidad de crear una instancia de la clase que la contiene.
        void: Esto significa que la función no devuelve ningún valor.
    */
    public static void SaveData(List<Estudiante> lstListado)
    {
        // Convierte la lista de objetos en un archivo Json y el Formatting sirve para que sea mas lejible.
        string json = JsonConvert.SerializeObject(lstListado, Formatting.Indented);
        //toma la cadena JSON generada en el paso anterior y la escribe en un archivo llamado "boletin.json" mediante WriteAllText.
        File.WriteAllText("boletin.json", json);
    }

    public static List<Estudiante> LoadData()
    {
        // Abre el archivo "boletin.json" para leerlo
        using (StreamReader reader = new StreamReader("boletin.json"))
        {
            // Lee todo el contenido del archivo y lo almacena en una cadena llamada "json"
            string json = reader.ReadToEnd();

            // Deserializa la cadena JSON en una lista de objetos "Estudiante"
            // La opción PropertyNameCaseInsensitive permite que las propiedades coincidan
            // sin importar las mayúsculas y minúsculas en los nombres
            List<Estudiante> deserializedList = System.Text.Json.JsonSerializer.Deserialize<List<Estudiante>>(json, new System.Text.Json.JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            }) ?? new List<Estudiante>();

            // Devuelve la lista deserializada como el resultado de la función
            return deserializedList;
        }
    }

}
