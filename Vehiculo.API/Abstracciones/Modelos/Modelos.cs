using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Abstracciones.Modelos
{
		public class ModelosBase
		{
			public string Nombre { get; set; }
		}

		public class ModeloRequest : ModelosBase
		{
			public Guid IdMarca { get; set; }
		}

		public class ModeloResponse : ModelosBase
		{
			public Guid Id { get; set; }
			public string Marca { get; set; }
		}
	}
