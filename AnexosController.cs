using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AgendaBSS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NHibernate;
using NHibernate.Linq;
using System.Web;

namespace AgendaBSS.Controller
{
    public class AnexosController: ControllerBase
    {
        //Get CheckList Index.
        public ActionResult Index()
        {
            using (NHibernate.ISession session = NHibernateHelper.AbreSessao())
            {
                var anexo = session.Query<Anexos>().ToList();
                return View(anexo);
            }
        }

        //Get: CheckList/Detail/5
        public ActionResult Details(int id)
        {
            using (NHibernate.ISession session = NHibernateHelper.AbreSessao())
            {
                var anexo = session.Get<Anexos>(id);
                return View(anexo);
            }
        }

        DirectoryInfo dirArquivos = new DirectoryInfo(Server.MapPath("~/Upload/"));
        //POST CheckList/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Anexos anexo, HttpPostedFileBase file = null)
        {
            try
            {
                using (NHibernate.ISession session = NHibernateHelper.AbreSessao())
                {
                    if (file != null)
                    {
                        var arquivo = Request.Files[0];
                        var nomeArquivo = "Arq" + DateTime.Now.Millisecond.ToString() + ".pdf";
                        if (arquivo != null && arquivo.ContentLength() > 0)
                        {
                            anexo.Caminho_Arquivo = Path.Combine(dirArquivos, file.FileName);
                            var path = Path.Combine(dirArquivos, Path.GetFileName(file.FileName));
                            arquivo.SaveAs(path);
                        }
                    }
                    using (ITransaction transacao = session.BeginTransaction())
                    {
                        session.Save(anexo);
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
                var anexo = session.Get<Anexos>(id);
                return View(anexo);
            }
        }

        //Post CheckList/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Anexos anexo)
        {
            try
            {
                using (NHibernate.ISession session = NHibernateHelper.AbreSessao())
                {
                    var anexoAlterado = session.Get<Anexos>(id);
                    anexoAlterado.Id = anexo.Id;
                    anexoAlterado.Caminho_Arquivo = anexo.Caminho_Arquivo;
                    anexoAlterado._Tarefa = anexo._Tarefa;
                    using (ITransaction transacao = session.BeginTransaction())
                    {
                        session.Save(anexoAlterado);
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
                var anexo = session.Get<Anexos>(id);
                return View(anexo);
            }
        }

        //Post CheckList/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Anexos anexo)
        {
            try
            {
                using (NHibernate.ISession session = NHibernateHelper.AbreSessao())
                {
                    using (ITransaction transacao = session.BeginTransaction())
                    {
                        session.Delete(anexo);
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
}
