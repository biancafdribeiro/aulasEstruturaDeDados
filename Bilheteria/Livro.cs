using System.Collections.Generic;
using System.Linq;

namespace Biblioteca
{
    public class Livro
    {
        public int Isbn { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
        public List<Exemplar> Exemplares { get; private set; }

        public Livro(int isbn, string titulo, string autor, string editora)
        {
            Isbn = isbn;
            Titulo = titulo;
            Autor = autor;
            Editora = editora;
            Exemplares = new List<Exemplar>();
        }

        public void AdicionarExemplar(Exemplar exemplar)
        {
            Exemplares.Add(exemplar);
        }

        public int QtdeExemplares() => Exemplares.Count;

        public int QtdeDisponiveis() => Exemplares.Count(e => e.Disponivel());

        public int QtdeEmprestimos() => Exemplares.Sum(e => e.QtdeEmprestimos());

        public double PercDisponibilidade()
        {
            if (QtdeExemplares() == 0) return 0;
            return (double)QtdeDisponiveis() / QtdeExemplares() * 100;
        }
    }
}
