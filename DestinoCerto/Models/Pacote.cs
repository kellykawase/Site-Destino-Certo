using System;

namespace DestinoCerto.Models
{
    public class Pacote
    {
        public int IdP {get; set;}
        public string Nome {get; set;}
        public string Origem {get; set;}
        public string Destino {get; set;}
        public string Atrativos {get; set;}
        public DateTime Saida {get; set;}
        public DateTime Retorno {get; set;}
        public int Usuario {get; set;}
    }
}