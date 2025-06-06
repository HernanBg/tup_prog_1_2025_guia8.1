using System;

class Program
{
    static Servicio servicio = new Servicio();

    static void Main(string[] args)
    {
        int opcion;
        do
        {
            opcion = MostrarPantallaSolicitarOpcionMenu();

            switch (opcion)
            {
                case 1:
                    MostrarPantallaRegistrarEncuesta();
                    break;
                case 2:
                    MostrarPantallaProcesarMostrarResultadosEncuesta();
                    break;
                case 0:
                    Console.WriteLine("Fin del programa.");
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }

            Console.WriteLine();

        } while (opcion != 0);
    }

    static int MostrarPantallaSolicitarOpcionMenu()
    {
        Console.WriteLine("=== ENCUESTA DE OPINIÓN ===");
        Console.WriteLine("1. Registrar opinión");
        Console.WriteLine("2. Mostrar resultados");
        Console.WriteLine("0. Salir");
        Console.Write("Seleccione una opción: ");
        int.TryParse(Console.ReadLine(), out int opcion);
        return opcion;
    }

    static void MostrarPantallaRegistrarEncuesta()
    {
        Console.WriteLine("Ingrese su opinión:");
        Console.WriteLine("1. Positivo");
        Console.WriteLine("2. Negativo");
        Console.WriteLine("3. Indeciso");
        Console.Write("Opción: ");

        int.TryParse(Console.ReadLine(), out int opinion);

        if (opinion >= 1 && opinion <= 3)
        {
            servicio.RegistrarOpinion(opinion);
            Console.WriteLine("Opinión registrada.");
        }
        else
        {
            Console.WriteLine("Opción inválida.");
        }
    }

    static void MostrarPantallaProcesarMostrarResultadosEncuesta()
    {
        servicio.ProcesarEncuesta();

        Console.WriteLine("=== Resultados ===");
        Console.WriteLine($"Positivos: {servicio.PorcentajePositivos:F2}%");
        Console.WriteLine($"Negativos: {servicio.PorcentajeNegativos:F2}%");
        Console.WriteLine($"Indecisos: {servicio.PorcentajeIndecisos:F2}%");
    }
}
public class Servicio
{
    private int indecisos = 0;
    private int negativos = 0;
    private int positivos = 0;

    public double PorcentajeIndecisos { get; private set; }
    public double PorcentajeNegativos { get; private set; }
    public double PorcentajePositivos { get; private set; }

    public void RegistrarOpinion(int opinion)
    {
        switch (opinion)
        {
            case 1:
                positivos++;
                break;
            case 2:
                negativos++;
                break;
            case 3:
                indecisos++;
                break;
        }
    }

    public void ProcesarEncuesta()
    {
        int total = positivos + negativos + indecisos;

        if (total > 0)
        {
            PorcentajePositivos = (positivos * 100.0) / total;
            PorcentajeNegativos = (negativos * 100.0) / total;
            PorcentajeIndecisos = (indecisos * 100.0) / total;
        }
    }
}

