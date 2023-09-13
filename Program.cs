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
            Console.Clear();
            Console.WriteLine("----------CAMPUSLAND----------\n");
            Console.WriteLine("1. Registro de estudiantes");
            Console.WriteLine("2. Registro de notas");
            Console.WriteLine("3. Reportes e informes");
            Console.WriteLine("4. ELiminar estudiantes");
            Console.WriteLine("5. Editar estudiantes");
            Console.WriteLine("\n0. Salir");
            Console.Write("\nIngrese una opcion: ");
            byte opcionMenu = Convert.ToByte(Console.ReadLine());
            switch (opcionMenu)
            {
                case 1:
                    Console.Clear();
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
                                Console.WriteLine("\n{0,17} {1,-40} {2,6} {3,6} {4,6} {5,6} {6,6} {7,6} {8,6} {9,6} {10,6}", "Codigo Estudiante", "Nombre", "Q1", "Q2", "Q3", "Q4", "T1", "T2", "P1", "P2", "P3");
                                for (int i = 0; i < estudiantes.Count; i++)
                                {
                                    Console.WriteLine("{0,-17} {1,-40} {2,6} {3,6} {4,6} {5,6} {6,6} {7,6} {8,6} {9,6} {10,6}", estudiantes[i].Code, estudiantes[i].Nombre, estudiantes[i].Quices[0], estudiantes[i].Quices[1], estudiantes[i].Quices[2], estudiantes[i].Quices[3], estudiantes[i].Trabajos[0], estudiantes[i].Trabajos[1], estudiantes[i].Parciales[0],estudiantes[i].Parciales[1],estudiantes[i].Parciales[2]);
                                }
                                Console.Write("\nPresione cualquier tecla para continuar...🌟");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case 2:
                                Console.Clear();
                                break;
                            case 0:
                                Console.Clear();
                                cicloReportes = false;
                                break;
                            default:
                                Console.Clear();
                                Console.WriteLine("Opcion invalida");
                                Console.Write("Presione Enter para volver a ingresar: ");
                                Console.ReadKey();
                                break;
                        }
                    }
                    break;
                case 4:
                    student.RemoveItem(estudiantes);
                break;
                case 5:
                    student.EditEstudent(estudiantes);
                break;
                case 0:
                    cicloMenu = false;
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Opcion invalida");
                    Console.Write("Presione Enter para volver a ingresar: ");
                    Console.ReadKey();
                    break;
            }

        }


    }
}