using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.Feature.Models {
    public class UsuarioModel {

        public Guid ID_USUARIO { get; set; }
        public string NOME { get; set; }
        public string EMAIL { get; set; }
        public string SENHA { get; set; }
        public string CPF { get; set; }
        public string TELEFONE { get; set; }
        public DateTime CRIACAO_CADASTRO { get; set; }
        public DateTime ATUALIZACAO_CADASTRO { get; set; }
        public bool CADASTRO_ATIVO { get; set; }

    }
}
