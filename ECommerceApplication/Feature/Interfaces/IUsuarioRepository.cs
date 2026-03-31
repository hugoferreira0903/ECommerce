using ECommerceApplication.Feature.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.Feature.Interfaces {
    public interface IUsuarioRepository {

        Task InsertAsync(UsuarioModel model, CancellationToken cancellationToken = default);

    }
}
