
using System.Net;
using System.Reflection;
using System.Text.Json;
using System.Text.RegularExpressions;
using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Pages.Vehiculos
{
	public class EditarModel : PageModel
	{
		private readonly IConfiguracion _configuracion;
		public EditarModel(IConfiguracion configuracion)
		{
			_configuracion = configuracion;
		}
		[BindProperty]
		public VehiculoRequest vehiculo { get; set; } = new VehiculoRequest();
		[BindProperty]
		public List<SelectListItem> marcas { get; set; }
		[BindProperty]
		public List<SelectListItem> modelos { get; set; }
		[BindProperty]
		public Guid marcaseleccionada { get; set; }

		public async Task<ActionResult> OnGet()
		{
			await ObtenerMarcas();
			return Page();
		}
		public async Task<ActionResult> OnPost()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}
			string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "AgregarVehiculo");
			var cliente = new HttpClient();
			var solicitud = new HttpRequestMessage(HttpMethod.Post, endpoint);
			var respuesta=await cliente.PostAsJsonAsync(endpoint, vehiculo);

			if (respuesta.IsSuccessStatusCode)
			{
				return RedirectToPage("Index");
			}
			else
			{
				ModelState.AddModelError(string.Empty, "Error al agregar el veh�culo.");
				await ObtenerMarcas();
				return Page();
			}
		}
		private async Task ObtenerMarcas()
		{

			string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "ObtenerMarcas");
			var cliente = new HttpClient();
			var solicitud = new HttpRequestMessage(HttpMethod.Get, endpoint);

			var respuesta = await cliente.SendAsync(solicitud);
			respuesta.EnsureSuccessStatusCode();
			var resultado = await respuesta.Content.ReadAsStringAsync();
			var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
			var resultadodeserializado = JsonSerializer.Deserialize<List<Marca>>(resultado, opciones);
			marcas = resultadodeserializado.Select(m =>
			new SelectListItem
			{
				Value = m.Id.ToString(),
				Text = m.Nombre,
			}

			).ToList();

		}

		private async Task<List<Modelo>> ObtenerModelos(Guid marcaId)
		{

			string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "ObtenerModelos");
			var cliente = new HttpClient();
			var solicitud = new HttpRequestMessage(HttpMethod.Get, string.Format(endpoint, marcaId));

			var respuesta = await cliente.SendAsync(solicitud);
			respuesta.EnsureSuccessStatusCode();
			if (respuesta.StatusCode == HttpStatusCode.OK)
			{
				var resultado = await respuesta.Content.ReadAsStringAsync();
				var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
				return JsonSerializer.Deserialize<List<Modelo>>(resultado, opciones);

			}
			
			return new List<Modelo>();
		}

		public async Task<JsonResult> OnGetObtenerModelos(Guid marcaID)
		{
			var modelos = await ObtenerModelos(marcaID);
			return new JsonResult(modelos);
		}


	}
}



