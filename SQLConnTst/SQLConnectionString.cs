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
        public bool TrustServerCertificate { get; set; }
        public bool MultipleActiveResultSets { get; set; }
        public bool Encrypt { get; set; }
        public string TableName { get; set; } = "names";
        public AuthenticationType AuthenticationType { get; set; }
        public string FullConnectionString
        {
            get
            {
                if (AuthenticationType == AuthenticationType.SQLCredentials)
                {
                    return $"Server={Server},1433;Initial Catalog={InitialCatalog};Persist Security Info=False;User ID={Username};Password={Password};MultipleActiveResultSets={MultipleActiveResultSets};Encrypt={Encrypt};TrustServerCertificate={TrustServerCertificate};";
                }

             
                    return $"Server={Server},1433;Initial Catalog={InitialCatalog};Persist Security Info=False;User ID={Username};Password={Password};MultipleActiveResultSets={MultipleActiveResultSets};Encrypt={Encrypt};TrustServerCertificate={TrustServerCertificate};Authentication=\"{AuthenticationType.GetDisplayName()}\";";
            }
        }
    }
}