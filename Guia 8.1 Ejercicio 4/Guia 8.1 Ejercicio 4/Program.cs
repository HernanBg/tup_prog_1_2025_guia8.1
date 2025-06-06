using System;
public class Servicio
{
    private string jugador1, jugador2;
    private int setGanados1, setGanados2;

    public void RegistrarJugadores(string nombre1, string nombre2)
    {
        jugador1 = nombre1;
        jugador2 = nombre2;
        setGanados1 = 0;
        setGanados2 = 0;
    }

    public void RegistrarResultadoSet(int resultado1, int resultado2)
    {
        if (resultado1 > resultado2)
        {
            setGanados1++;
        }
        else if (resultado2 > resultado1)
        {
            setGanados2++;
        }
      
    }

    public string DeterminarGanador()
    {
        if (setGanados1 > setGanados2)
        {
            return $"El ganador es: {jugador1}";
        }
        else if (setGanados2 > setGanados1)
        {
            return $"El ganador es: {jugador2}";
        }
        else
        {
            return "El juego terminó en empate.";
        }

    }
}

class Program
{
    static Servicio servicio = new Servicio();

    static void MostrarPantallaSolicitarOpcionMenu()
    {
        Console.WriteLine("1. Ingresar nombres de jugadores");
        Console.WriteLine("2. Registrar resultado del set");
        Console.WriteLine("3. Mostrar ganador");
        Console.WriteLine("4. Salir");
        Console.Write("Seleccione una opción: ");
    }

    static void MostrarPantallaSolicitarNombreJugadores()
    {
        Console.Write("Ingrese nombre del Jugador 1: ");
        string nombre1 = Console.ReadLine();
        Console.Write("Ingrese nombre del Jugador 2: ");
        string nombre2 = Console.ReadLine();

        servicio.RegistrarJugadores(nombre1, nombre2);
    }

    static void MostrarPantallaSolicitarResultadoSet()
    {
        Console.Write("Ingrese sets ganados por el Jugador 1: ");
        int resultado1 = int.Parse(Console.ReadLine());

        Console.Write("Ingrese sets ganados por el Jugador 2: ");
        int resultado2 = int.Parse(Console.ReadLine());

        servicio.RegistrarResultadoSet(resultado1, resultado2);
    }

    static void MostrarPantallaGanador()
    {
        string mensaje = servicio.DeterminarGanador();
        Console.WriteLine(mensaje);
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
                    MostrarPantallaSolicitarNombreJugadores();
                    break;
                case 2:
                    MostrarPantallaSolicitarResultadoSet();
                    break;
                case 3:
                    MostrarPantallaGanador();
                    break;
                case 4:
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }

            Console.WriteLine();

        } while (opcion != 4);
    }
}