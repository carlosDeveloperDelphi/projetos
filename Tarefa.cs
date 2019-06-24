using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaBSS.Models
{
    public class Tarefa
    {
        private int id;
        private String titulo;
        private DateTime data_cadastro;
        private DateTime data_entrega;
        private String descricao;
        private IList<Anexos> listaanexo;
        private IList<Checklist> listacheckelist;

        public virtual int Id
        {
            get;
            set; 
        }

        public virtual String Titulo
        {
            get;
            set;
        }

        public virtual DateTime Data_Cadastro
        {
            get;
            set;
        }

        public virtual DateTime Data_Entrega
        {
            get;
            set;
        }

        public virtual String Descricao
        {
            get;
            set;
        }

        public virtual IList<Anexos> ListaAnexos
        {
            get;
            set;
        }

        public virtual IList<Checklist> ListaCheckList
        {
            get;
            set;
        }

        public Tarefa() { }
    }
}
