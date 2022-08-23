// See https://aka.ms/new-console-template for more information
using System;

namespace CoreEscuela{

    class Escuela{
        public string nombre;
        public string direccion;
        public int añoFundacion;

        public string ceo ;

        public void Timbrar(){
            Console.Beep(2000,3000);
        }
    }
    class Program{

        static void Main(string[] args){
            var miEscuela = new Escuela();
            miEscuela.nombre = "Iguana Digital";
            miEscuela.direccion = "Carchi y Hurtado";
            miEscuela.añoFundacion = 2022;

            Console.WriteLine("TIMBRE");
            miEscuela.Timbrar();
            //Console.WriteLine("Hello");
        }
    }
}


