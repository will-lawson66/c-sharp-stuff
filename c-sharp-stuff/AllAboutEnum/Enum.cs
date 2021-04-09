using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AllAboutEnum
{
    public enum SomeEnumeratedPronouns
    {
        This,
        That,
        TheOther
    }

    public enum SomeEnumeratedConjunctions
    {
        And, 
        But, 
        Or, 
        Nor, 
        For, 
        Yet, 
        So
    }

    public class AllTheEnums
    {
        [ArrayOfEnum(new []{0, 1})]
        public SomeEnumeratedPronouns[] Pronouns { get; set; }
        
        public SomeEnumeratedConjunctions[] Conjunctions { get; set; }
    }

    public class ValidationUtility
    {
        public static void ValidateDomainModel<T>(T domainObject)
        {
            var vc = new ValidationContext(domainObject);
            ICollection<ValidationResult> results = new List<ValidationResult>();

            if (Validator.TryValidateObject(domainObject, vc, results, true)) return;
            var firstResult = results.FirstOrDefault();
            if (firstResult != null) throw new ValidationException(firstResult.ErrorMessage);
        }
    }
}