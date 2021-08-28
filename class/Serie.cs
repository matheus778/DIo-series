using System;

namespace Dio_series
{
  public class Serie : EntidadeBase
  {
    // atributos
    private Genero genero { get; set; }
    private string titulo { get; set; }
    private string descricao { get; set; }
    private int ano { get; set; }

    private bool excluido { get; set; }

    // metodo construtor
    public Serie(int id, Genero genero, string titulo, string descricao, int ano)
    {
      this.id = id;
      this.genero = genero;
      this.titulo = titulo;
      this.descricao = descricao;
      this.ano = ano;
      this.excluido = false;
    }

    public override string ToString()
    {
      string retorno = "";
      retorno += "genero: " + this.genero + Environment.NewLine;
      retorno += "titulo: " + this.titulo + Environment.NewLine;
      retorno += "descricao: " + this.descricao + Environment.NewLine;
      retorno += "ano de inicio: " + this.ano + Environment.NewLine;
      retorno += "Excluido: " + this.excluido;
      return retorno;
    }

    public string retornarTitulo()
    {
      return this.titulo;
    }

    public int retornarId()
    {
      return this.id;
    }

    public void excluir()
    {
      this.excluido = true;
    }

    public bool retornaExcluido()
    {
      return this.excluido;
    }
  }
}