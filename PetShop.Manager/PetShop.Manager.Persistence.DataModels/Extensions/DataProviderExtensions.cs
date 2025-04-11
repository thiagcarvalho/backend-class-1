using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Manager.Persistence.DataModels.Extensions
{
    public static class DataProviderExtensions
    {
        public static IDbDataParameter GetParameter(this IDbCommand command, string name, object? value, DbType? dbType = null)
        {
            var parameter = command.CreateParameter();
            parameter.ParameterName = name;
            parameter.Value = value ?? DBNull.Value;
            if (dbType.HasValue)
            {
                parameter.DbType = dbType.Value;
            }
            return parameter;
        }
    }
}
