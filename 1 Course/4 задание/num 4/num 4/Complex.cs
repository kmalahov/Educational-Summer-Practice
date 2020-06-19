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
        double real;
        double imag;

        // ДСЧ для генерации элементов
        static Random rnd = new Random();

        // Конструкторы
        public Complex()
        {
            real = rnd.NextDouble() * rnd.Next(-100, 101);
            imag = rnd.NextDouble() * rnd.Next(-100, 101);
        }

        public Complex(double rel, double img)
        {
            real = rel;
            imag = img;
        }

        // Свойства
        public double rel
        {
            get { return real; }
        }

        public double img
        {
            get { return imag; }
        }

        public override string ToString()
        {
            if (imag >= 0)
                return real + " + " + imag + "i";
            return real + " " + imag + "i";
        }

        public static Complex operator +(Complex a, Complex b)
        {
            return new Complex(a.rel + b.rel, a.img + b.img);
        }

        public static Complex operator -(Complex a, Complex b)
        {
            return new Complex(a.rel - b.rel, a.img - b.img);
        }

        public static Complex operator *(Complex a, Complex b)
        {
            return new Complex(a.rel * b.rel - a.img * b.img, a.img * b.rel + a.rel * b.img);
        }

        public static Complex operator /(Complex a, Complex b)
        {
            Complex c = b.connect();
            double denom = Math.Pow(b.rel, 2) + Math.Pow(b.img, 2);
            Complex res = a * c;
            return new Complex(res.rel / denom, res.img / denom);
        }

        // Сопряженное
        public Complex connect()
        {
            return new Complex(rel, -1 * img);
        }

        // Возведение в степень
        public Complex pow(int p)
        {
            Complex res = this;
            for (int i = 1; i < p; i++)
                res = res * res;
            return res;
        }
    }
}
