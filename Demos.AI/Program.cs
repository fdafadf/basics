﻿using Games.Go;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Demo
{
    class Segment
    {
        public double Y;
        public double Left = 0;
        public double Right = 1;
        public double Middle = 0.5;

        public Segment(double y) => Y = y;

        public void Update()
        {
            if (Math.Sqrt(Middle * Middle + Y * Y) < 1.0)
            {
                Left = Middle;
            }
            else
            {
                Right = Middle;
            }

            Middle = (Left + Right) / 2.0;
        }
    }

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //int n = 1;
            //
            //for (int i = 0; i < 8; i++)
            //{
            //    IEnumerable<Segment> segments = Enumerable.Range(0, n + 1).Select(k => new Segment(k / (double)n)).ToArray();
            //
            //    for (int j = 0; j < 43; j++)
            //    {
            //        segments.ForEach(segment => segment.Update());
            //    }
            //
            //    Console.WriteLine(4 * segments.Sum(segment => segment.Middle) / segments.Count());
            //    n = n * 10;
            //}
            //
            //return;
            new PVNetworkTest().Test();
            //var input = new NdArray(new double[] { 1, 0, 1, 0, 1, 0, 0, 0, 0 });
            //var expectedOutput = new NdArray(new double[] { 0, 0, 1 });
            ////var output = stack.Forward(input);
            ////stack.Backward();
            //for (int i = 0; i < 100; i++)
            //{
            //    Console.WriteLine(Trainer.Train(stack, input, expectedOutput, new SoftmaxCrossEntropy()));
            //    //stack.Update();
            //}

            //var prediction = stack.Predict(input);


            //Examples.Example1(Console.Out);
            //string modelPath = @"C:\Users\pstepnowski\Source\Repos\fdafadf\basics\Workspace\TicTacToeKerasModel.bin";
            //string modelPath = @"C:\Deployment\model.onnx";
            //string kerasModelPath = @"C:\Deployment\model.tf";
            //
            //if (File.Exists(kerasModelPath) == false)
            //{
            //    TicTacToeKerasExamples.TrainValueNetworkFromScratchAndSaveModel(1, kerasModelPath);
            //}

            //TicTacToeKerasExamples.AllCases();
            //TicTacToeKerasExamples.PredictTimeTest();
            ///TensorFlowSharp.PredictTimeTest(kerasModelPath);
            ///Basics.MLNet.MLTest.LoadModel(@"C:\Deployment\saved_model.pb");
            ///
            ///TensorFlowSharp.PredictTimeTest(kerasModelPath);
            //GoGameGeneratingPlayoutsTest();

            //var fullTree = Games.TicTacToe.TicTacToeGameStateGenerator.Instance.GetFullTree();
            //TicTacToeKerasModel.CreateModel(new FileInfo(Settings.TicTacToeKerasModelPath), 200);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DemoMainForm());
        }

        private static void GoGameGeneratingPlayoutsTest()
        {
            GameState gameState = new GameState(9);
            Stack<GameState> playout = null;
            var startTime = DateTime.Now;

            for (int i = 0; i < 1000; i++)
            {
                playout = gameState.RandomPlayout();
            }

            Console.WriteLine(DateTime.Now - startTime);
            List<string> joinedLines = new List<string>();

            for (int i = 0; i < playout.Count; i++)
            {
                string[] lines = playout.ElementAt(i).ToString().Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                if (i % 10 == 0)
                {
                    joinedLines.Clear();
                    joinedLines.AddRange(lines);
                }
                else
                {
                    for (int j = 0; j < lines.Length; j++)
                    {
                        joinedLines[j] += "   ";
                        joinedLines[j] += lines[j];
                    }
                }

                if (i % 10 == 9)
                {
                    foreach (var joinedLine in joinedLines)
                    {
                        Console.WriteLine(joinedLine);
                    }

                    Console.WriteLine();
                }
            }
        }
    }


    /*
            Random random = new Random(0);
            NeuralNetwork2 network = new NeuralNetwork2(2, new[] { 5, 1 }, random);
            network.WriteWeights(Console.Out);
            Console.WriteLine();

            double[][] inputs =
            {
                new [] { -1.0, -1.0 },
                new [] { -1.0, +1.0 },
                new [] { +1.0, -1.0 },
                new [] { +1.0, +1.0 },
            };

            double[][] outputs =
            {
                new [] { 0.0 },
                new [] { 1.0 },
                new [] { 1.0 },
                new [] { 0.0 },
            };

            for (int i = 0; i < 10000; i++)
            {
                for (int j = 0; j < inputs.Length; j++)
                {
                    network.Train(inputs[j], outputs[j]);
                }
            }

            for (int j = 0; j < inputs.Length; j++)
            {
                network.Evaluate(inputs[j]);
                Console.WriteLine(network.Output[0]);
            }
            */

    //var fullTree = new TicTacToeGameStateGenerator().FullTree();
    //var fullTreeFlatten = fullTree.Flatten();
    //Dictionary<int, GameState> uniqueStates = new Dictionary<int, GameState>();
    //
    //foreach (var gameState in fullTreeFlatten)
    //{
    //    int hashCode = gameState.GetHashCode();
    //
    //    if (uniqueStates.ContainsKey(hashCode) == false)
    //    {
    //        uniqueStates.Add(hashCode, gameState);
    //    }
    //}
    //
    //Console.WriteLine("All possible states: {0}", fullTreeFlatten.Count());
    //Console.WriteLine("Unique states: {0}", uniqueStates.Count());

    //var test = new PythonInterop().GetAllUniqueStates();

    //   var inputFunction = TicTacToeNeuralIO.InputFunctions.Bipolar;
    //var outputFunction = new TicTacToeMinMaxWinnerEvaluator();
    //var trainingData = TicTacToeNeuralIOGenerator.Instance.GetAllUniqueStates(inputFunction, outputFunction);
    //var csvLines = trainingData.Select(d => d.Input.Concatenate(",") + "," + d.Output.Concatenate(","));
    //File.WriteAllLines(@"C:\Deployment\TicTacToeTrainingData.txt", csvLines);

}
