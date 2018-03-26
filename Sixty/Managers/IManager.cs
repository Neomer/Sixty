using Sixty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sixty.Managers
{
    /// <summary>
    /// Фасад для доступа к модели
    /// </summary>
    public interface IManager
    {
        /// <summary>
        /// Тип сущности
        /// </summary>
        System.Type EntityType { get; }
        /// <summary>
        /// Возвращает сущность по идентификатору
        /// </summary>
        IEntity GetById(Guid id);
        /// <summary>
        /// Возвращает все экземпляры сущности
        /// </summary>
        IEnumerable<IEntity> GetAll();
        /// <summary>
        /// Возвращает определенное количество экземпляров сущности
        /// </summary>
        IEnumerable<IEntity> GetLimit(int limit);
        /// <summary>
        /// Создает экземпляр сущности в базе
        /// </summary>
        void CreateEntity(IEntity entity);
        /// <summary>
        /// Сохраняет экземпляр сущности в базе
        /// </summary>
        void SaveEntity(IEntity entity);
    }
}
