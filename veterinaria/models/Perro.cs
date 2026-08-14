using System;

namespace veterinaria.models
{
    public class Perro : Mascota
    {
        private string raza;
        private string tamano;

        public string Raza
        {
            get { return raza; }
            set { raza = value; }
        }

        public string Tamano
        {
            get { return tamano; }
            set { tamano = value; }
        }

        public Perro(string nombre, double peso, string sexo, int edad,
                     string propietario, bool enfermo,
                     string raza, string tamano)
            : base(nombre, peso, sexo, edad, propietario, enfermo)
        {
            this.raza = raza;
            this.tamano = tamano;
        }

        public override double CalcularDosis(double dosis_por_Kg)
        {
            return base.CalcularDosis(dosis_por_Kg);
        }

        public override void MostrarInformacion()
        {
            Console.WriteLine("== PERRO ==");
            base.MostrarInformacion();
            Console.WriteLine($"Raza: {raza} | Tamaño: {tamano}");
        }
    }
}