using System;

namespace veterinaria.models
{
    public class Ave : Mascota
    {
        private double envergaduraAlas;
        private bool puedeVolar;

        public double EnvergaduraAlas
        {
            get { return envergaduraAlas; }
            set { envergaduraAlas = value; }
        }

        public bool PuedeVolar
        {
            get { return puedeVolar; }
            set { puedeVolar = value; }
        }

        public Ave(string nombre, double peso, string sexo, int edad,
                   string propietario, bool enfermo,
                   double envergaduraAlas, bool puedeVolar)
            : base(nombre, peso, sexo, edad, propietario, enfermo)
        {
            this.envergaduraAlas = envergaduraAlas;
            this.puedeVolar = puedeVolar;
        }

        public override double CalcularDosis(double dosis_por_Kg)
        {
            return base.CalcularDosis(dosis_por_Kg) * 0.50;
        }

        public override void MostrarInformacion()
        {
            Console.WriteLine("== AVE ==");
            base.MostrarInformacion();
            Console.WriteLine($"Envergadura de alas: {envergaduraAlas} cm");
            Console.WriteLine($"Puede volar: {(puedeVolar ? "Sí" : "No")}");
        }
    }
}