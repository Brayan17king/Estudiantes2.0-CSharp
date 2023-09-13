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
            Console.Write("Ingrese el Codigo del Estudiante: ");
            estudiante.Code = Console.ReadLine();
            Console.Write("Ingrese el Nombre del Estudiante: ");
            estudiante.Nombre = Console.ReadLine();
            Console.Write("Ingrese la Direccion del Estudiante: ");
            estudiante.Direccion = Console.ReadLine();
            Console.Write("Ingrese la Edad del Estudiante: ");
            estudiante.Edad = Convert.ToByte(Console.ReadLine());
            estudiante.Quices = new List<float>();
            estudiante.Trabajos = new List<float>();
            estudiante.Parciales = new List<float>();
            estudiantes.Add(estudiante);
        }

        public void RegistroNota(List<Estudiante> estudiantes, int opcion)
        {
            Console.Clear();
            Console.WriteLine("Ingrese el codigo del estudiante: ");
            string studenCode = Console.ReadLine();
            // Estudiante alumno =  new Estudiante();
            Estudiante alumno = estudiantes.FirstOrDefault(x => x.Code.Equals(studenCode));
            Console.WriteLine("Por favor ingrese las notas: ");
            switch (opcion)
            {
                case 1:
                    //Por favor me cuente la cantidad de Quices ✨, como el contador inicia en 0 le sumamos 1.
                    Console.Write("Quiz Nro{0}: ", (alumno.Quices.Count + 1));
                    alumno.Quices.Add(float.Parse(Console.ReadLine()));
                    break;
                case 2:
                    Console.Write("Trabajo Nro{0}: ", (alumno.Trabajos.Count + 1));
                    alumno.Trabajos.Add(float.Parse(Console.ReadLine()));
                    break;
                case 3:
                    Console.Write("Parcial Nro{0}: ", (alumno.Parciales.Count + 1));
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
            Console.WriteLine("Ingrese el código del estudiante a eliminar: ");
            string id = Console.ReadLine();

            // Validación de entrada: Comprueba si el código ingresado no está vacío
            if (string.IsNullOrWhiteSpace(id))
            {
                Console.WriteLine("Código ingresado no válido.");
                Console.ReadLine();
                return;
            }

            // Busca al estudiante en la lista por código
            Estudiante studentToRemove = FindStudentById(estudiantes, id);

            if (studentToRemove != null)
            {
                estudiantes.Remove(studentToRemove);
                MisFunciones.SaveData(estudiantes);
                Console.Write("Estudiante eliminado correctamente. Press Enter to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("No se encontró ningún estudiante con el código ingresado.");
                Console.ReadKey();
            }
        }

        // Función auxiliar para buscar estudiantes por código
        private Estudiante FindStudentById(List<Estudiante> estudiantes, string id)
        {
            return estudiantes.FirstOrDefault(student => (student.Code ?? string.Empty).Equals(id));
        }

        public void EditEstudent(List<Estudiante> estudiantes)
        {
            Console.Clear();
            Console.WriteLine("Ingrese el código del estudiante a editar: ");
            string id = Console.ReadLine();

            // Validación de entrada: Comprueba si el código ingresado no está vacío
            if (string.IsNullOrWhiteSpace(id))
            {
                Console.WriteLine("Código ingresado no válido.");
                Console.ReadLine();
                return;
            }

            // Busca al estudiante en la lista por código
            Estudiante studentToEdit = estudiantes.FirstOrDefault(x => x.Code.Equals(id));

            if (studentToEdit != null)
            {
                Console.Clear();
                Console.Write("Ingrese el nuevo Código del Estudiante: ");
                studentToEdit.Code = Console.ReadLine();
                Console.Write("Ingrese el nuevo Nombre del Estudiante: ");
                studentToEdit.Nombre = Console.ReadLine();
                Console.Write("Ingrese la nueva Dirección del Estudiante: ");
                studentToEdit.Direccion = Console.ReadLine();
                Console.Write("Ingrese la nueva edad del Estudiante: ");
                byte nuevaEdad;
                if (byte.TryParse(Console.ReadLine(), out nuevaEdad))
                {
                    studentToEdit.Edad = nuevaEdad;
                }
                else
                {
                    Console.WriteLine("Edad ingresada no válida. No se realizaron cambios en la edad.");
                }

                MisFunciones.SaveData(estudiantes);

                Console.WriteLine("Estudiante editado correctamente. Presione Enter para continuar...");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("No se encontró ningún estudiante con el código ingresado.");
                Console.ReadLine();
            }
        }
    }
}