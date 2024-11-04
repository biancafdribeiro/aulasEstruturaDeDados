using System.Collections.Generic;
using System.Linq;

namespace Biblioteca
{
    public class Exemplar
    {
        public int Tombo { get; set; }
        public List<Emprestimo> Emprestimos { get; private set; }

        public Exemplar(int tombo)
        {
            Tombo = tombo;
            Emprestimos = new List<Emprestimo>();
        }

        public bool Emprestar()
        {
            if (Disponivel())
            {
                Emprestimos.Add(new Emprestimo(System.DateTime.Now));
                return true;
            }
            return false;
        }

        public bool Devolver()
        {
            var emprestimo = Emprestimos.LastOrDefault(e => e.DtDevolucao == null);
            if (emprestimo != null)
            {
                emprestimo.DtDevolucao = System.DateTime.Now;
                return true;
            }
            return false;
        }

        public bool Disponivel() => Emprestimos.All(e => e.DtDevolucao != null);

        public int QtdeEmprestimos() => Emprestimos.Count;
    }
}
