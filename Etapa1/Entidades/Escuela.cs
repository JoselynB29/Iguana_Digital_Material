using System;
using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    public class Escuela
    {
        public string UniqueId { get;private set; } = Guid.NewGuid().ToString();
        string nombre;
        public string Nombre
        {
            get { return "Copia: " + nombre; }
            set { nombre = value.ToUpper(); }

        }
        public int AñodDeCreacion { get; set; }

        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public TiposEscuela TipoEscuela { get; set; }
        public List<Curso>Cursos {get;set;}

        public Escuela(string nombre, int año) => (Nombre, AñodDeCreacion) = (nombre, año);

        public Escuela(string nombre, int año,
                        TiposEscuela tipo,
                        string pais = "", string ciudad = "") : base()
        {
            (Nombre, AñodDeCreacion) = (nombre, año);
            Pais = pais;
            Ciudad = ciudad;
        }


        public override string ToString()
        {
            return $"Nombre: \"{Nombre}\", Tipos: {TipoEscuela} {System.Environment.NewLine} {Pais}, Ciudad: {Ciudad}";
        }

    }
}
