using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace AllAboutEnum
{
    public enum SomeEnumeratedPronouns
    {
        This = 0,
        That = 1,
        TheOther = 2
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
        [ArrayOfEnum(new []{0})]
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

    public class Utility
    {
        public static T[] ConvertStringToEnumArray<T>(string inputString) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum) throw new ArgumentException(typeof(T) + " is not an enumerable type.");
            
            var result = new T[0];
            var separators = new[] {'[', ']', ','};
            
            foreach (var stringElement in inputString.Split(separators, StringSplitOptions.RemoveEmptyEntries))
            {
                if (Int32.TryParse(stringElement, out int intOut) && Enum.IsDefined(typeof(T), intOut) || Enum.IsDefined(typeof(T), stringElement))
                {
                    if (Enum.TryParse<T>(stringElement, true, out T outputElement))
                    {
                        result = result.Concat(new[] { outputElement }).ToArray();
                    }
                }
                else
                {
                    Console.WriteLine(stringElement + " is not a member of enum " + typeof(T));
                    throw new ArgumentException(stringElement + " is not a member of enum" + typeof(T));
                }
            }
            return result;
        }

        public static string ConvertEnumArrayToString<T>(T[] enumArray)
        {
            if (!typeof(T).IsEnum) throw new ArgumentException(typeof(T) + " is not an enumerable type.");
            if (!enumArray.GetType().IsArray) throw new ArgumentException(enumArray.GetType() + " is not an array of " + typeof(T) + ".");

            var stringOfEnum = new StringBuilder("[");

            var lengthOfEnumArray = enumArray.Length;
            
            for (int i = 0; i < lengthOfEnumArray; i++)
            {
                if (enumArray[i] == null) continue;
                if (enumArray[i].IsAnInteger())
                {
                    stringOfEnum.Append(enumArray[i].ToString());
                }
                else if(Enum.IsDefined(typeof(T), enumArray[i]))
                {
                    stringOfEnum.Append((int)(object)enumArray[i]);
                }
                _ = i < (lengthOfEnumArray - 1) ? stringOfEnum.Append(",") : stringOfEnum.Append("]");
            }

            return stringOfEnum.ToString();
        }
    }

    public static class DomainUtilityExtensions
    {
        public static bool IsAnInteger(this object o)
        {
            HashSet<Type> integralTypes = new HashSet<Type>
            {
                typeof(UInt16)
                , typeof(UInt32)
                , typeof(UInt64)
                , typeof(Int16)
                , typeof(Int32)
                , typeof(Int64)
            };

            return integralTypes.Contains(o.GetType());
        }
    }

}