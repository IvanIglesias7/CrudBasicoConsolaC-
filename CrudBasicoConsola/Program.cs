// See https://aka.ms/new-console-template for more information
using CrudBasicoConsola.Consultas;
using CrudBasicoConsola.Modelo;

internal class Program
{
    private static void Main(string[] args)
    {
        Consultas c = new Consultas();
        var context = new ColegioBasicoContext();

        //Muestro a los profesores y alumnos
        c.MostrarTodo(context);

        //Inserto alumno
        //c.InsertarAlumno(context, "Manuel", "Ramirez");

        //Inserto profesor
        //c.InsertarProfesor(context, "Gerardo", "Sanchez");

        //Elimina un alumno
        //c.EliminarAlumno(context);

        //Elimina un profesor
        //c.EliminarProfesor(context);

        //Modifica un alumno
        //c.ModificarAlumno(context);

        Console.ReadLine();
    }
}