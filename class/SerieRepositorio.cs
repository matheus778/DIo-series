using System;
using System.Collections.Generic;
using Dio_series.interfaces;

namespace Dio_series
{
  public class SerieRepositorio : iRepositorio<Serie>
  {
    private List<Serie> listaSerie = new List<Serie>();
    public void atualizar(int id, Serie objeto)
    {
      listaSerie[id] = objeto;
    }

    public void excluir(int id)
    {
      listaSerie[id].excluir();
    }

    public void insere(Serie objeto)
    {
      listaSerie.Add(objeto);
    }

    public List<Serie> Lista()
    {
      return listaSerie;
    }

    public int proximoId()
    {
      return listaSerie.Count;
    }

    public Serie retornaPorId(int id)
    {
      return listaSerie[id];
    }
  }
}
