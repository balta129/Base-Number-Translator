using System;
using System.Configuration.Assemblies;
using System.Globalization;
using System.Reflection.Metadata;
using System.Security.Cryptography;

namespace TabanAritmetiği;

class Program
{
    public static void Main(string[] args)
    {
        int inputNumber = 252547;
        int inputBaseNumber = 32;
        int desiredBaseNumber = 13;
        int baseTenNumber = 0;
        bool error = false;
        ConvertNumberToBaseTen();
        if (error == false)
        {
            ConvertNumberToDesiredBase();
        }
        void ConvertNumberToBaseTen()
        {
            if (baseTenNumber != inputNumber)
            {
                string number = inputNumber.ToString();

                int[] baseNumberDigits = new int[number.Length];
                for (int i = 0; i < number.Length; i++)
                {
                    baseNumberDigits[i] = Convert.ToInt32(number[i] - 48);
                    if (baseNumberDigits[i] >= inputBaseNumber || inputBaseNumber > 36 || inputBaseNumber < 2)
                    {
                        error = true;
                        Console.WriteLine("Input digits cant be greater than base number or base number cant be greater than 36 or lower than 2!");
                        break;
                    }
                }
                if (error == false)
                {
                    int[] multipicationsOfNumbers = new int[number.Length];
                    int multipicationOfNumber = 0;
                    for (int i = 0; i < number.Length; i++)
                    {
                        multipicationOfNumber = multipicationOfNumber * inputBaseNumber;
                        if (multipicationOfNumber == 0)
                        {
                            multipicationOfNumber++;
                        }
                        
                        multipicationsOfNumbers[i] = multipicationOfNumber; 
                    }

                    int a = 0;
                    int baseTen = 0;
                    for (int i = 0; i < number.Length; i++)
                    {
                       /* Console.WriteLine("a = "+ a);
                        Console.WriteLine("baseNumberDigits[i] = "+ baseNumberDigits[i]);
                        Console.WriteLine("multipicationsOfNumbers[number.Length-1-i] = " +multipicationsOfNumbers[number.Length-1-i]);*/
                        a = baseNumberDigits[i] * multipicationsOfNumbers[number.Length - 1 - i];
                        baseTen = baseTen + a;
                    }
                    baseTenNumber = baseTen;
                }
            }
        }
        void ConvertNumberToDesiredBase()
        {
            string twodigitnumbers = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            int[] desiredbasenumbers = new int[100];

            int numberOfTransactions = 0;
            for (int i = 0; i < 100; i++)
            {
                int a = 0;
                int b = 0;
                a = baseTenNumber / desiredBaseNumber;
                b = baseTenNumber - (a * desiredBaseNumber);
                baseTenNumber = a;
                numberOfTransactions++;
                desiredbasenumbers[i] = b;
                if (a < desiredBaseNumber)
                {
                    desiredbasenumbers[i + 1] = a;
                    break;
                }
            }
            bool firstNumber = false;
            Console.Write("(" + inputNumber + ")" + inputBaseNumber + " = ");
            Console.Write("(");
            for (int i = numberOfTransactions; i >= 0; i--)
            {
                if (desiredBaseNumber != 2)
                {
                    if (firstNumber == false)
                    {
                        if (desiredbasenumbers[i] != 0)
                        {
                            firstNumber = true;
                        }
                    }
                }
                else
                {
                    firstNumber = true;
                }
                if (firstNumber == true)
                {
                    if (desiredbasenumbers[i] < 10)
                    {
                        Console.Write(desiredbasenumbers[i]);
                    }
                    else
                    {
                        for (int j = 10; j < 62; j++)
                        {
                            if (desiredbasenumbers[i] == j)
                            {
                                Console.Write(twodigitnumbers[j - 10]);
                            }
                        }
                    }
                }

            }
            Console.Write(")" + desiredBaseNumber);
        }

    }
}