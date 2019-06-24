using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaBSS.Models
{
    public class Anexos
    {
        private int id;
        private String caminho_arquivo;
        private Tarefa _tarefa;

        public virtual int Id
        {
            get;
            set;
        }

        public virtual String Caminho_Arquivo
        {
            get;
            set;
        }

        public virtual Tarefa _Tarefa
        {
            get;
            set;
        }

        public Anexos() { }
    }
}
