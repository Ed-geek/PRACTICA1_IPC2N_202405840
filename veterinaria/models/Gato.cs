using System;

namespace veterinaria.models
{
    public class Gato : Mascota
    {
        private string raza;
        private bool esterilizado;

        public string Raza
        {
            get { return raza; }
            set { raza = value; }
        }

        public bool Esterilizado
        {
            get { return esterilizado; }
            set { esterilizado = value; }
        }

        public Gato(string nombre, double peso, string sexo, int edad,
                    string propietario, bool enfermo,
                    string raza, bool esterilizado)
            : base(nombre, peso, sexo, edad, propietario, enfermo)
        {
            this.raza = raza;
            this.esterilizado = esterilizado;
        }

        public override double CalcularDosis(double dosis_por_Kg)
        {
            return base.CalcularDosis(dosis_por_Kg) * 0.90;
        }

        public override void MostrarInformacion()
        {
            Console.WriteLine("== GATO ==");
            base.MostrarInformacion();
            Console.WriteLine($"Raza: {raza} | Esterilizado: {(esterilizado ? "Sí" : "No")}");
        }
    }
}