using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace AgendaBSS.Models
{
    public class CheckListMap: ClassMap<Checklist>
    {
        public CheckListMap()
        {
            Id(x => x.Id);
            Map(x => x.CheckList).Length(200);
            References(x => x._Tarefa).Column("idtarefa");
            Join("Tarefa", m => {
                m.Fetch.Join();
                m.KeyColumn("idtarefa");
                m.Map(t => t.Id).Nullable();
            });
            Table("Checkedlist");
        }
    }
}
