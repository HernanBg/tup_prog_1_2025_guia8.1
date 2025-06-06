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
                    MostrarPantallaRegistrarTransaccion();
                    break;
                case 2:
                    MostrarPantallaPorcentajeDeCantidadesPorRubro();
                    break;
                case 3:
                    MostrarPantallaTransaccionMayorMonto();
                    break;
                case 4:
                    MostrarPantallaMontoRecaudadoTotal();
                    break;
                case 0:
                    Console.WriteLine("Programa finalizado.");
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
        Console.WriteLine("=== MENÚ DE TRANSACCIONES ===");
        Console.WriteLine("1. Registrar transacción");
        Console.WriteLine("2. Ver porcentajes por rubro");
        Console.WriteLine("3. Ver transacción de mayor monto");
        Console.WriteLine("4. Ver monto recaudado total");
        Console.WriteLine("0. Salir");
        Console.Write("Opción: ");
        int.TryParse(Console.ReadLine(), out int opcion);
        return opcion;
    }

    static void MostrarPantallaRegistrarTransaccion()
    {
        Console.Write("Número de transacción: ");
        int nro = int.Parse(Console.ReadLine());

        Console.Write("Rubro (1 a 5): ");
        int rubro = int.Parse(Console.ReadLine());

        Console.Write("Cantidad vendida: ");
        int cantidad = int.Parse(Console.ReadLine());

        Console.Write("Monto de la transacción: ");
        double monto = double.Parse(Console.ReadLine());

        servicio.EvaluarTransaccionPuntoDeVenta(nro, rubro, cantidad, monto);
        Console.WriteLine("Transacción registrada correctamente.");
    }

    static void MostrarPantallaPorcentajeDeCantidadesPorRubro()
    {
        servicio.CalcularPorcentajesCantidadVentasPorRubro();
        servicio.MostrarEstadisticas();
    }

    static void MostrarPantallaTransaccionMayorMonto()
    {
        servicio.CalcularPorcentajesCantidadVentasPorRubro(); // Solo para mantener actualizados datos si no se usó 2
        servicio.MostrarEstadisticas();
    }

    static void MostrarPantallaMontoRecaudadoTotal()
    {
        servicio.MostrarEstadisticas();
    }
}
public class Servicio
{
    private int[] cantidades = new int[5];
    private double[] porcentajes = new double[5];

    private int numeroTransaccionMayor;
    private double montoTransaccionMayor;

    private int contadorDeTransacciones;
    private double recaudacionTotal;

    public Servicio()
    {
        InicializarVariables();
    }

    public void InicializarVariables()
    {
        for (int i = 0; i < 5; i++)
        {
            cantidades[i] = 0;
            porcentajes[i] = 0.0;
        }

        contadorDeTransacciones = 0;
        recaudacionTotal = 0.0;
        numeroTransaccionMayor = 0;
        montoTransaccionMayor = 0.0;
    }

    public void EvaluarTransaccionPuntoDeVenta(int nroTransaccion, int rubro, int cantidad, double monto)
    {
        if (rubro < 1 || rubro > 5) return;

        cantidades[rubro - 1] += cantidad;
        recaudacionTotal += monto;
        contadorDeTransacciones++;

        if (monto > montoTransaccionMayor)
        {
            montoTransaccionMayor = monto;
            numeroTransaccionMayor = nroTransaccion;
        }
    }

    public void CalcularPorcentajesCantidadVentasPorRubro()
    {
        int total = 0;
        foreach (int c in cantidades)
            total += c;

        if (total > 0)
        {
            for (int i = 0; i < 5; i++)
            {
                porcentajes[i] = (cantidades[i] * 100.0) / total;
            }
        }
    }

    public void MostrarEstadisticas()
    {
        Console.WriteLine("=== Cantidad Vendida por Rubro ===");
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Rubro {i + 1}: {cantidades[i]} unidades - {porcentajes[i]:F2}%");
        }

        Console.WriteLine($"\nTransacción con mayor monto: #{numeroTransaccionMayor} por ${montoTransaccionMayor:F2}");
        Console.WriteLine($"Monto total recaudado: ${recaudacionTotal:F2}");
  
    }
}



  