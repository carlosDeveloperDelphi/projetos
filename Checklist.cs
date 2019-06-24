using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaBSS.Models
{
    public class Checklist
    {
        private int id;
        private String checklist;
        private Tarefa _tarefa;

        public virtual int Id
        {
            get;
            set;
        }

        public virtual String CheckList
        {
            get;
            set;
        }

        public virtual Tarefa _Tarefa
        {
            get;
            set;
        }

        public Checklist() { }
    }
}
