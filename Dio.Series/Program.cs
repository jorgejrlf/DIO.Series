using DIO.Series.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIO.Series
{
    static class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        //VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
        public static void ListarSeries()
        {
            Console.WriteLine("Listar series");
            var lista = repositorio.Lista();

            if (lista.Count == 0)
                Console.WriteLine("Nenhuma serie cadastrada");

            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                Console.WriteLine("#ID {0}: - {1} - {2}", serie.retornaId(), serie.retornaTitulo(), excluido ? "Excluido" : "");
            }
                
        }
        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o id da serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }
        private static void VisualizarSerie()
        {
            Console.WriteLine("Digite o id da serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.retornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }
        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));

            Console.WriteLine("Digite o gênero entre as opções acima");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Titulo da série");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de inicio da série");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da série");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie, genero: (Genero)entradaGenero, titulo: entradaTitulo, ano: entradaAno, descricao: entradaDescricao);

            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }
        private static void InserirSerie()
        {
            Console.WriteLine("inserir nova serie");

            foreach (int i in Enum.GetValues(typeof(Genero)))
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));

            Console.WriteLine("Digite o gênero entre as opções acima");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Titulo da série");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de inicio da série");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da série");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie (id: repositorio.ProximoId(), genero: (Genero)entradaGenero, titulo: entradaTitulo, ano: entradaAno, descricao: entradaDescricao);
        }
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Dio Serie a seu dispor!!");
            Console.WriteLine("Informe a opção desejada");

            Console.WriteLine("1 - Lista de serie");
            Console.WriteLine("2 - Inserir nova serie");
            Console.WriteLine("3 - Atualizar serie");
            Console.WriteLine("4 - Excluir serie");
            Console.WriteLine("5 - Visualizar serie");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string Opcao =  Console.ReadLine().ToUpper();
            Console.WriteLine();
            return Opcao;
        }
    }
}
