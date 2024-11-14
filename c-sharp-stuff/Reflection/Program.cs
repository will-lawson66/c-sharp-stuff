using System;
using System.Reflection;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            Mirror mirror = new Mirror();
            Type config = typeof(Mirror);

            var settingNameBool = "SeeYourself";
            var settingNameString = "SeeYourselfUgh";

            PropertyInfo propInfoBool = config.GetProperty(settingNameBool);
            PropertyInfo propInfoString = config.GetProperty(settingNameString);

            var settingBool = new object();
            if(propInfoBool != null) 
                settingBool = propInfoBool.GetValue(mirror);
            
            var settingString = new object();
            if (propInfoString != null)
                settingString = propInfoString.GetValue(mirror);

            if (settingBool is bool)
            {
                Console.WriteLine("setting is bool");
            }

            try
            {
                if ((bool)settingString)
                {
                    Console.WriteLine("string is bool-ey");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("could not cast string as Boolean " + ex.Message);
            }
            
            Boolean.TryParse(settingString.ToString(), out bool result);
            if (result)
                Console.WriteLine("string to bool ok");
            else
                Console.WriteLine("not so bool-ey");
        }
    }
}
