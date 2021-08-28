using System;

namespace Dio_series
{
  class Program
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
            ApagarSerie();
            break;

          case "5":
            VisualizarSerie();
            break;

          case "C":
            Console.Clear();
            break;

          case "X":
            break;

          default:
            throw new ArgumentOutOfRangeException();
        }

        opcaoUsuario = ObterOpcaoUsuario();
      }
    }

    private static void ListarSeries()
    {
      Console.WriteLine("Listar series");
      var lista = repositorio.Lista();

      if (lista.Count == 0)
      {
        Console.WriteLine("! Nenhuma serie cadastrada");
        return;
      }

      foreach (var serie in lista)
      {
        var excluido = serie.retornaExcluido();

        Console.WriteLine($"#ID {serie.retornarId()}: - {serie.retornarTitulo()} {(excluido ? "*excluído*" : "")} ");

      }
    }
    private static void InserirSerie()
    {
      Console.WriteLine("Inserir nova serie: ");

      foreach (int i in Enum.GetValues(typeof(Genero)))
      {
        Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero), i)}");
      }

      Console.Write("Digite o genero entre as opçoes a cima: ");
      int entradaGenero = int.Parse(Console.ReadLine());

      Console.Write("Digite o titulo da serie: ");
      string entradaTitulo = Console.ReadLine();

      Console.Write("Digite o ano de inicio da serie: ");
      int entradaAno = int.Parse(Console.ReadLine());

      Console.Write("Digite a descrição da serie: ");
      string entradaDescricao = Console.ReadLine();

      Serie novaSerie = new Serie(
        id: repositorio.proximoId(),
        genero: (Genero)entradaGenero,
        titulo: entradaTitulo,
        descricao: entradaDescricao,
        ano: entradaAno
      );

      repositorio.insere(novaSerie);
    }
    private static void AtualizarSerie()
    {
      Console.Write("digite o id da serie: ");
      int indiceSerie = int.Parse(Console.ReadLine());

      foreach (int i in Enum.GetValues(typeof(Genero)))
      {
        Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero), i)}");
      }

      Console.Write("Digite o genero entre as opçoes a cima: ");
      int entradaGenero = int.Parse(Console.ReadLine());

      Console.Write("Digite o titulo da serie: ");
      string entradaTitulo = Console.ReadLine();

      Console.Write("Digite o ano de inicio da serie: ");
      int entradaAno = int.Parse(Console.ReadLine());

      Console.Write("Digite a descrição da serie: ");
      string entradaDescricao = Console.ReadLine();

      Serie atualizarSerie = new Serie(
        id: indiceSerie,
        genero: (Genero)entradaGenero,
        titulo: entradaTitulo,
        descricao: entradaDescricao,
        ano: entradaAno
      );

      repositorio.atualizar(indiceSerie, atualizarSerie);
    }
    private static void ApagarSerie()
    {
      Console.Write("digite o id da serie: ");
      int indiceSerie = int.Parse(Console.ReadLine());
      repositorio.excluir(indiceSerie);
    }

    private static void VisualizarSerie()
    {
      Console.Write("digite o id da serie: ");
      int indiceSerie = int.Parse(Console.ReadLine());

      var serie = repositorio.retornaPorId(indiceSerie);
      Console.WriteLine(serie);
    }
    private static string ObterOpcaoUsuario()
    {
      Console.WriteLine();
      Console.WriteLine(@" _______   __    ______           _______. _______ .______       __   _______      _______.
|       \ |  |  /  __  \         /       ||   ____||   _  \     |  | |   ____|    /       |
|  .--.  ||  | |  |  |  |       |   (----`|  |__   |  |_)  |    |  | |  |__      |   (----`
|  |  |  ||  | |  |  |  |        \   \    |   __|  |      /     |  | |   __|      \   \    
|  '--'  ||  | |  `--'  |    .----)   |   |  |____ |  |\  \----.|  | |  |____ .----)   |   
|_______/ |__|  \______/     |_______/    |_______|| _| `._____||__| |_______||_______/ ");
      Console.WriteLine();
      Console.WriteLine("Informe a opção desejada");

      Console.WriteLine("________________________");
      Console.WriteLine("|                        |");
      Console.WriteLine("| 1 - Listar series      |");
      Console.WriteLine("| 2 - Inserir nova serie |");
      Console.WriteLine("| 3 - Atualizar serie    |");
      Console.WriteLine("| 4 - Excluir serie      |");
      Console.WriteLine("| 5 - Vizualizar serie   |");
      Console.WriteLine("| C - Limpar Tela        |");
      Console.WriteLine("| X - Sair               |");
      Console.WriteLine("|________________________|");
      Console.WriteLine();
      Console.Write("--> ");

      string opcaoUsuario = Console.ReadLine().ToUpper();
      Console.WriteLine();
      return opcaoUsuario;

    }
  }
}
