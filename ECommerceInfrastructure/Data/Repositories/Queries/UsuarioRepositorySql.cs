using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceInfrastructure.Data.Repositories.Queries {
    public class UsuarioRepositorySql {


        public const string insert = @"
            INSERT INTO [dbo].[TB_USUARIO] (
                [ID_USUARIO],
                [CPF],
                [NOME],
                [EMAIL],
                [SENHA],
                [TELEFONE],
                [ATUALIZACAO_CADASTRO],
                [CRIACAO_CADASTRO],
                [CADASTRO_ATIVO]
            ) VALUES (
                @ID_USUARIO,
                @CPF,
                @NOME,
                @EMAIL,
                @SENHA,
                @TELEFONE,
                @ATUALIZACAO_CADASTRO,
                @CRIACAO_CADASTRO,
                @CADASTRO_ATIVO
            );";

    }
}
