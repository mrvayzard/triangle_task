using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool flag = false;
            List<int> prime = new List<int>();
            prime.Add(2);
            for (int i = 3; i < 1000000; i++)
            {
                string number = i.ToString();
                for (int j=0; j<number.Length; j++)
                {
                    int num = Convert.ToInt32(number);
                    for (int k=0; k<prime.Count; k++)
                    {
                        if (num % prime[k] == 0 && num!= prime[k])
                        {
                            flag = true;
                            break;
                        }
                    }
                    char temp = number[0];
                    number = number.Remove(0, 1);
                    number += temp;
                }
                if (flag == false)
                    prime.Add(i);
                flag = false;
            }
        }
    }
}
