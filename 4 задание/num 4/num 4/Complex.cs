using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace num_4
{
    class Complex
    {

        // Вещественная и мнимая части
        double Real;
        double Imaginary;

        // ДСЧ для генерации элементов
        static Random rnd = new Random();

        // Конструкторы
        public Complex()
        {
            Real = rnd.NextDouble() * rnd.Next(-100, 101);
            Imaginary = rnd.NextDouble() * rnd.Next(-100, 101);
        }

        public Complex(double Re, double Im)
        {
            Real = Re;
            Imaginary = Im;
        }

        // Свойства
        public double Re
        {
            get { return Real; }
        }

        public double Im
        {
            get { return Imaginary; }
        }

        public override string ToString()
        {
            if (Imaginary >= 0)
                return Real + " + " + Imaginary + "i";
            return Real + " " + Imaginary + "i";
        }

        public static Complex operator +(Complex a, Complex b)
        {
            return new Complex(a.Re + b.Re, a.Im + b.Im);
        }

        public static Complex operator -(Complex a, Complex b)
        {
            return new Complex(a.Re - b.Re, a.Im - b.Im);
        }

        public static Complex operator *(Complex a, Complex b)
        {
            return new Complex(a.Re * b.Re - a.Im * b.Im, a.Im * b.Re + a.Re * b.Im);
        }

        public static Complex operator /(Complex a, Complex b)
        {
            Complex c = b.Conjugate();
            double denominator = Math.Pow(b.Re, 2) + Math.Pow(b.Im, 2);
            Complex res = a * c;
            return new Complex(res.Re / denominator, res.Im / denominator);
        }

        // Сопряженное
        public Complex Conjugate()
        {
            return new Complex(Re, -1 * Im);
        }

        // Возведение в степень
        public Complex Pow(int p)
        {
            Complex res = this;
            for (int i = 1; i < p; i++)
                res = res * res;
            return res;
        }
    }
}
