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
            
        }

        //OPCIÓN DOS DEL MENÚ PRINCIPAL: GESTIONAR PACIENTES
        static void GestionarPacientes()
        {
            
        }
    }
}