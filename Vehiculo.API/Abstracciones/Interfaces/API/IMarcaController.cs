using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace Abstracciones.Interfaces.API
{
	public interface IMarcaController
	{

		Task<IActionResult> Obtener();

		Task<IActionResult> Obtener(Guid Id);

		Task<IActionResult> Agregar(MarcaRequest Marca);

		Task<IActionResult> Editar(Guid Id, MarcaRequest Marca);

		Task<IActionResult> Eliminar(Guid Id);
	}
}

