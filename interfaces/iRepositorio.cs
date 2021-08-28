using System.Collections.Generic;

namespace Dio_series.interfaces
{
  public interface iRepositorio<T>
  {
    List<T> Lista();
    T retornaPorId(int id);
    void insere(T entidade);
    void excluir(int id);
    void atualizar(int id, T entidade);
    int proximoId();
  }
}
