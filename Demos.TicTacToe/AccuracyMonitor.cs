﻿using AI.TicTacToe;
using AI.TicTacToe.NeuralNetworks;
using AI.NeuralNetwork;

namespace Demos.TicTacToe
{
    public class AccuracyMonitor : TrainingMonitor
    {
        Trainer Trainer;

        public override void OnEpoch(double[][] features, double[][] labels)
        {
            CollectedData.Add(CalculateAccuracy(Trainer.Optimizer).Value);
        }

        public override void OnInit(Trainer trainer, int epoches)
        {
            Trainer = trainer;
        }

        public override void OnOptimized(double[] features, double[] labels, double[] evaluation)
        {
        }

        static double[][] Features = DataLoader.TestingFeatures;
        static TicTacToeResultProbabilities[] Labels = DataLoader.TestingLabels;

        public static Accuracy CalculateAccuracy(Optimizer optimizer)
        {
            int correctPredictionCount = 0;

            for (int i = 0; i < Features.Length; i++)
            {
                double[] prediction = optimizer.Network.Evaluate(Features[i]);

                if (TicTacToeTrainingData.IsPredictionCorrect(Labels[i], prediction))
                {
                    correctPredictionCount++;
                }
            }

            return new Accuracy(correctPredictionCount, Features.Length);
        }

        public override string ToString()
        {
            return "ACC";
        }
    }
}
