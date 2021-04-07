using System;
using System.Dynamic;
using System.Linq;

namespace AllAboutEnum
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //1. create an array of enums and iterate through it
            var arrayOfEnum = new[]
            {
                SomeEnumeratedPronouns.This,
                SomeEnumeratedPronouns.That,
            };
            
            foreach (var element in arrayOfEnum)
            {
                Console.WriteLine(element.ToString());
                Console.ReadLine();
            }

            //2. add another value to the array of enums
            arrayOfEnum = arrayOfEnum.Concat(new[] {SomeEnumeratedPronouns.TheOther}).ToArray();
            
            // sort the array (sorted by index by default)
            Array.Sort(arrayOfEnum);

            foreach (var element in arrayOfEnum)
            {
                Console.WriteLine(element.ToString());
                Console.ReadLine();
            }

            //3. a class whose properties are arrays of enums
            var classOfEnumArrays = new AllTheEnums()
            {
                Pronouns = new[]
                {
                    SomeEnumeratedPronouns.That, 
                    SomeEnumeratedPronouns.TheOther
                },
                Conjunctions = new[]
                {
                    SomeEnumeratedConjunctions.And, 
                    SomeEnumeratedConjunctions.But, 
                    SomeEnumeratedConjunctions.Or, 
                    SomeEnumeratedConjunctions.So
                }
            };
            
            // convert to integer array
            var intArrays = new
            {
                pronouns = Array.ConvertAll(classOfEnumArrays.Pronouns, value => (int) value),
                conjunctions = classOfEnumArrays.Conjunctions.Select(value => (int) value).ToArray()
            };


            foreach (var element in intArrays.pronouns)
            {
                Console.WriteLine(element.ToString());
                Console.ReadLine();
            }
            foreach (var element in intArrays.conjunctions)
            {
                Console.WriteLine(element.ToString());
                Console.ReadLine();
            }
            
            // revert integer arrays to arrays of enums
            var newEnumArrays = new
            {
                pronouns = intArrays.pronouns.Select(p => (SomeEnumeratedPronouns) p).ToArray(),
                conjunctions = intArrays.conjunctions.Cast<SomeEnumeratedConjunctions>().ToArray()
            };

            foreach (var element in newEnumArrays.pronouns)
            {
                Console.WriteLine(element.ToString());
                Console.ReadLine();
            }
            foreach (var element in newEnumArrays.conjunctions)
            {
                Console.WriteLine(element.ToString());
                Console.ReadLine();
            }
        }
    }
}
