using System.Text.Json;
using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Vehiculos
{
	public class IndexModel : PageModel
	{
		private readonly IConfiguracion _configuracion;
		public List<VehiculoResponse> vehiculos { get; set; } = default!;
		public IndexModel(IConfiguracion configuration)
		{
			_configuracion = configuration;
		}
		public async Task OnGet()
		{
			string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "ObtenerVehiculos");

			using var cliente = new HttpClient();
			var solicitud = new HttpRequestMessage(HttpMethod.Get, endpoint);

			var respuesta = await cliente.SendAsync(solicitud);

			if (!respuesta.IsSuccessStatusCode)
			{
				var error = await respuesta.Content.ReadAsStringAsync();
				Console.WriteLine($"Error de API: {respuesta.StatusCode} - {error}");
				throw new Exception($"Error del servidor: {respuesta.StatusCode} - {error}");
			}

			var resultado = await respuesta.Content.ReadAsStringAsync();
			var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

			vehiculos = JsonSerializer.Deserialize<List<VehiculoResponse>>(resultado, opciones);
		}

	}
}
