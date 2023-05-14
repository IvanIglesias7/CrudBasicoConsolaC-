using CrudBasicoConsola.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudBasicoConsola.Consultas
{
    public class Consultas
    {
        public void MostrarTodo(ColegioBasicoContext context)
        {
            var alumnos = context.Alumnos.ToList();
            var profesores = context.Profesores.ToList();

            Console.WriteLine("Lista de Alumnos:");
            Console.WriteLine("------------------");

            foreach (var alumno in alumnos)
            {
                Console.WriteLine($"{alumno.Id} - {alumno.Nombre} {alumno.Apellidos}");
            }

            Console.WriteLine("\nLista de Profesores:");
            Console.WriteLine("------------------");
            foreach (var profesor in profesores)
            {
                Console.WriteLine("{0} - {1} {2}", profesor.Id, profesor.Nombre, profesor.Apellidos);
            }
        }

        public void InsertarAlumno(ColegioBasicoContext context, string nombre, string apellidos)
        {
            Alumno a = new Alumno();
            a.Nombre = nombre;
            a.Apellidos = apellidos;

            context.Alumnos.Add(a);
            context.SaveChanges();


            //Limpio pantalla y muestro la lista completa de alumnos y profesores con el nuevo alumno añadido
            Console.Clear();
            Console.WriteLine("Alumno añadido", a.ToString());
            MostrarTodo(context);

        }

        public void InsertarProfesor(ColegioBasicoContext context, string nombre, string apellidos)
        {
            Profesore p = new Profesore();
            p.Nombre = nombre;
            p.Apellidos = apellidos;

            context.Profesores.Add(p);
            context.SaveChanges();

            //Limpio pantalla y muestro la lista completa de alumnos y profesores con el nuevo profesor añadido
            Console.Clear();
            Console.WriteLine("Profesor añadido", p);
            MostrarTodo(context);

        }

        public void EliminarAlumno(ColegioBasicoContext context)
        {

            Console.Write("Qué alumno quiere eliminar? - ");
            int num = Convert.ToInt32(Console.ReadLine());

            var a = context.Alumnos.Find(num);

            Console.WriteLine("Alumno con el id {0} eliminado: {1} {2}", a.Id, a.Nombre, a.Apellidos);
            context.Remove(a); 
            context.SaveChanges();
           
        }

        public void EliminarProfesor(ColegioBasicoContext context)
        {
            Console.Write("Qué profesor quiere eliminar? - ");
            int num = Convert.ToInt32(Console.ReadLine());

            var p = context.Profesores.Find(num);

            Console.WriteLine("Profesor con el id {0} eliminado: {1} {2}", p.Id, p.Nombre, p.Apellidos);
            context.Remove(p);
            context.SaveChanges();
        }

        public void ModificarAlumno(ColegioBasicoContext context)
        {
            bool repetir = false;

            Console.WriteLine("Qué alumno quieres modificar? - ");

            int alumno = Convert.ToInt32(Console.ReadLine());

            var a = context.Alumnos.Find(alumno);
            do
            {
                Console.WriteLine("Qué propiedad?" +
                "Nombre - 1 | Apellidos - 2");
                int propiedad = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Qué valor deseas ponerle?");
                string valorNuevo = Console.ReadLine();

                
                if (propiedad == 1)
                {
                    a.Nombre = valorNuevo;
                }
                if (propiedad == 2)
                {
                    a.Apellidos = valorNuevo;
                }
                else
                {
                    Console.WriteLine("Se ha equivocado.");
                    repetir = true;
                }
                    

            } while (repetir == true);

            context.Entry(a).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            Console.WriteLine("Alumno con Id nº {0} modificado exitosamente", a.Id);
                
        }


    }
}
