using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace AgendaBSS.Models
{
    public class TarefaMap: ClassMap<Tarefa>
    {
        public TarefaMap()
        {
            Id(x => x.Id);
            Map(x => x.Titulo).Length(100);
            Map(x => x.Data_Cadastro);
            Map(x => x.Data_Entrega);
            Map(x => x.Descricao).Length(100);
            HasMany(x => x.ListaAnexos);
            HasMany(x => x.ListaCheckList);
            Table("Tarefa");
        }
    }
}
