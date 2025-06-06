using System;
public class Servicio
{
    private int acumulador;
    private int contador;
    public int Maximo { get; private set; }
    public int Minimo { get; private set; }

    public Servicio()
    {
        acumulador = 0;
        contador = 0;
        Maximo = int.MinValue;
        Minimo = int.MaxValue;
    }

    public void RegistrarValor(int valor)
    {
        acumulador += valor;
        contador++;

        if (valor > Maximo) Maximo = valor;
        if (valor < Minimo) Minimo = valor;
    }

    public double CalcularPromedio()
    {
        if (contador == 0)
            return 0;

        return (double)acumulador / contador;
    }

    public int Contador => contador;
}



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
                    SolicitarUnNumero();
                    break;
                case 2:
                    SolicitarVariosNumeros();
                    break;
                case 3:
                    MostrarMaximo();
                    break;
                case 4:
                    MostrarMinimo();
                    break;
                case 5:
                    MostrarPromedio();
                    break;
                case 6:
                    MostrarCantidad();
                    break;
                case 0:
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Console.WriteLine("Opción inválida");
                    break;
            }
            Console.WriteLine();
        } while (opcion != 0);
    }

    static int MostrarMenu()
    {
        Console.WriteLine("----- MENÚ -----");
        Console.WriteLine("1. Ingresar un número");
        Console.WriteLine("2. Ingresar varios números");
        Console.WriteLine("3. Mostrar máximo");
        Console.WriteLine("4. Mostrar mínimo");
        Console.WriteLine("5. Calcular y mostrar promedio");
        Console.WriteLine("6. Mostrar cantidad de números");
        Console.WriteLine("0. Salir");
        Console.Write("Seleccione una opción: ");

        int.TryParse(Console.ReadLine(), out int opcion);
        return opcion;
    }

    static void SolicitarUnNumero()
    {
        Console.Write("Ingrese un número: ");
        if (int.TryParse(Console.ReadLine(), out int numero))
        {
            servicio.RegistrarValor(numero);
            Console.WriteLine("Número registrado.");
        }
        else
        {
            Console.WriteLine("Entrada inválida.");
        }
    }

    static void SolicitarVariosNumeros()
    {
        Console.Write("Ingrese números separados por coma (ej. 5,10,20): ");
        string entrada = Console.ReadLine();
        string[] partes = entrada.Split(',');

        foreach (var parte in partes)
        {
            if (int.TryParse(parte.Trim(), out int numero))
            {
                servicio.RegistrarValor(numero);
            }
        }
        Console.WriteLine("Números registrados.");
    }

    static void MostrarMaximo()
    {
        Console.WriteLine($"Máximo: {servicio.Maximo}");
    }

    static void MostrarMinimo()
    {
        Console.WriteLine($"Mínimo: {servicio.Minimo}");
    }

    static void MostrarPromedio()
    {
        Console.WriteLine($"Promedio: {servicio.CalcularPromedio():F2}");
    }

    static void MostrarCantidad()
    {
        Console.WriteLine($"Cantidad de números ingresados: {servicio.Contador}");
    }
}