using System;
using System.Collections.Generic;
using veterinaria.models;

namespace veterinaria.services
{
    public class Veterinaria
    {
        private List<Mascota> pacientes;

        public Veterinaria()
        {
            pacientes = new List<Mascota>();
        }

        public void RegistrarMascota(Mascota mascota)
        {
            pacientes.Add(mascota);
        }

        // Cambiamos el tipo de retorno a Mascota? (nullable)
        public Mascota? BuscarPorCodigo(string codigo)
        {
            return pacientes.Find(m => m.Codigo == codigo);
        }

        public List<Mascota> ObtenerTodos()
        {
            return pacientes;
        }

        public bool CambiarEstado(string codigo)
        {
            Mascota? m = BuscarPorCodigo(codigo);
            if (m == null) return false;
            m.CambiarEstado();
            return true;
        }

        public int CantidadPacientes()
        {
            return pacientes.Count;
        }

        public void MostrarLista()
        {
            if (pacientes.Count == 0)
            {
                Console.WriteLine("No hay pacientes registrados en esta veterinaria.");
                return;
            }

            Console.WriteLine("\n--- LISTA DE PACIENTES ---");
            for (int i = 0; i < pacientes.Count; i++)
            {
                var m = pacientes[i];
                Console.WriteLine($"{i + 1}. {m.Nombre} (Código: {m.Codigo}) - {(m.Enfermo ? "Enfermo" : "Sano")}");
            }
        }
    }
}