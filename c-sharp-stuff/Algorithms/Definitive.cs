using System.Collections.Generic;

namespace Algorithms
{
    public class Definitive
    {
        public List<int> Fibonacci(int size)
        {
            var result = new List<int>();
            for (var number = 0; number < size; number++)
            {
                if (number == 0)
                {
                    result.Add(0);
                    return result;
                }
                    
                if (number == 1)
                {
                    result.Add(0);
                    result.Add(1);
                    return result;
                }
                
                result.Add(result[number - 1] + result[number - 2]);
            }

            return result;
        }
    }
}
