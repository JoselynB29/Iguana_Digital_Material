using System;
using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    public class Alumno:ObjetoEscuelaBase
    {
        public List<Evaluación> Evaluación { get; set; } = new List<Evaluación>();  
    }
}