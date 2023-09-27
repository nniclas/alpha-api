using alpha_api.Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace alpha_api.Models
{
    public interface IEntity
    {
        public int Id { get; set; }
    }
}
