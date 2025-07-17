using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;

using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MarcaController : ControllerBase, IMarcaController
	{
		private IMarcaFlujo _MarcaFlujo;
		private ILogger<MarcaController> _logger;

		public MarcaController(IMarcaFlujo MarcaFlujo, ILogger<MarcaController> logger)
		{
			_MarcaFlujo = MarcaFlujo;
			_logger = logger;
		}
		[HttpPost]
		public async Task<IActionResult> Agregar(MarcaRequest Marca)
		{
			var resultado = await _MarcaFlujo.Agregar(Marca);
			return CreatedAtAction(nameof(Obtener),new{Id=resultado},null);
		}
		[HttpPut("{Id}")]
		public async Task<IActionResult> Editar(Guid Id, MarcaRequest Marca)
		{
			var resultado = await _MarcaFlujo.Editar(Id, Marca);
			return Ok(resultado);
		}
		[HttpDelete("{Id}")]
		public async Task<IActionResult> Eliminar(Guid Id)
		{
			var resultado = await _MarcaFlujo.Eliminar(Id);
			return NoContent();
		}
		[HttpGet]
		public async Task<IActionResult> Obtener()
		{
			var resultado = await _MarcaFlujo.Obtener();
			if (!resultado.Any())
				return NoContent();
			return Ok(resultado);
		}

		[HttpGet("{Id}")]
		public async Task<IActionResult> Obtener(Guid Id)
		{
			var resultado = await _MarcaFlujo.Obtener();
			return Ok(resultado);
		}
	}
}
