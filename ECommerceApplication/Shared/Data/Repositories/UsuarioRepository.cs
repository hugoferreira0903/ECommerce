using System;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using ECommerceApplication.Feature.Interfaces;
using ECommerceApplication.Feature.Models;
using ECommerceInfrastructure.Data.Repositories.Queries;
using ECommerceInfrastructure.Data;

namespace ECommerceInfrastructure.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DbSession _session;

        public UsuarioRepository(DbSession session)
        {
            _session = session ?? throw new ArgumentNullException(nameof(session));
        }

        public async Task InsertAsync(UsuarioModel model, CancellationToken cancellationToken = default)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            await _session.Connection.ExecuteAsync(
                UsuarioRepositorySql.insert,
                param: model,
                transaction: _session.Transaction);
        }
    }
}
