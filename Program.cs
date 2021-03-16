using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        ListarSerie();
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
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
                Console.WriteLine("Obrigado por utilizar nossos serviços.");
                Console.ReadLine();
        }
        private static void VisualizarSerie()
		{
			Console.Write("Digite o ID da Série:");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
		}
        private static void ExcluirSerie()
		{
			Console.Write("Digite o id da Série:");
			int indiceSerie = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceSerie);
		}
        private static void ListarSerie()
		{
			Console.WriteLine("Listar Séries");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma Série Cadastrada.");
				return;
			}

			foreach (var serie in lista)
			{
                var excluido = serie.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "[Excluído]" : ""));
			}
		}
        private static void AtualizarSerie()
        {
            Console.Write("Digite o ID da Série:");
			int indiceSerie = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o Gênero entre as opções acima:");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série:");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série:");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série:");
			string entradaDescricao = Console.ReadLine();

			Serie atualizaSerie = new Serie(id: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualizar(indiceSerie, atualizaSerie);
        }
        private static void InserirSerie()
        {
            Console.WriteLine("Inserir Nova Série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}",i,Enum.GetName(typeof(Genero),i));
            }
            Console.Write("Digite o gênero entre as opções acima:");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série:");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Inicio da Série:");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série:");
            string entradaDescricao = Console.ReadLine();

            Serie novaserie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorio.insere(novaserie);

        }
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("");
            Console.WriteLine("DIO Séries a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Listar Séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar Série");
            Console.WriteLine("4 - Excluir Série");
            Console.WriteLine("5 - Visualizar Série");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine("");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine("");
            return opcaoUsuario;
        }
    }
}
