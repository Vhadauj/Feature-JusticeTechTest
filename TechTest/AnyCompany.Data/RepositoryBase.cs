using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Data
{
    public abstract class RepositoryBase
    {
        internal readonly string? ConnectionString;

        public RepositoryBase(IConfiguration configuration, string? connectionString = "")
        {
            if (configuration != null)
            {
                connectionString = configuration["ConnectionStrings:DefaultConnectionString"];
            }
            ConnectionString = connectionString;
        }
    }
}