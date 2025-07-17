using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Interfaces.DA
{
	public interface IMarcaDA
	{


		Task<IEnumerable<MarcaResponse>> Obtener();

		Task<MarcaResponse> Obtener(Guid Id);

		Task<Guid> Agregar(MarcaRequest Marcas);

		Task<Guid> Editar(Guid Id, MarcaRequest Marcas);

		Task<Guid> Eliminar(Guid Id);
	}
}

