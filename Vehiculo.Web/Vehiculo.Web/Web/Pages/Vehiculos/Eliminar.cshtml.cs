using System.Text.Json;
using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages
{
	public class EliminarModel : PageModel
	{
		private readonly IConfiguracion _configuracion;
		public VehiculoResponse vehiculo { get; set; } = default!;

		public EliminarModel(IConfiguracion configuration)
		{
			_configuracion = configuration;
		}


		public async Task<IActionResult> OnGetAsync(Guid? id)
		{
			if (id == null || id == Guid.Empty)
				return NotFound();

			string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "ObtenerVehiculo");

			using var cliente = new HttpClient();
			var solicitud = new HttpRequestMessage(HttpMethod.Get, string.Format(endpoint, id));

			var respuesta = await cliente.SendAsync(solicitud);
			respuesta.EnsureSuccessStatusCode();

			var resultado = await respuesta.Content.ReadAsStringAsync();
			var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

			var lista = JsonSerializer.Deserialize<List<VehiculoResponse>>(resultado, opciones);
			vehiculo = lista?.FirstOrDefault() ?? new VehiculoResponse();

			return Page();
		}

		public async Task<ActionResult> OnPost(Guid? id)
		{

			if (id == Guid.Empty)
				NotFound();
			if (!ModelState.IsValid)
				Page();
			string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints",
						"EliminarVehiculos");
			var cliente = new HttpClient();
			var solicitud = new HttpRequestMessage(HttpMethod.Delete, string.Format(endpoint,id));

			var respuesta = await cliente.SendAsync(solicitud);
			respuesta.EnsureSuccessStatusCode();
			return RedirectToPage("./Index");
		}
	}
}
