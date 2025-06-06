using System;

class Program
{
    static Servicio servicio = new Servicio();

    static void Main(string[] args)
    {
        int opcion;
        do
        {
            opcion = MostrarMenu();
            switch (opcion)
            {
                case 1:
                    MostrarPantallaSolicitarMesAñoYDeterminarDías();
                    break;
                case 2:
                    MostrarPantallaVerificarSiElAñoEsBisiesto();
                    break;
                case 0:
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
            Console.WriteLine();
        } while (opcion != 0);
    }

    static int MostrarMenu()
    {
        Console.WriteLine("===== MENÚ =====");
        Console.WriteLine("1. Determinar días del mes");
        Console.WriteLine("2. Verificar si un año es bisiesto");
        Console.WriteLine("0. Salir");
        Console.Write("Seleccione una opción: ");

        int.TryParse(Console.ReadLine(), out int opcion);
        return opcion;
    }

    static void MostrarPantallaSolicitarMesAñoYDeterminarDías()
    {
        Console.Write("Ingrese el mes (1-12): ");
        int mes = Convert.ToInt32(Console.ReadLine());

        Console.Write("Ingrese el año: ");
        int año = Convert.ToInt32(Console.ReadLine());

        int dias = servicio.DeterminarLosDíasDelMes(mes, año);
        Console.WriteLine($"El mes {mes} del año {año} tiene {dias} días.");
    }

    static void MostrarPantallaVerificarSiElAñoEsBisiesto()
    {
        Console.Write("Ingrese el año: ");
        int año = Convert.ToInt32(Console.ReadLine());

        bool esBisiesto = servicio.DeterminarSiEsBisiesto(año);
        Console.WriteLine($"El año {año} {(esBisiesto ? "es" : "no es")} bisiesto.");
    }
}
public class Servicio
{
    public bool DeterminarSiEsBisiesto(int año)
    {
        return (año % 4 == 0 && año % 100 != 0) || (año % 400 == 0);
    }

    public int DeterminarLosDíasDelMes(int mes, int año)
    {
        switch (mes)
        {
            case 2:
                return DeterminarSiEsBisiesto(año) ? 29 : 28;
            case 4:
            case 6:
            case 9:
            case 11:
                return 30;
            default:
                return 31;
        }
    }
}