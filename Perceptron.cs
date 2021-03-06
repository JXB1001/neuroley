﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Neuroley
{
    class Perceptron
    {
        private float[] weights;
        private float learningRate = 0.01f;

        public Perceptron(int numberOfInputs, float learningRate)
        {
            this.learningRate = learningRate;
            Initialse(numberOfInputs);
        }

        public Perceptron(int numberOfInputs)
        {
            Initialse(numberOfInputs);
        }

        private void Initialse(int numberOfInputs)
        {
            Random random = new Random();
            weights = new float[numberOfInputs];
            for (int i = 0; i < weights.Length; i++)
                weights[i] = (float)random.NextDouble() * 2 - 1;
        }

        public float Guess(float[] input)
        {
            float output = 0;
            for(int i = 0; i < input.Length; i++)
            {
                for(int j = 1; j < input.Length; j++)
                {
                    output += weights[i] * input[j];
                }
            }
            return activate(output+0.1f);
        }

        public void Train(float[] input, float goal)
        {
            float guess = Guess(input);
            float error = goal-guess;

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 1; j < input.Length; j++)
                {
                    weights[i] +=  input[j]*error*learningRate;
                }
            }
        }

        public float Evaluate(float[] input, float goal)
        {
            float guess = Guess(input);
            float error = goal - guess;
            return error;
        }

        private int activate(float sum)
        {
            if(sum > 0)
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
