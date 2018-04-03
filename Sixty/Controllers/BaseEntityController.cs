using Sixty.Helpers;
using Sixty.Managers;
using Sixty.Models;
using Sixty.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sixty.Controllers
{
    public class BaseEntityController<T, VM> : Controller, IEntityController
        where T : class, IEntity, new()
        where VM: class, IEntityEdittingViewModel, new()
    {
        public virtual string ViewPath
        {
            get
            {
                return typeof(T).ToString().Split('.').Last();
            }
        }


        [Authorize]
        [HttpGet]
        public virtual ActionResult Delete(Guid id)
        {
            var manager = ManagerProvider.Instance.Get<T>();
            if (manager == null)
            {
                throw new Exception(TR.T("Менеджер для сущности %1 не зарегистрирован в системе!", typeof(T).ToString()));
            }
            var entity = manager.GetById(id) as T;
            if (entity == null)
            {
                return RedirectToAction("Index");
            }
            manager.DeleteEntity(entity);
            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpGet]
        public virtual ActionResult Edit(Guid? id = default(Guid?))
        {
            var model = new VM();
            if (id != null)
            {
                var manager = ManagerProvider.Instance.Get<T>();
                if (manager == null)
                {
                    throw new Exception(TR.T("Менеджер для сущности %1 не зарегистрирован в системе!", typeof(T).ToString()));
                }
                var entity = manager.GetById((Guid)id) as T;
                model.LoadEntity(entity);
            }
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public virtual ActionResult Edit(VM viewmodel)
        {
            var manager = ManagerProvider.Instance.Get<T>();
            if (manager == null)
            {
                throw new Exception(TR.T("Менеджер для сущности %1 не зарегистрирован в системе!", typeof(T).ToString()));
            }

            IEntity entity = null;
            if (viewmodel.IsNew)
            {
                entity = new T();
                entity.Id = Guid.NewGuid();
            }
            else
            {
                if (viewmodel.Id == null)
                {
                    throw new Exception(TR.T("Идентификатор не задан!"));
                }
                entity = manager.GetById((Guid)viewmodel.Id) as T;
                if (entity == null)
                {
                    //throw new Exception(TR.T("Сущность не найдена!"));
                    return RedirectToAction("Index");
                }
            }
            viewmodel.FillEntity(ref entity);
            try
            {
                if (viewmodel.IsNew)
                {
                    manager.CreateEntity(entity);
                }
                else
                {
                    manager.UpdateEntity(entity);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", TR.T("Не удалось создать сезон! %1", ex.Message));
            }

            return View(viewmodel);
        }

        [Authorize]
        [HttpGet]
        public virtual ActionResult Index()
        {
            var manager = ManagerProvider.Instance.Get<T>();
            if (manager == null)
            {
                throw new Exception(TR.T("Менеджер для сущности %1 не зарегистрирован в системе!", typeof(T).ToString()));
            }
            return View(manager.GetAll());
        }
    }
}