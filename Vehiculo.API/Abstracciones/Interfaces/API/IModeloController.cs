using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace Abstracciones.Interfaces.API
{
	public interface IModeloController
	{
		Task<IActionResult> Obtener();

		Task<IActionResult> Obtener(Guid Id);

		Task<IActionResult> Agregar(ModeloRequest modelo);

		Task<IActionResult> Editar(Guid Id, ModeloRequest modelo);

		Task<IActionResult> Eliminar(Guid Id);
	}
}
