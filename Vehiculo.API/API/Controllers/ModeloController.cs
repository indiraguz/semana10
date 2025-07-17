using System.Reflection;
using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;

using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ModeloController : ControllerBase, IModeloController
	{
		private IModeloFlujo _ModeloFlujo;
		private ILogger<ModeloController> _logger;

		public ModeloController(IModeloFlujo ModeloFlujo, ILogger<ModeloController> logger)
		{
			_ModeloFlujo = ModeloFlujo;
			_logger = logger;
		}
		[HttpPost]
		public async Task<IActionResult> Agregar(ModeloRequest modelo)
		{
			var resultado = await _ModeloFlujo.Agregar(modelo);
			return CreatedAtAction(nameof(Obtener),new{Id=resultado},null);
		}
		[HttpPut("{Id}")]
		public async Task<IActionResult> Editar(Guid Id, ModeloRequest Modelo)
		{
			var resultado = await _ModeloFlujo.Editar(Id, Modelo);
			return Ok(resultado);
		}
		[HttpDelete("{Id}")]
		public async Task<IActionResult> Eliminar(Guid Id)
		{
			var resultado = await _ModeloFlujo.Eliminar(Id);
			return NoContent();
		}
		[HttpGet]
		public async Task<IActionResult> Obtener()
		{
			var resultado = await _ModeloFlujo.Obtener();
			if (!resultado.Any())
				return NoContent();
			return Ok(resultado);
		}

		[HttpGet("{Id}")]
		public async Task<IActionResult> Obtener(Guid Id)
		{
			var resultado = await _ModeloFlujo.Obtener();
			return Ok(resultado);
		}

		

	}
}
