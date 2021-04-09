using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace AllAboutEnum
{
    public sealed class ArrayOfEnumAttribute : ValidationAttribute
    {
        private int[] Allowed { get; }

        public ArrayOfEnumAttribute(int[] allowed)
        {
            Allowed = allowed;
        }

        public override bool IsValid(object value)
        {
            try
            {
                var values = (int[]) value;
                foreach (var element in values)
                {
                    if (!Allowed.Contains(element)) return false;
                }
            }
            catch(Exception ex)
            {
                throw new ValidationException("Values are not of correct type.", ex);
            }

            return true;
        }
    }
}
