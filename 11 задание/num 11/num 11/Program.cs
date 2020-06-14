/*
 * № 841
 * https://prnt.sc/sox0bo
 */

using System;
using System.Text;

namespace Task11
{
    public class Program
    {
        public static void Main()
        {
            Console.Write("Введите зашифрованный сигнал, состоящий из нулей и единиц, которым кратен 3: ");
            var encryptedSignal = Console.ReadLine();

            try
            {
                Console.WriteLine($"Расшифрованный сигнал: {Decrypt(encryptedSignal)}");
                Console.ReadLine();
            }
            catch (ArgumentException E)
            {
                Console.WriteLine(E.Message);
                Console.ReadLine();
            }           
            
        }

        /*
         * Метод для непосредственной дешифрофки сигнала
         * Принимает зашифрованную сигнал, возвращает расшифрованный
         */
        public static string Decrypt(string encryptedSignal)
        {
            if (encryptedSignal == null) throw new NullReferenceException();
            if (encryptedSignal.Length < 3 || encryptedSignal.Length % 3 != 0) 
                throw new ArgumentException("Зашифрованный сигнал должен быть кратен 3");

            /*
             * StringBuilder эффективен для данного алгоритма за счет мутабельности
             */
            var stringBuilder = new StringBuilder();

            /*
             * Каждая итерация проверяет очередную триаду в исходном сигнале
             */
            for (var i = 2; i < encryptedSignal.Length; i += 3)
            {
                var number1 = encryptedSignal[i - 2];
                var number2 = encryptedSignal[i - 1];
                var number3 = encryptedSignal[i];

                if (!IsZeroOrOne(number1) || !IsZeroOrOne(number2) || !IsZeroOrOne(number3))
                {
                    throw new ArgumentException("Сигнал должен состоять только из нулей и единиц");
                }

                stringBuilder.Append(number1 == number2 ? number1.ToString() : number3.ToString());
            }

            return stringBuilder.ToString();
        }

        /*
         * Метод, проверяющий, является ли переданный символ нулем или единицей
         */
        private static bool IsZeroOrOne(char ch)
        {
            return ch == 48 || ch == 49;
        }
    }
}