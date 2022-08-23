using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;

namespace Etapa1
{
    public sealed class EscuelaEngine
    {
        public EscuelaEngine(Escuela escuela)
        {
            this.Escuela = escuela;

        }
        public Escuela Escuela { get; set; }

        public EscuelaEngine()
        {

        }


        public void Inicializar()
        {
            Escuela = new Escuela("Iguana Digital", 2022, TiposEscuela.Secundaria,
                        pais: "Ecuador", ciudad: "Guayaquil"
                        );

            CargarCursos();
            CargarAsignaturas();
            CargarEvaluaciones();


        }


        private List<Alumno> GenerarAlumnosAlAzar(int cantidad)
        {
            string[] nombre1 = { "Ismael", "Carla", "Jose", "Luber", "Efren", "Julitza", "Silvia", "Cesar" };
            string[] apellido1 = { "Carreño", "Barriga", "Garcia", "Torres", "Galarza", "Vera", "Garcia", "Vinicio" };
            string[] nombre2 = { "Erick", "Kevin", "Santiago", "Jordan", "Camila", "Vielka", "Michelle", "Ariel" };
            string[] apellido2 = { "Lopez", "Matias", "De La Rosa", "Zambrano", "Alban", "Subia", "Villalta", "Andrade" };

            var listaAlumnos = from n1 in nombre1
                               from a1 in apellido1
                               from n2 in nombre2
                               from a2 in apellido2
                               select new Alumno { Nombre = $"{n1} {a1} {n2} {a2}" };

            return listaAlumnos.OrderBy((al) => al.UniqueId).Take(cantidad).ToList();
        }

        private void CargarCursos()
        {
            Escuela.Cursos = new List<Curso>(){
                        new Curso(){ Nombre = "101", Jornada = TiposJornada.Mañana},
                        new Curso(){Nombre = "201", Jornada = TiposJornada.Mañana},
                        new Curso{Nombre = "301", Jornada = TiposJornada.Mañana},
                        new Curso(){ Nombre = "401", Jornada = TiposJornada.Tarde},
                        new Curso(){Nombre = "501", Jornada = TiposJornada.Tarde},
            };

            Random rnd = new Random();
            foreach (var c in Escuela.Cursos)
            {
                int cantRandom = rnd.Next(5, 20);
                c.Alumnos = GenerarAlumnosAlAzar(cantRandom);
            }
        }
        public List<ObjetoEscuelaBase> GetObjetosEscuela()
        {
            var listaObj = new List<ObjetoEscuelaBase>();
            listaObj.Add(Escuela);
            listaObj.AddRange(Escuela.Cursos);

            foreach (var curso in Escuela.Cursos)
            {
                listaObj.AddRange(curso.Asignaturas);
                listaObj.AddRange(curso.Alumnos);

                foreach (var alumno in curso.Alumnos)
                {
                    listaObj.AddRange(alumno.Evaluación);
                }
            }

            return listaObj;
        }

        private void CargarAsignaturas()
        {
            foreach (var curso in Escuela.Cursos)
            {
                List<Asignatura> listaAsignatura = new List<Asignatura>(){
                    new Asignatura{Nombre="Matematicas"},
                    new Asignatura{Nombre="Educacion Fisica"},
                    new Asignatura{Nombre="Castellano"},
                    new Asignatura{Nombre="Ciencias Naturales"},
                };
                curso.Asignaturas = listaAsignatura;
            }
        }

        private void CargarEvaluaciones()
        {
            foreach (var curso in Escuela.Cursos)
            {
                foreach (var asignatura in curso.Asignaturas)
                {
                    foreach (var alumno in curso.Alumnos)
                    {
                        var rnd = new Random(System.Environment.TickCount);

                        for (int i = 0; i < 5; i++)
                        {
                            var ev = new Evaluación
                            {
                                Asignatura = asignatura,
                                Nombre = $"{asignatura.Nombre} Ev#{i + 1}",
                                Nota = (float)(5 * rnd.NextDouble()),
                                Alumno = alumno
                            };
                            alumno.Evaluación.Add(ev);
                        }
                    }
                }
            }
        }
    }
}