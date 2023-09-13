using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace Boletin.Entities
{
    public class Estudiante : Boletin
    {
        private string code;
        private string nombre;
        private string direccion;
        private byte edad;



        public Estudiante() : base()
        {
        }

        public Estudiante(List<float> quices, List<float> trabajos, List<float> parciales, string code, string nombre, string direccion, byte edad) : base(quices, trabajos, parciales)
        {
            this.Code = code;
            this.Nombre = nombre;
            this.Direccion = direccion;
            this.Edad = edad;
            this.Quices = quices;
            this.Trabajos = trabajos;
            this.Parciales = parciales;
        }

        public string Code { get => code; set => code = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public byte Edad { get => edad; set => edad = value; }
        public void InfoEstudiante(List<Estudiante> estudiantes)
        {
            Estudiante estudiante = new Estudiante();
            Console.Write("Codigo: ");
            estudiante.Code = Console.ReadLine();
            Console.Write("Nombre: ");
            estudiante.Nombre = Console.ReadLine();
            Console.Write("Direccion: ");
            estudiante.Direccion = Console.ReadLine();
            Console.Write("Edad: ");
            estudiante.Edad = Convert.ToByte(Console.ReadLine());
            estudiante.Quices = new List<float>();
            estudiante.Trabajos = new List<float>();
            estudiante.Parciales = new List<float>();
            estudiantes.Add(estudiante);
        }

        public void RegistroNota(List<Estudiante> estudiantes, int opcion)
        {
            Console.WriteLine("Ingrese el codigo del estudiante: ");
            string studenCode = Console.ReadLine();
            // Estudiante alumno =  new Estudiante();
            Estudiante alumno = estudiantes.FirstOrDefault(x => x.Code.Equals(studenCode));
            Console.WriteLine("Por favor ingrese la nota: ");
            switch (opcion)
            {
                case 1:
                    //Por favor me cuente la cantidad de Quices ✨, como el contador inicia en 0 le sumamos 1.
                    Console.WriteLine("Quiz Nro: {0}", (alumno.Quices.Count + 1));
                    alumno.Quices.Add(float.Parse(Console.ReadLine()));
                    break;
                case 2:
                    alumno.Trabajos.Add(float.Parse(Console.ReadLine()));
                    break;
                case 3:
                    alumno.Parciales.Add(float.Parse(Console.ReadLine()));
                    break;
                default:
                    Console.WriteLine("Opcion no valida");
                    Console.ReadKey();
                    break;
            }
            int idx = estudiantes.FindIndex(p => p.Code.Equals(studenCode));
            estudiantes[idx] = alumno;
        }
        public void RemoveItem(List<Estudiante> estudiantes)
        {
            Console.Clear();
            // Solicita al usuario que ingrese el código del estudiante a eliminar
            Console.WriteLine("Ingrese el código del estudiante a eliminar: ");
            string id = Console.ReadLine();

            // Busca el primer estudiante cuyo código coincide con el código ingresado
            Estudiante studenToRemove = estudiantes.FirstOrDefault(st => (st.Code ?? string.Empty).Equals(id)) ?? new Estudiante();

            // Verifica si se encontró un estudiante con el código ingresado
            if (studenToRemove != null)
            {
                // Si se encontró un estudiante, lo elimina de la lista de estudiantes
                estudiantes.Remove(studenToRemove);
                MisFunciones.SaveData(estudiantes);
            }
        }

        // public void RemoveItem(List<Estudiante> estudiantes)
        // {
        //     Console.WriteLine("Ingrese el código del estudiante a eliminar: ");
        //     string id = Console.ReadLine();

        //     // Validación de entrada: Comprueba si el código ingresado no está vacío
        //     if (string.IsNullOrWhiteSpace(id))
        //     {
        //         Console.WriteLine("Código ingresado no válido.");
        //         return;
        //     }

        //     // Busca al estudiante en la lista por código
        //     Estudiante studentToRemove = FindStudentById(estudiantes, id);

        //     if (studentToRemove != null)
        //     {
        //         estudiantes.Remove(studentToRemove);
        //         Console.WriteLine("Estudiante eliminado correctamente.");
        //     }
        //     else
        //     {
        //         Console.WriteLine("No se encontró ningún estudiante con el código ingresado.");
        //     }
        // }

        // // Función auxiliar para buscar estudiantes por código
        // private Estudiante FindStudentById(List<Estudiante> estudiantes, string id)
        // {
        //     return estudiantes.FirstOrDefault(student => (student.Code ?? string.Empty).Equals(id));
        // }


    }
}