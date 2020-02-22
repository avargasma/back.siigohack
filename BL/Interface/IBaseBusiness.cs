using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interface
{
    public interface IBaseBusiness<T>
    {
        #region Queries

        public Task<List<T>> GetAll(int quantity = -1);

        public Task<List<T>> GetAllBy(Expression<Func<T, bool>> condition);

        public Task<T> GetById(int id);

        public Task<T> GetBy(Expression<Func<T, bool>> condition);

        #endregion

        #region Insert
        /// <summary>
        /// Metodo que agrerga un entidad de tipo {T}
        /// </summary>
        /// <param name="entity">Entidad de tipo {T}</param>
        /// <returns>Retorna la entidad de tipo {T} generada</returns>
        public Task<T> Update(T entity);
        public Task<T> Insert(T entity);
        #endregion

        #region Delete

        /// <summary>
        /// Metodo para eliminar una entidad de tipo {T} por su identificador
        /// </summary>
        /// <param name="id">Identificador de la {T}</param>
        /// <returns>Retorna verdadero si se pudo eliminar, de lo contrario retorna falso></returns>
        public Task<bool> Delete(int id, long idUsuMod);

        #endregion
    }
}
