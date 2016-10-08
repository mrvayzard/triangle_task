/* Creating by Yablonskyy Denys <mrvayzard@ukr.net> */

using System;
using System.Collections.Generic;

class Ex1
{
    static List<int> FindCircularPrimeNumbers(int limit)    //finding circular prime numbers
    {
        bool flag = false;
        List<int> prime = new List<int>(); //list of circular prime numbers
        prime.Add(2);
        for (int i = 3; i < limit; i++)
        {
            string number = i.ToString();
            for (int j = 0; j < number.Length; j++)
            {
                int num = Convert.ToInt32(number);
                for (int k = 0; k < prime.Count; k++)
                {
                    if (num % prime[k] == 0 && num != prime[k]) //if number not circular prime
                    {
                        flag = true;
                        break;
                    }
                }
                //next 3 line is number discharge shift (to left)
                char temp = number[0];
                number = number.Remove(0, 1);
                number += temp;
            }
            if (flag == false)  //if number is circular prime
                prime.Add(i);
            flag = false;
        }
        return prime;   //return list of circular prime numbers
    }

    static void Main(string[] args)
    {
        int limit = 1000000;    //max number value
        List <int> circularPrimeNumbers = FindCircularPrimeNumbers(limit);  //list of circular prime numbers
        Console.WriteLine("Count of cycles prime numbers: " + circularPrimeNumbers.Count);  //output count ofcircular prime numbers to console

        /*Uncomment to output cycles prime numbers*/

        //foreach (var item in cyclesPrimeNumbers)
        //{
        //    Console.Write(item + " ");
        //}

        Console.Read();
    }
}
