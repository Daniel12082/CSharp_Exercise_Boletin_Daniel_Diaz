using Boletin.Entities;
using Newtonsoft.Json;

namespace Boletin;

public class MisFunciones
{
    public static byte MenuNotas()
    {
        Console.WriteLine("1. Registro quices");
        Console.WriteLine("2. Registro trabajos");
        Console.WriteLine("3. Registro parciales");
        Console.WriteLine("0. Regresar al menu principal");
        Console.Write("Opcion: ");
        return Convert.ToByte(Console.ReadLine());
    }
    public static byte MenuEditNotas(){
        Console.WriteLine("1. Editar Notas");
        Console.WriteLine("2. Eliminar Notas");
        Console.WriteLine("0. Regresar al menu principal");
        Console.Write("Opcion: ");
        return Convert.ToByte(Console.ReadLine());
    }
    public static byte Reportes()
    {
        Console.WriteLine("1. Notas del grupo");
        Console.WriteLine("2. Notas Finales");
        Console.WriteLine("0. Regresar al menu principal");
        Console.Write("Opcion: ");
        return Convert.ToByte(Console.ReadLine());
    }
    public static void SaveData(List<Estudiante> lstListado)
    {
        string json = JsonConvert.SerializeObject(lstListado, Formatting.Indented);
        File.WriteAllText("boletin.json", json);
    }
    public static List<Estudiante> LoadData()
    {
        using (StreamReader reader = new StreamReader("boletin.json"))
        {
            string json = reader.ReadToEnd();
            return System.Text.Json.JsonSerializer
            .Deserialize<List<Estudiante>>(json, new System.Text.Json.JsonSerializerOptions()
            { PropertyNameCaseInsensitive = true }) ?? new List<Estudiante>();
        }
    }
    public static void ImprimirNotas(List<Estudiante> estudiantes)
    {
        int estudiantesPorPagina = 10;
        int paginaActual = 0;
        while (paginaActual * estudiantesPorPagina < estudiantes.Count)
        {
            Console.Clear();
            Console.WriteLine("Página {0}", paginaActual + 1);
            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("| {0,-20} | {1,-40} | {2,-29} | {3,-13} | {4,-21} |", "Cod.Estudiante", "Nombre Estudiante", "Quizzes", "Trabajos", "Parciales");
            Console.WriteLine("| {0,-20} | {1,-40} | {2,-5} | {3,-5} | {4,-5} | {5,-5} | {6,-5} | {7,-5} | {8,-5} | {9,-5} | {10,-5} |", "", "", "Q1", "Q2", "Q3", "Q4", "T1", "T2", "P1", "P2", "P3");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------");
            
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Presione Enter para avanzar a la siguiente página o cualquier otra tecla para salir...");
            if (Console.ReadKey().Key != ConsoleKey.Enter)
            {
                break; // Salir si el usuario no presiona "Enter" para avanzar.
            }
            paginaActual++;
        }
    }
    public static void ImprimirNotasFinales(List<Estudiante> listEstudiantes){
        Console.Clear();
    }
}
