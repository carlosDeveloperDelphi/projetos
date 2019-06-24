using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace AgendaBSS.Models
{
    public class NHibernateHelper
    {
        public static ISession AbreSessao()
        {
            ISessionFactory sessionFactory = Fluently.Configure().Database(PostgreSQLConfiguration.PostgreSQL82.
                                             ConnectionString("Server=localhost; Port=5432; User Id=postgres; Password=230281; Database=AgendaDB").ShowSql()).
                                             Mappings(m => m.FluentMappings.AddFromAssemblyOf<Tarefa>()).
                                             Mappings(m => m.FluentMappings.AddFromAssemblyOf<Anexos>()).
                                             Mappings(m => m.FluentMappings.AddFromAssemblyOf<Checklist>()).
                                             ExposeConfiguration(cfg => new SchemaExport(cfg).Create(false, false)).BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }
}
