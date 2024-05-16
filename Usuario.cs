using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioTextToSpeech
{
    internal class Usuario
    {
        static public int contadorUsuarios = 1;
        private string formatoNumero = "C-";

        public string Nombre { get; private set; }
        public string Numero { get; private set; }

        public Usuario(string nombre)
        {
            Nombre = nombre;
            // Formato C-XXXX
            Numero = formatoNumero + contadorUsuarios.ToString("D4");
            contadorUsuarios++;
        }
    }
}