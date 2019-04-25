using System;

namespace Neuroley
{
    class Program
    {
        static void Main(string[] args)
        {
            Perceptron brain = new Perceptron(2);
            float guess = brain.Guess(new float[]{2,1});
            Console.Out.WriteLine(guess.ToString());
        }
    }
}
