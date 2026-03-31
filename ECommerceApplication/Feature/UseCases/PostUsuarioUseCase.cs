using System;
using System.Threading;
using System.Threading.Tasks;
using ECommerceApplication.Feature.DTOs;
using ECommerceApplication.Feature.Interfaces;
using ECommerceApplication.Feature.Models;



namespace ECommerceApplication.Feature.UseCases
{
    public class PostUsuarioUseCase
    {
        private readonly IUsuarioRepository _repository;

        public PostUsuarioUseCase(IUsuarioRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<UsuarioDTO> ExecuteAsync(UsuarioDTO dto, CancellationToken cancellationToken = default)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            var now = DateTime.UtcNow;

            var model = new UsuarioModel
            {
                ID_USUARIO = dto.ID_USUARIO == Guid.Empty ? Guid.NewGuid() : dto.ID_USUARIO,
                NOME = dto.NOME,
                EMAIL = dto.EMAIL,
                CPF = dto.CPF,
                TELEFONE = dto.TELEFONE,
                CRIACAO_CADASTRO = dto.CRIACAO_CADASTRO == default ? now : dto.CRIACAO_CADASTRO,
                ATUALIZACAO_CADASTRO = now,
                CADASTRO_ATIVO = dto.CADASTRO_ATIVO,
                SENHA = dto.SENHA
            };

            await _repository.InsertAsync(model, cancellationToken);

            // Atualiza campos no DTO com valores gerados/padrão
            dto.ID_USUARIO = model.ID_USUARIO;
            dto.CRIACAO_CADASTRO = model.CRIACAO_CADASTRO;
            dto.ATUALIZACAO_CADASTRO = model.ATUALIZACAO_CADASTRO;
            dto.CADASTRO_ATIVO = model.CADASTRO_ATIVO;

            return dto;
        }
    }
}
