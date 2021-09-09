using System;
using System.Dynamic;
using System.Linq;

namespace AllAboutEnum
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region 1. create an array of enums and iterate through it
            var arrayOfEnum = new[]
            {
                SomeEnumeratedPronouns.This,
                SomeEnumeratedPronouns.That,
            };

            Console.WriteLine("Iterate through an array of enum:");
            foreach (var element in arrayOfEnum)
            {
                Console.WriteLine(element.ToString());
            }
            Console.ReadLine();
            #endregion

            #region 2. add another value to the array of enums
            arrayOfEnum = arrayOfEnum.Concat(new[] { SomeEnumeratedPronouns.TheOther }).ToArray();

            // sort the array (sorted by index by default)
            Array.Sort(arrayOfEnum);

            Console.WriteLine("Add element to array and iterate:");
            foreach (var element in arrayOfEnum)
            {
                Console.WriteLine(element.ToString());
            }
            Console.ReadLine();
            #endregion

            #region 3. a class whose properties are arrays of enums
            var classOfEnumArrays = new AllTheEnums()
            {
                Pronouns = new[]
                {
                    SomeEnumeratedPronouns.This,
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
                pronouns = Array.ConvertAll(classOfEnumArrays.Pronouns, value => (int)value),
                conjunctions = classOfEnumArrays.Conjunctions.Select(value => (int)value).ToArray()
            };

            Console.WriteLine("Convert arrays of enum to int[] and display:");
            foreach (var element in intArrays.pronouns)
            {
                Console.WriteLine(element.ToString());
            }
            Console.ReadLine();

            foreach (var element in intArrays.conjunctions)
            {
                Console.WriteLine(element.ToString());
            }
            Console.ReadLine();

            // revert integer arrays to arrays of enums
            var newEnumArrays = new
            {
                pronouns = intArrays.pronouns.Select(p => (SomeEnumeratedPronouns)p).ToArray(),
                conjunctions = intArrays.conjunctions.Cast<SomeEnumeratedConjunctions>().ToArray()
            };

            Console.WriteLine("Convert int[] back to enum:");
            foreach (var element in newEnumArrays.pronouns)
            {
                Console.WriteLine(element.ToString());
            }
            Console.ReadLine();

            foreach (var element in newEnumArrays.conjunctions)
            {
                Console.WriteLine(element.ToString());
            }
            Console.ReadLine();
            #endregion

            #region 4. GetNames Method
            Console.WriteLine("The members of the SomeEnumeratedConjunctions enum are:");
            foreach (string s in Enum.GetNames(typeof(SomeEnumeratedConjunctions)))
                Console.WriteLine(s);
            Console.ReadLine();
            #endregion

            #region 5. TryParse and IsDefined methods
            string[] partsOfSpeech = { "this", "theOther", "and", "but", "he", "or, so" };
            foreach (string pOS in partsOfSpeech)
            {
                if (Enum.TryParse(pOS, true, out SomeEnumeratedPronouns pronouns))
                {
                    if (Enum.IsDefined(typeof(SomeEnumeratedPronouns), pronouns) | pronouns.ToString().Contains(","))
                        Console.WriteLine("Converted '{0}' to {1}.", pOS, pronouns.ToString());
                    else
                        Console.WriteLine("{0} is not an underlying value of the pronouns enumeration.", pOS);
                }
                else
                {
                    Console.WriteLine("{0} is not a member of the pronouns enumeration.", pOS);
                }

                if (Enum.TryParse(pOS, true, out SomeEnumeratedConjunctions conjunctions))
                {
                    if (Enum.IsDefined(typeof(SomeEnumeratedConjunctions), conjunctions) | conjunctions.ToString().Contains(","))
                        Console.WriteLine("Converted '{0}' to {1}.", pOS, conjunctions.ToString());
                    else
                        Console.WriteLine("{0} is not an underlying value of the conjunctions enumeration.", pOS);
                }
                else
                {
                    Console.WriteLine("{0} is not a member of the conjunctions enumeration.", pOS);
                }
            }
            #endregion

            #region 6. Custom validation

            var tryValidation = new AllTheEnums
            {
                Pronouns = new[] { SomeEnumeratedPronouns.This, SomeEnumeratedPronouns.That },
                Conjunctions = new[]
                    {SomeEnumeratedConjunctions.And, SomeEnumeratedConjunctions.Nor, SomeEnumeratedConjunctions.Yet}
            };
            ValidationUtility.ValidateDomainModel(tryValidation);

            #endregion

            //try parse string
            var data = $"[1,This,500]";
            var output = Utility.ConvertStringToEnumArray<SomeEnumeratedPronouns>(data);

            var toStringArray = new[]
                {SomeEnumeratedPronouns.This, SomeEnumeratedPronouns.That, SomeEnumeratedPronouns.TheOther};

            var stringArray = Utility.ConvertEnumArrayToString<SomeEnumeratedPronouns>(toStringArray);

        }
    }
}
