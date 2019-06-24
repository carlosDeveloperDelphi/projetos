using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace AgendaBSS.Models
{
    public class AnexosMap: ClassMap<Anexos>
    {
        public AnexosMap()
        {
            Id(x => x.Id);
            Map(x => x.Caminho_Arquivo).Length(200);
            References(x => x._Tarefa).Column("idtarefa");
            Join("Tarefa", m => {
                m.Fetch.Join();
                m.KeyColumn("idtarefa");
                m.Map(t => t.Id).Nullable();
                });
            Table("Anexos");
        }
    }
}
