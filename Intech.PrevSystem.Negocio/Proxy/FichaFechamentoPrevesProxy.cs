﻿using Intech.PrevSystem.Dados.DAO;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class FichaFechamentoPrevesProxy : FichaFechamentoPrevesDAO
	{
		public FichaFechamentoPrevesProxy (IDbTransaction tx = null) : base(tx) { }
	}
}
