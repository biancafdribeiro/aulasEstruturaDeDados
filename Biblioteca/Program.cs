using System;

namespace Biblioteca
{
    class Program
    {
        static Livros biblioteca = new Livros();

        static void Main(string[] args)
        {
            int opcao;
            do
            {
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("0. Sair");
                Console.WriteLine("1. Adicionar livro");
                Console.WriteLine("2. Pesquisar livro (sintético)");
                Console.WriteLine("3. Pesquisar livro (analítico)");
                Console.WriteLine("4. Adicionar exemplar");
                Console.WriteLine("5. Registrar empréstimo");
                Console.WriteLine("6. Registrar devolução");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        AdicionarLivro();
                        break;
                    case 2:
                        PesquisarLivroSintetico();
                        break;
                    case 3:
                        PesquisarLivroAnalitico();
                        break;
                    case 4:
                        AdicionarExemplar();
                        break;
                    case 5:
                        RegistrarEmprestimo();
                        break;
                    case 6:
                        RegistrarDevolucao();
                        break;
                }
            } while (opcao != 0);
        }

        static void AdicionarLivro()
        {
            Console.WriteLine("Digite o ISBN:");
            int isbn = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o título:");
            string titulo = Console.ReadLine();
            Console.WriteLine("Digite o autor:");
            string autor = Console.ReadLine();
            Console.WriteLine("Digite a editora:");
            string editora = Console.ReadLine();

            Livro livro = new Livro(isbn, titulo, autor, editora);
            biblioteca.Adicionar(livro);
            Console.WriteLine("Livro adicionado com sucesso!");
        }

        static void PesquisarLivroSintetico()
        {
            Console.WriteLine("Digite o ISBN do livro:");
            int isbn = int.Parse(Console.ReadLine());
            Livro livro = biblioteca.Pesquisar(isbn);

            if (livro != null)
            {
                Console.WriteLine($"Título: {livro.Titulo}");
                Console.WriteLine($"Autor: {livro.Autor}");
                Console.WriteLine($"Editora: {livro.Editora}");
                Console.WriteLine($"Total de Exemplares: {livro.QtdeExemplares()}");
                Console.WriteLine($"Exemplares Disponíveis: {livro.QtdeDisponiveis()}");
                Console.WriteLine($"Total de Empréstimos: {livro.QtdeEmprestimos()}");
                Console.WriteLine($"Percentual de Disponibilidade: {livro.PercDisponibilidade():F2}%");
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
            }
        }

        static void PesquisarLivroAnalitico()
        {
            Console.WriteLine("Digite o ISBN do livro:");
            int isbn = int.Parse(Console.ReadLine());
            Livro livro = biblioteca.Pesquisar(isbn);

            if (livro != null)
            {
                PesquisarLivroSintetico();
                Console.WriteLine("Detalhes dos Exemplares:");
                foreach (var exemplar in livro.Exemplares)
                {
                    Console.WriteLine($"Tombo: {exemplar.Tombo}, Disponível: {exemplar.Disponivel()}, Total de Empréstimos: {exemplar.QtdeEmprestimos()}");
                    Console.WriteLine("Histórico de Empréstimos:");
                    foreach (var emprestimo in exemplar.Emprestimos)
                    {
                        Console.WriteLine($"- Empréstimo em: {emprestimo.DtEmprestimo}, Devolução: {emprestimo.DtDevolucao}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
            }
        }

        static void AdicionarExemplar()
        {
            Console.WriteLine("Digite o ISBN do livro:");
            int isbn = int.Parse(Console.ReadLine());
            Livro livro = biblioteca.Pesquisar(isbn);

            if (livro != null)
            {
                Console.WriteLine("Digite o tombo do exemplar:");
                int tombo = int.Parse(Console.ReadLine());
                Exemplar exemplar = new Exemplar(tombo);
                livro.AdicionarExemplar(exemplar);
                Console.WriteLine("Exemplar adicionado com sucesso!");
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
            }
        }

        static void RegistrarEmprestimo()
        {
            Console.WriteLine("Digite o ISBN do livro:");
            int isbn = int.Parse(Console.ReadLine());
            Livro livro = biblioteca.Pesquisar(isbn);

            if (livro != null)
            {
                Exemplar exemplarDisponivel = livro.Exemplares.FirstOrDefault(e => e.Disponivel());

                if (exemplarDisponivel != null && exemplarDisponivel.Emprestar())
                {
                    Console.WriteLine("Empréstimo registrado com sucesso!");
                }
                else
                {
                    Console.WriteLine("Nenhum exemplar disponível para empréstimo.");
                }
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
            }
        }

        static void RegistrarDevolucao()
        {
            Console.WriteLine("Digite o ISBN do livro:");
            int isbn = int.Parse(Console.ReadLine());
            Livro livro = biblioteca.Pesquisar(isbn);

            if (livro != null)
            {
                Console.WriteLine("Digite o tombo do exemplar:");
                int tombo = int.Parse(Console.ReadLine());
                Exemplar exemplar = livro.Exemplares.FirstOrDefault(e => e.Tombo == tombo);

                if (exemplar != null && exemplar.Devolver())
                {
                    Console.WriteLine("Devolução registrada com sucesso!");
                }
                else
                {
                    Console.WriteLine("Exemplar não encontrado ou não está emprestado.");
                }
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
            }
        }
    }
}
