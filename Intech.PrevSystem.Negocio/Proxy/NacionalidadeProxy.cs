﻿using Intech.PrevSystem.Dados.DAO;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class NacionalidadeProxy : NacionalidadeDAO
	{
		public NacionalidadeProxy (IDbTransaction tx = null) : base(tx) { }
	}
}
