using System;

class Calculadora
{
    static void Main()
    {
        bool continuar = true;

        while (continuar)
        {
            Console.Clear();
            Console.WriteLine("=== Calculadora de Consola ===");
            Console.WriteLine("1. Suma");
            Console.WriteLine("2. Resta");
            Console.WriteLine("3. Multiplicación");
            Console.WriteLine("4. División");
            Console.WriteLine("5. Raíz Cuadrada");
            Console.WriteLine("6. Exponencial");
            Console.WriteLine("7. Salir");
            Console.Write("Elige una opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1": RealizarOperacion((a, b) => a + b, "Suma"); break;
                case "2": RealizarOperacion((a, b) => a - b, "Resta"); break;
                case "3": RealizarOperacion((a, b) => a * b, "Multiplicación"); break;
                case "4": RealizarDivision(); break;
                case "5": RealizarRaizCuadrada(); break;
                case "6": RealizarOperacion(Math.Pow, "Exponencial"); break;
                case "7": continuar = false; break;
                default: Console.WriteLine("Opción no válida. Intenta de nuevo."); break;
            }

            if (continuar)
            {
                Console.WriteLine("Presiona cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }
    }

    static void RealizarOperacion(Func<double, double, double> operacion, string nombreOperacion)
    {
        (double num1, double num2) = PedirDosNumeros();
        double resultado = operacion(num1, num2);
        MostrarResultado(nombreOperacion, resultado);
    }

    static void RealizarDivision()
    {
        (double num1, double num2) = PedirDosNumeros();
        if (num2 == 0)
        {
            Console.WriteLine("Error: No se puede dividir por cero.");
        }
        else
        {
            MostrarResultado("División", num1 / num2);
        }
    }

    static void RealizarRaizCuadrada()
    {
        double num1 = PedirUnNumero();
        if (num1 < 0)
        {
            Console.WriteLine("Error: No se puede calcular la raíz cuadrada de un número negativo.");
        }
        else
        {
            MostrarResultado("Raíz Cuadrada", Math.Sqrt(num1));
        }
    }

    static (double, double) PedirDosNumeros()
    {
        double num1 = PedirUnNumero("Ingrese el primer número: ");
        double num2 = PedirUnNumero("Ingrese el segundo número: ");
        return (num1, num2);
    }

    static double PedirUnNumero(string mensaje = "Ingrese un número: ")
    {
        double numero;
        while (true)
        {
            Console.Write(mensaje);
            if (double.TryParse(Console.ReadLine(), out numero))
                return numero;
            Console.WriteLine("Error: Ingrese un número válido.");
        }
    }

    static void MostrarResultado(string operacion, double resultado)
    {
        Console.WriteLine($"El resultado de la {operacion} es: {resultado}");
    }
}
