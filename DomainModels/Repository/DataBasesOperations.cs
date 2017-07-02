using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Repository
{
    public class DataBasesOperations
    {
        private string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Vaio\Desktop\SuperCalc\ReactCalc-MVCApp\DomainModels\App_Data\reactcalc.mdf;Integrated Security=True";

        public IUserRepository userOpers;

        public IOperationRepository operOpers;

        public IOperationResultRepository operRes;

        public IUserFavoriteResultRepository usrFevRes;

        public DataBasesOperations()
        {
            userOpers = new UserRepository(conString);

            operOpers = new OperationRepository(conString);

            operRes = new OperationResultRepository(conString);

            usrFevRes = new UserFavoriteResultRepository(conString);
        }
    }
}
