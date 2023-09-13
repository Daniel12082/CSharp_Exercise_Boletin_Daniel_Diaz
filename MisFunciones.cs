using System.Security.Cryptography.X509Certificates;
using Boletin.Entities;
using Newtonsoft.Json;

namespace Boletin;

public class MisFunciones
{
    public static byte MenuNotas()
    {
        Console.Clear();
        Console.WriteLine("REGISTRO DE NOTAS");
        Console.WriteLine("1. Registro quices");
        Console.WriteLine("2. Registro trabajos");
        Console.WriteLine("3. Registro parciales");
        Console.WriteLine("0. Regresar al menu principal");
        Console.Write("Opcion: ");
        return Convert.ToByte(Console.ReadLine());
    }
    public static byte MenuEditNotas(){
        Console.Clear();
        Console.WriteLine("EDITAR NOTAS");
        Console.WriteLine("1. Editar Notas");
        Console.WriteLine("2. Eliminar Notas");
        Console.WriteLine("0. Regresar al menu principal");
        Console.Write("Opcion: ");
        return Convert.ToByte(Console.ReadLine());
    }
    public static byte Reportes()
    {
        Console.Clear();
        Console.WriteLine("REPORTES E INFORMES");
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
        string archivoJson = "boletin.json";

        if (File.Exists(archivoJson))
        {
            string json = File.ReadAllText(archivoJson);
            return JsonConvert.DeserializeObject<List<Estudiante>>(json) ?? new List<Estudiante>();
        }
        else
        {
            return new List<Estudiante>();
        }
    }
    public static void ImprimirNotas()
    {
        int estudiantesPorPagina = 10;
        int paginaActual = 0;
        List<Estudiante> estudiantes = LoadData();
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
            var estudiantesPagina = estudiantes
            .Skip(paginaActual * estudiantesPorPagina)
            .Take(estudiantesPorPagina);
            foreach (var estudiante in estudiantesPagina)
            {
                Console.WriteLine("| {0,-20} | {1,-40} | {2,-5} | {3,-5} | {4,-5} | {5,-5} | {6,-5} | {7,-5} | {8,-5} | {9,-5} | {10,-5} |", estudiante.Code, estudiante.Nombre, estudiante.Quices[0], estudiante.Quices[1], estudiante.Quices[2], estudiante.Quices[3], estudiante.Trabajos[0], estudiante.Trabajos[1], estudiante.Parciales[0], estudiante.Parciales[1], estudiante.Parciales[2]);
                Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------");
            }
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
