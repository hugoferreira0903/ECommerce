using System.Threading;
using System.Threading.Tasks;
using ECommerceApplication.Feature.DTOs;
using ECommerceApplication.Feature.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase {
        private readonly PostUsuarioUseCase _postUsuarioUseCase;

        public UsuarioController(PostUsuarioUseCase postUsuarioUseCase) {
            _postUsuarioUseCase = postUsuarioUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UsuarioDTO usuarioDto, CancellationToken cancellationToken) {
            if (usuarioDto == null)
                return BadRequest("Dados do usuário não informados.");

            var result = await _postUsuarioUseCase.ExecuteAsync(usuarioDto, cancellationToken);

            return Ok(result);
        }
    }
}
