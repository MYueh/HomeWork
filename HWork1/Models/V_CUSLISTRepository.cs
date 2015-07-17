using System;
using System.Linq;
using System.Collections.Generic;
	
namespace HWork1.Models
{   
	public  class V_CUSLISTRepository : EFRepository<V_CUSLIST>, IV_CUSLISTRepository
	{

	}

	public  interface IV_CUSLISTRepository : IRepository<V_CUSLIST>
	{

	}
}