using System.Text.Json;
using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Vehiculos
{
    public class DetalleModel : PageModel
    {
        private readonly IConfiguracion _configuracion;

		public VehiculoResponse vehiculo{ get; set; }=default!;
		public DetalleModel(IConfiguracion configuracion)
		{
			_configuracion = configuracion;
		}

		public async Task OnGet(Guid? id)
		{
			if (id == null)
				throw new Exception("ID es null");

			var fullUrl = _configuracion.ObtenerMetodo("ApiEndPoints", "ObtenerVehiculo")
										.Replace("{0}", id.ToString());

			using var cliente = new HttpClient();
			var respuesta = await cliente.SendAsync(new HttpRequestMessage(HttpMethod.Get, fullUrl));
			respuesta.EnsureSuccessStatusCode();

			var resultado = await respuesta.Content.ReadAsStringAsync();
			var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

			var lista = JsonSerializer.Deserialize<List<VehiculoResponse>>(resultado, opciones);
			vehiculo = lista?.FirstOrDefault() ?? new VehiculoResponse();
		}







	}
}
