using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModels.Models
{
    [Table("UserFavoriteResult")]
    public class UserFavoriteResult
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public virtual User User { get; set; }

        public long ResultId { get; set; }

        public virtual OperationResult Result { get; set; }
    }
}
