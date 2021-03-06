﻿//#define MOMENTUM

namespace AI.NeuralNetworks
{
    public abstract class Optimizer
    {
        public Network Network { get; }
        public double LearningRate { get; private set; }

        public Optimizer(Network network, double learningRate)
        {
            Network = network;
            LearningRate = learningRate;
        }

        public abstract double[] Evaluate(double[] features, double[] labels);
        public abstract void Update(int batchSize);
    }
}
