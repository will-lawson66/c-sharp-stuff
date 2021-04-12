using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;


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
                var message = new StringBuilder();
                message.Append(value.GetType().ToString() + " data is invalid.");
                throw new ValidationException(message.ToString(), ex);
            }

            return true;
        }
    }
}
