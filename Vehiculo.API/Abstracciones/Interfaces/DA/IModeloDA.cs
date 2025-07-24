﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.DA
{
	public interface IModeloDA
	{
		Task<IEnumerable<ModeloResponse>> Obtener();

		Task<ModeloResponse> Obtener(Guid Id);

		Task<Guid> Agregar(ModeloRequest modelo);

		Task<Guid> Editar(Guid Id, ModeloRequest modelo);

		Task<Guid> Eliminar(Guid Id);
	}
}

