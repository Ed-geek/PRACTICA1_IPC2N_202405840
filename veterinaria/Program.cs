using System;
using veterinaria.models;
using veterinaria.services;

namespace veterinaria
{
    class Program
    {
        static Veterinaria veterinaria = new Veterinaria();

        static void Main(string[] args)
        {
            bool salir = false;

            while (!salir)
            {
                MenuConsola.MostrarMenuPrincipal();
                int opcion = MenuConsola.LeerOpcion(1, 3);

                switch (opcion)
                {
                    case 1:
                        RegistrarMascota();
                        break;
                    case 2:
                        GestionarPacientes();
                        break;
                    case 3:
                        salir = true;
                        Console.WriteLine("Saliendo del sistema...");
                        break;
                }
            }
        }

        //Opción #1: Registrar mascota
        static void RegistrarMascota()
        {
            Console.Clear();
           Console.WriteLine("--- REGISTRO DE NUEVA MASCOTA ---");


           string nombre = MenuConsola.LeerString("Nombre: ");
           double peso = MenuConsola.LeerDouble("Peso (kg): ");
           string sexo = MenuConsola.LeerString("Sexo (M/F): ");
           int edad = MenuConsola.LeerInt("Edad (años): ");
           string propietario = MenuConsola.LeerString("Propietario: ");
           bool enfermo = MenuConsola.LeerBool("¿Está enfermo?");


           //QUÉ TIPO DE MASCOTA ES?
           Console.WriteLine("Seleccione el tipo de mascota:");
           Console.WriteLine("1. Perro");
           Console.WriteLine("2. Gato");
           Console.WriteLine("3. Ave");
           Console.WriteLine("4. Tortuga");
           int tipo = MenuConsola.LeerOpcion(1, 4);


           // Declaramos la variable como nullable
           Mascota? nueva = null;

            // Según el tipo de animal, pedimos información adicional y creamos la instancia correspondiente
           switch (tipo)
           {
               case 1:
                   string razaPerro = MenuConsola.LeerString("Raza: ");
                   string tamano = MenuConsola.LeerString("Tamaño (pequeño/mediano/grande): ");
                   nueva = new Perro(nombre, peso, sexo, edad, propietario, enfermo, razaPerro, tamano);
                   break;


               case 2:
                   string razaGato = MenuConsola.LeerString("Raza: ");
                   bool esterilizado = MenuConsola.LeerBool("¿Está esterilizado?");
                   nueva = new Gato(nombre, peso, sexo, edad, propietario, enfermo, razaGato, esterilizado);
                   break;


               case 3:
                   double envergadura = MenuConsola.LeerDouble("Envergadura de alas (cm): ");
                   bool puedeVolar = MenuConsola.LeerBool("¿Puede volar?");
                   nueva = new Ave(nombre, peso, sexo, edad, propietario, enfermo, envergadura, puedeVolar);
                   break;


               case 4:
                   string caparazon = MenuConsola.LeerString("Tipo de caparazón (duro/blando): ");
                   bool esAcuatica = MenuConsola.LeerBool("¿Es acuática?");
                   nueva = new Tortuga(nombre, peso, sexo, edad, propietario, enfermo, caparazon, esAcuatica);
                   break;
           }


           // Validación de seguridad (aunque el switch siempre asigna un valor para 1-4)
           if (nueva == null)
           {
               Console.WriteLine("Error: No se pudo crear la mascota.");
               MenuConsola.Pausa();
               return;
           }


           // Ahora sabemos que nueva no es null, usamos el operador ! para suprimir la advertencia
           veterinaria.RegistrarMascota(nueva!);
           Console.WriteLine($"\n¡Mascota registrada con éxito! Código único: {nueva.Codigo}");
           MenuConsola.Pausa();

        }

        //OPCIÓN DOS DEL MENÚ PRINCIPAL: GESTIONAR PACIENTES
        static void GestionarPacientes()
        {
            Console.Clear();


           if (veterinaria.CantidadPacientes() == 0)
           {
               Console.WriteLine("No hay pacientes registrados.");
               MenuConsola.Pausa();
               return;
           }


           veterinaria.MostrarLista();


           Console.Write("\nSeleccione el número del paciente a gestionar (0 para cancelar): ");
           int indice = MenuConsola.LeerOpcion(0, veterinaria.CantidadPacientes());


           if (indice == 0)
               return;


           Mascota mascota = veterinaria.ObtenerTodos()[indice - 1];
           bool volver = false;

            //OPCIONES DE MASCOTAS
           while (!volver)
           {
               Console.Clear();
               Console.WriteLine($"--- GESTIÓN DE {mascota.Nombre.ToUpper()} ---");
               Console.WriteLine("1. Cambiar estado (enfermo/sano)");
               Console.WriteLine("2. Calcular dosis de medicamento");
               Console.WriteLine("3. Mostrar información completa");
               Console.WriteLine("4. Volver al menú anterior");
               Console.Write("Opción: ");
               int opcion = MenuConsola.LeerOpcion(1, 4);


               switch (opcion)
               {
                   case 1:
                       mascota.CambiarEstado();
                       Console.WriteLine($"Estado actualizado a: {(mascota.Enfermo ? "Enfermo" : "Sano")}");
                       MenuConsola.Pausa();
                       break;


                   case 2:
                       double dosisPorKg = MenuConsola.LeerDouble("Ingrese la dosis estándar (mg/kg): ");
                       double dosis = mascota.CalcularDosis(dosisPorKg);
                       Console.WriteLine($"La dosis calculada para {mascota.Nombre} es: {dosis:F2} mg");
                       MenuConsola.Pausa();
                       break;


                   case 3:
                       Console.WriteLine("\n--- INFORMACIÓN COMPLETA ---");
                       mascota.MostrarInformacion();
                       MenuConsola.Pausa();
                       break;


                   case 4:
                       volver = true;
                       break;
               }
           }

        }
    }
}