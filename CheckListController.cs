using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendaBSS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NHibernate;
using NHibernate.Linq;

namespace AgendaBSS.Controller
{
    public class CheckListController: ControllerBase
    {
        //Get CheckList Index.
        public ActionResult Index()
        {
            using (NHibernate.ISession session = NHibernateHelper.AbreSessao())
            {
                var checklist = session.Query<Checklist>().ToList();
                return View(checklist);
            }
        }

        //Get: CheckList/Detail/5
        public ActionResult Details(int id)
        {
            using (NHibernate.ISession session = NHibernateHelper.AbreSessao())
            {
                var checklist = session.Get<Checklist>(id);
                return View(checklist);
            }
        }

        //POST CheckList/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Checklist checklist)
        {
            try
            {
                using (NHibernate.ISession session = NHibernateHelper.AbreSessao())
                {
                    using (ITransaction transacao = session.BeginTransaction())
                    {
                        session.Save(checklist);
                        transacao.Commit();
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //Get CheckList/Edit/5
        public ActionResult Edit(int id)
        {
            using (NHibernate.ISession session = NHibernateHelper.AbreSessao())
            {
                var checklist = session.Get<Checklist>(id);
                return View(checklist);
            }
        }

        //Post CheckList/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Checklist checklist)
        {
            try
            {
                using (NHibernate.ISession session = NHibernateHelper.AbreSessao())
                {
                    var checklistAlterado = session.Get<Checklist>(id);
                    checklistAlterado.Id = checklist.Id;
                    checklistAlterado.CheckList = checklist.CheckList;
                    checklistAlterado._Tarefa = checklist._Tarefa;
                    using (ITransaction transacao = session.BeginTransaction())
                    {
                        session.Save(checklistAlterado);
                        transacao.Commit();
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //Get CheckList/Delete/5
        public ActionResult Delete(int id)
        {
            using (NHibernate.ISession session = NHibernateHelper.AbreSessao())
            {
                var checklist = session.Get<Checklist>(id);
                return View(checklist);
            }
        }

        //Post CheckList/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Checklist checklist)
        {
            try
            {
                using (NHibernate.ISession session = NHibernateHelper.AbreSessao())
                {
                    using (ITransaction transacao = session.BeginTransaction())
                    {
                        session.Delete(checklist);
                        transacao.Commit();
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
