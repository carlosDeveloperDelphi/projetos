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
    public class TarefaController : ControllerBase
    {
        // GET: Tarefa
        public ActionResult Index()
        {
            using (NHibernate.ISession session = NHibernateHelper.AbreSessao())
            {
                var tarefas = session.Query<Tarefa>().ToList();
                return View(tarefas);
            }
            
        }

        // GET: Tarefa/Details/5
        public ActionResult Details(int id)
        {
            using (NHibernate.ISession session = NHibernateHelper.AbreSessao())
            {
                var tarefa = session.Get<Tarefa>(id);
                return View(tarefa);
            }

        }

        // POST: Tarefa/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tarefa tarefa)
        {
            try
            {
                // TODO: Add insert logic here
                using (NHibernate.ISession session = NHibernateHelper.AbreSessao())
                {
                    using (ITransaction transacao = session.BeginTransaction())
                    {
                        session.Save(tarefa);
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

        // GET: Tarefa/Edit/5
        public ActionResult Edit(int id)
        {
            using (NHibernate.ISession session = NHibernateHelper.AbreSessao())
            {
                var tarefa = session.Get<Tarefa>(id);
                return View(tarefa);
            }
                
        }

        // POST: Tarefa/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Tarefa tarefa)
        {
            try
            {
                // TODO: Add update logic here
                using (NHibernate.ISession session = NHibernateHelper.AbreSessao())
                {
                    var tarefaAlterado = session.Get<Tarefa>(id);
                    tarefaAlterado.Id = tarefa.Id;
                    tarefaAlterado.Titulo = tarefa.Titulo;
                    tarefaAlterado.Descricao = tarefa.Descricao;
                    tarefaAlterado.Data_Cadastro = tarefa.Data_Cadastro;
                    tarefaAlterado.Data_Entrega = tarefa.Data_Entrega;
                    using (ITransaction transacao = session.BeginTransaction())
                    {
                        session.Save(tarefaAlterado);
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

        // GET: Tarefa/Delete/5
        public ActionResult Delete(int id)
        {
            using (NHibernate.ISession session = NHibernateHelper.AbreSessao())
            {
                var tarefa = session.Get<Tarefa>(id);
                return View(tarefa);
            }

        }

        // POST: Tarefa/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Tarefa tarefa)
        {
            try
            {
                // TODO: Add delete logic here
                using (NHibernate.ISession session = NHibernateHelper.AbreSessao())
                {
                    using (ITransaction transacao = session.BeginTransaction())
                    {
                        session.Delete(tarefa);
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