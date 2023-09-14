using Boletin;
using Boletin.Entities;

internal class Program
{
    private static void Main(string[] args)
    {
        List<Estudiante> estudiantes = new List<Estudiante>();
        Estudiante student = new Estudiante();
        bool cicloMenu = true;
        estudiantes = MisFunciones.LoadData();
        while (cicloMenu)
        {
            try
            {
            Console.Clear();
            Console.WriteLine("1. Registro de estudiantes");
            Console.WriteLine("2. Registro de notas");
            Console.WriteLine("3. Reportes e informes");
            Console.WriteLine("4. Buscar Alumno");
            Console.WriteLine("5. Eliminar Alumno");
            Console.WriteLine("6. Modificar Notas");
            Console.WriteLine("0. Salir");
            Console.Write("Opcion: ");
            byte opcionMenu = Convert.ToByte(Console.ReadLine());
            switch (opcionMenu)
            {
                case 1:
                    student.InfoEstudiante(estudiantes);
                    MisFunciones.SaveData(estudiantes);
                    break;
                case 2:
                    bool cicloNotas = true;
                    while (cicloNotas)
                    {
                        Console.Clear();
                        byte opcionNotas = MisFunciones.MenuNotas();
                        if (opcionNotas != 0)
                        {
                            student.RegistroNota(estudiantes, opcionNotas);
                            MisFunciones.SaveData(estudiantes);
                        }
                        else
                        {
                            cicloNotas = false;
                        }
                    }
                    break;
                case 3:
                    bool cicloReportes = true;
                    while (cicloReportes)
                    {
                        Console.Clear();
                        byte opcionRegistro = MisFunciones.Reportes();
                        switch (opcionRegistro)
                        {
                            case 1:
                                Console.Clear();
                                MisFunciones.ImprimirNotas();
                                break;
                            case 2:
                                Console.Clear();
                                MisFunciones.ImprimirNotasFinales(estudiantes);
                                break;
                            case 0:
                                Console.Clear();
                                cicloReportes = false;
                                break;
                            default:
                                Console.WriteLine("Opcion invalida");
                                Console.Write("Presione Enter para volver a ingresar: ");
                                Console.ReadKey();
                                break;
                        }
                    }
                    break;
                case 4:
                    bool cicloBuscar = true;
                    while (cicloBuscar)
                    {
                        Console.Clear();
                        byte opcionBuscar = MisFunciones.Find();
                        switch (opcionBuscar)
                        {
                            case 1:
                                Console.Clear();
                                student.FindByCode(estudiantes);
                                break;
                            case 2:
                                Console.Clear();
                                student.FindByName(estudiantes);
                                break;
                            case 3:
                                Console.Clear();
                                student.FindByAge(estudiantes);
                                break;
                            case 4:
                                Console.Clear();
                                student.FindByAddres(estudiantes);
                                Console.ReadKey();
                                break;
                            case 0:
                                Console.Clear();
                                cicloBuscar = false;
                                break;
                            default:
                                Console.WriteLine("Opcion invalida");
                                Console.Write("Presione Enter para volver a ingresar: ");
                                Console.ReadKey();
                                break;
                        }
                    }
                    break;
                case 5:
                    student.RemoveItem(estudiantes);
                    break;
                case 6:
                    byte opcionEdit = MisFunciones.MenuEditNotas();
                    switch(opcionEdit){
                        case 1:
                            student.EditGrades(estudiantes);
                            break;
                        case 2:
                            student.RemoveGrade(estudiantes);
                            break;
                    }
                    break;
                case 0:
                    cicloMenu = false;
                    break;
                default:
                    Console.WriteLine("Opcion invalida");
                    Console.Write("Presione Enter para volver a ingresar: ");
                    Console.ReadKey();
                    break;
            }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                Console.Write("Presione Enter para volver a ingresar: ");
                Console.ReadKey();
            }
        }
    }
}