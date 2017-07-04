using DomainModels.Models;
using System.Data.Entity;

namespace DomainModels.EntityFramework
{
    public class CalcContext : DbContext
    {

        public CalcContext() : base(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Vaio\Desktop\Проекты\Копия\ReactCalc-MVCApp\DomainModels\App_Data\reactcalc.mdf;Integrated Security=True")
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Operation> Operations { get; set; }

        public DbSet<OperationResult> OperationResults { get; set; }

        public DbSet<UserFavoriteResult> UserFavoriteResults { get; set; }

    }
}
