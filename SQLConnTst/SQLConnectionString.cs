using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SQLConnTst
{
    public class SQLConnectionString
    {
        public string Username { get; set; } = "joeblow@mferncervgmail.onmicrosoft.com";
        public string Password { get; set; } = "password";
        public string Server { get; set; } = "mferncervsql.database.windows.net";
        public string InitialCatalog { get; set; } = "mifernadb";

        public string TableName { get; set; } = "names";
        public AuthenticationType AuthenticationType { get; set; }
        public string FullConnectionString
        {
            get
            {
                if (AuthenticationType == AuthenticationType.SQLCredentials)
                {
                    return $"Server={Server},1433;Initial Catalog={InitialCatalog};Persist Security Info=False;User ID={Username};Password={Password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;";
                }

             
                    return $"Server={Server},1433;Initial Catalog={InitialCatalog};Persist Security Info=False;User ID={Username};Password={Password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Authentication=\"{AuthenticationType.GetDisplayName()}\";";
            }
        }
    }
}