using System;

namespace veterinaria.services
{
    public static class MenuConsola
    {
        public static void MostrarMenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("=== VETERINARIA ===");
            Console.WriteLine("1. Registrar mascota");
            Console.WriteLine("2. Gestionar pacientes");
            Console.WriteLine("3. Salir");
            Console.Write("Opción: ");
        }

        public static int LeerOpcion(int min, int max)
        {
            int opcion;
            while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < min || opcion > max)
            {
                Console.Write($"Ingrese un número entre {min} y {max}: ");
            }
            return opcion;
        }

        public static string LeerString(string mensaje)
        {
            Console.Write(mensaje);
            string entrada;
            do
            {
                // Usamos el operador ! para indicar que sabemos que no será null
                // porque validamos que no sea nulo ni vacío.
                entrada = Console.ReadLine()!;
                if (string.IsNullOrWhiteSpace(entrada))
                    Console.Write("No puede estar vacío. Ingrese nuevamente: ");
            } while (string.IsNullOrWhiteSpace(entrada));
            return entrada;
        }

        public static double LeerDouble(string mensaje)
        {
            double valor;
            Console.Write(mensaje);
            while (!double.TryParse(Console.ReadLine(), out valor) || valor <= 0)
            {
                Console.Write("Ingrese un número positivo válido: ");
            }
            return valor;
        }

        public static int LeerInt(string mensaje)
        {
            int valor;
            Console.Write(mensaje);
            while (!int.TryParse(Console.ReadLine(), out valor) || valor < 0)
            {
                Console.Write("Ingrese un número entero no negativo: ");
            }
            return valor;
        }

        public static bool LeerBool(string mensaje)
        {
            Console.Write(mensaje + " (s/n): ");
            string resp;
            do
            {
                resp = Console.ReadLine()!;
                if (resp != "s" && resp != "n")
                    Console.Write("Responda 's' o 'n': ");
            } while (resp != "s" && resp != "n");
            return resp == "s";
        }

        public static void Pausa()
        {
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        public static void MostrarMensaje(string mensaje)
        {
            Console.WriteLine(mensaje);
        }

        public static void MostrarError(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(mensaje);
            Console.ResetColor();
        }
    }
}