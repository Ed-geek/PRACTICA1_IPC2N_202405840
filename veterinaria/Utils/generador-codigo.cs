using System;

namespace Utils
{
    public static class GeneradorCodigo
    {
        private static Random random = new Random();

        public static string Generar()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            char[] code = new char[8];
            for (int i = 0; i < 8; i++)
              code [i] = chars[random.Next(chars.Length)];
            return new string(code);
        }
    }
}