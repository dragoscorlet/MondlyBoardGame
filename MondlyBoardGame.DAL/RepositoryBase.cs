using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MondlyBoardGame.DAL
{
    public class RepositoryBase
    {
        public string ConnectionString { get { return ConfigurationManager.ConnectionStrings["mondly"].ConnectionString; } }
    }
}
