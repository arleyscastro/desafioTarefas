using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using FluentValidation.Results;

namespace tarefas.Core.Domain.Entitys
{
    public class BaseEntity
    {
        [NotMapped]
        [JsonIgnore]
        public ValidationResult ValidationResult { get; set; }

        public static bool operator ==(BaseEntity a, BaseEntity b)
        {
            if ((object)a == null && (object)b == null)
            {
                return true;
            }

            if ((object)a == null || (object)b == null)
            {
                return false;
            }

            return a.Equals(b);
        }

        public static bool operator !=(BaseEntity a, BaseEntity b)
        {
            return !(a == b);
        }
       

    }
}
