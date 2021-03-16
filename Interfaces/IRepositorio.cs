using System.Collections.Generic;

namespace DIO.Series.Interface
{
    public interface IRepositorio<T>
    {
         List<T> Lista();
         T RetornaPorId(int id);
         void insere(T entidade);
         void Exclui(int id);
         void Atualizar(int id,T entidade);
         int ProximoId();
    }
}