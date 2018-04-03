using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Sixty.Controllers
{
    /// <summary>
    /// Интерфейс контроллера для редактирования сущности
    /// </summary>
    public interface IEntityController
    {
        /// <summary>
        /// Путь к представлениям
        /// </summary>
        string ViewPath { get; }
        /// <summary>
        /// Просмотр списка объектов сущности
        /// </summary>
        ActionResult Index();
        /// <summary>
        /// Редактирование / Создание объекта сущности
        /// </summary>
        ActionResult Edit(Guid? id = null);
        /// <summary>
        /// Удаление объекта сущности
        /// </summary>
        ActionResult Delete(Guid id);
    }
}
