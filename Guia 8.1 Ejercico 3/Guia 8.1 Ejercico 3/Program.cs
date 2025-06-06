using System;
public class Servicio
{
    public string Nombre0, Nombre1, Nombre2;
    public int NumeroLibreta0, NumeroLibreta1, NumeroLibreta2;
    public int Orden;

    public void RegistrarNombreYNumeroLibreta(string nombre, int numeroLibreta, int orden)
    {
        switch (orden)
        {
            case 0:
                Nombre0 = nombre;
                NumeroLibreta0 = numeroLibreta;
                break;
            case 1:
                Nombre1 = nombre;
                NumeroLibreta1 = numeroLibreta;
                break;
            case 2:
                Nombre2 = nombre;
                NumeroLibreta2 = numeroLibreta;
                break;
        }
    }
}


class Program
{
    static Servicio servicio = new Servicio();

    static void MostrarPantallaSolicitarOpcionMenu()
    {
        Console.WriteLine("1. Ingresar alumnos");
        Console.WriteLine("2. Mostrar lista ordenada por número de libreta");
        Console.WriteLine("3. Salir");
        Console.Write("Seleccione una opción: ");
    }

    static void MostrarPantallaSolicitarAlumnos()
    {
        for (int i = 0; i < 3; i++)
        {
            Console.Write($"Ingrese nombre del alumno {i + 1}: ");
            string nombre = Console.ReadLine();

            Console.Write($"Ingrese número de libreta del alumno {i + 1}: ");
            int numeroLibreta = int.Parse(Console.ReadLine());

            servicio.RegistrarNombreYNumeroLibreta(nombre, numeroLibreta, i);
        }
    }

    static void MostrarPantallaMostrarListaOrdenada()
    {
        string[] nombres = { servicio.Nombre0, servicio.Nombre1, servicio.Nombre2 };
        int[] numeros = { servicio.NumeroLibreta0, servicio.NumeroLibreta1, servicio.NumeroLibreta2 };

        // Ordenar por número de libreta (burbuja simple)
        for (int i = 0; i < numeros.Length - 1; i++)
        {
            for (int j = i + 1; j < numeros.Length; j++)
            {
                if (numeros[i] > numeros[j])
                {
                    // Intercambiar número
                    int tempNum = numeros[i];
                    numeros[i] = numeros[j];
                    numeros[j] = tempNum;

                    // Intercambiar nombre
                    string tempNom = nombres[i];
                    nombres[i] = nombres[j];
                    nombres[j] = tempNom;
                }
            }
        }

        Console.WriteLine("\nLista ordenada por número de libreta:");
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($"Nombre: {nombres[i]}, Libreta: {numeros[i]}");
        }
    }

    static void Main(string[] args)
    {
        int opcion;
        do
        {
            MostrarPantallaSolicitarOpcionMenu();
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    MostrarPantallaSolicitarAlumnos();
                    break;
                case 2:
                    MostrarPantallaMostrarListaOrdenada();
                    break;
                case 3:
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

            Console.WriteLine();
        } while (opcion != 3);
    }
}