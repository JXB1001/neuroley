using System;

namespace Neuroley
{
    class Program
    {
        static void Main(string[] args)
        {
            Perceptron brain = new Perceptron(2);
            Random random = new Random();
            int lengthOfData = 10000000;
            int i;

            
            float[,] dataset = new float[lengthOfData, 2];
            for(i = 0; i < lengthOfData; i++)
            {
                dataset[i,0] = (float)random.NextDouble();                  
                dataset[i,1] = (float)random.NextDouble();
            }

            float sum = 0;
            float eval;
            for (i = 0; i < lengthOfData*0.1; i++)
            {
                sum += Math.Abs(brain.Evaluate(new float[] { dataset[i, 0], dataset[i, 1] }, classify(new float[] { dataset[i, 0], dataset[i, 1] })));
            }
            eval = sum/(lengthOfData*0.1f);
            Console.Out.WriteLine("Before : " + eval.ToString());

            for (i = i; i < lengthOfData*0.9; i++)
            {
                brain.Train(new float[] { dataset[i, 0], dataset[i, 1] }, classify(new float[] { dataset[i, 0], dataset[i, 1] }));
            }

            sum = 0;
            for (i = i; i < lengthOfData; i++)
            {
                sum += Math.Abs(brain.Evaluate(new float[] { dataset[i, 0], dataset[i, 1] }, classify(new float[] { dataset[i, 0], dataset[i, 1] })));
            }
            eval = sum/(lengthOfData*0.1f);
            Console.Out.WriteLine( "After : " + eval.ToString());
        }

        private static int classify(float[] data)
        {
            float x = data[0];
            float y = data[1];

            if(0.3*x > y - 0.2)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
    }
}
