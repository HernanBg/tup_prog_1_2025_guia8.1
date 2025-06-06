using System;

class Program
{
    static void Main()
    {
        int edadAnaPaula, edadLucia, edadMilena, edadJazmin;
        double montoTotal;

      
        Console.Write("Ingrese el monto total a repartir: ");
        while (!double.TryParse(Console.ReadLine(), out montoTotal) || montoTotal <= 0)
        {
            Console.Write("Monto inválido. Ingrese un número mayor a cero: ");
        }

        Console.Write("Edad de Ana Paula: ");
        while (!int.TryParse(Console.ReadLine(), out edadAnaPaula) || edadAnaPaula <= 0)
        {
            Console.Write("Edad inválida. Ingrese un número mayor a cero: ");
        }

        Console.Write("Edad de Lucía: ");
        while (!int.TryParse(Console.ReadLine(), out edadLucia) || edadLucia <= 0)
        {
            Console.Write("Edad inválida. Ingrese un número mayor a cero: ");
        }

        Console.Write("Edad de Milena: ");
        while (!int.TryParse(Console.ReadLine(), out edadMilena) || edadMilena <= 0)
        {
            Console.Write("Edad inválida. Ingrese un número mayor a cero: ");
        }

        Console.Write("Edad de Jazmín: ");
        while (!int.TryParse(Console.ReadLine(), out edadJazmin) || edadJazmin <= 0)
        {
            Console.Write("Edad inválida. Ingrese un número mayor a cero: ");
        }

      
        Servicio servicio = new Servicio();


        int sumaTotalEdades = servicio.SumarEdades(edadAnaPaula, edadLucia, edadMilena, edadJazmin);

    
        double montoAnaPaula = servicio.CalcularMontoPorEdad(montoTotal, edadAnaPaula, sumaTotalEdades);
        double montoLucia = servicio.CalcularMontoPorEdad(montoTotal, edadLucia, sumaTotalEdades);
        double montoMilena = servicio.CalcularMontoPorEdad(montoTotal, edadMilena, sumaTotalEdades);
        double montoJazmin = servicio.CalcularMontoPorEdad(montoTotal, edadJazmin, sumaTotalEdades);


        Console.WriteLine("\n--- Resultados ---");
        Console.WriteLine($"Ana Paula: ${montoAnaPaula:F2}");
        Console.WriteLine($"Lucía: ${montoLucia:F2}");
        Console.WriteLine($"Milena: ${montoMilena:F2}");
        Console.WriteLine($"Jazmín: ${montoJazmin:F2}");

        Console.WriteLine("\nPresione cualquier tecla para salir...");
        Console.ReadKey();
    }
}
public class Servicio
{

    public double CalcularMontoPorEdad(double montoTotal, int edad, int sumaTotalEdades)
    {
        return (edad * montoTotal) / (double)sumaTotalEdades;
    }


    public int SumarEdades(int edad1, int edad2, int edad3, int edad4)
    {
        return edad1 + edad2 + edad3 + edad4;
    }
}

