using System;

namespace Biblioteca
{
    public class Emprestimo
    {
        public DateTime DtEmprestimo { get; private set; }
        public DateTime? DtDevolucao { get; set; }

        public Emprestimo(DateTime dtEmprestimo)
        {
            DtEmprestimo = dtEmprestimo;
            DtDevolucao = null;
        }
    }
}
