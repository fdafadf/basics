﻿using AI.NeuralNetworks.TicTacToe;
using AI.TicTacToe;
using Games.TicTacToe;
using Newtonsoft.Json;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Demos.TicTacToe
{
    public class DataLoader
    {
        public static readonly Func<GameState, double[]> InputTransform = TicTacToeNeuralIOLoader.InputTransforms.Bipolar;

        static double[][] trainingFeatures;
        static double[][] trainingLabels;
        static double[][] testingFeatures;
        static TicTacToeResultProbabilities[] testingLabels;

        public static void LoadData()
        {
            if (testingFeatures == null)
            {
                FileInfo featuresCacheFile = new FileInfo(Path.Combine(Application.UserAppDataPath, @"TicTacToe-DataLoader-Features.txt"));
                FileInfo labelsCacheFile = new FileInfo(Path.Combine(Application.UserAppDataPath, @"TicTacToe-DataLoader-Labels.txt"));

                if (featuresCacheFile.Exists && labelsCacheFile.Exists)
                {
                    testingFeatures = JsonConvert.DeserializeObject<double[][]>(File.ReadAllText(featuresCacheFile.FullName));
                    testingLabels = JsonConvert.DeserializeObject<TicTacToeResultProbabilities[]>(File.ReadAllText(labelsCacheFile.FullName));
                }
                else
                {
                    TicTacToeTrainingData.Load(InputTransform, out testingFeatures, out testingLabels);
                    File.WriteAllText(featuresCacheFile.FullName, JsonConvert.SerializeObject(testingFeatures));
                    File.WriteAllText(labelsCacheFile.FullName, JsonConvert.SerializeObject(testingLabels));
                }

                trainingFeatures = testingFeatures.Clone() as double[][];
                trainingLabels = testingLabels.Select(o => o.Probabilities).ToArray();
            }
        }

        public static double[][] TrainingFeatures
        {
            get
            {
                LoadData();
                return trainingFeatures;
            }
        }

        public static double[][] TrainingLabels
        {
            get
            {
                LoadData();
                return trainingLabels;
            }
        }

        public static double[][] TestingFeatures
        {
            get
            {
                LoadData();
                return testingFeatures;
            }
        }

        public static TicTacToeResultProbabilities[] TestingLabels
        {
            get
            {
                LoadData();
                return testingLabels;
            }
        }
    }
}
