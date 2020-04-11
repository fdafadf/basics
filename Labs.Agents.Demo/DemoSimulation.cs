﻿using System;

namespace Labs.Agents.Demo
{
    public class DemoSimulation : Simulation<Environment2<DemoAgent, DemoAgentState>, DemoAgent, DemoAgentState>
    {
        AgentIteractionCollection<DemoAgent, Action2> EnvironmentIteractions;

        public DemoSimulation(Environment2<DemoAgent, DemoAgentState> environment, int numberOfAgents) : base(environment, numberOfAgents)
        {
            EnvironmentIteractions = new AgentIteractionCollection<DemoAgent, Action2>(Agents);
        }

        protected override void InitializeAgents()
        {
            for (int i = 0; i < Agents.Length; i++)
            {
                Environment.Add(Agents[i] = new DemoAgent(this), Environment.GetRandomUnusedPosition(Random));
            }
        }

        public override void Step()
        {
            foreach (var iteraction in EnvironmentIteractions)
            {
                iteraction.Action = iteraction.Agent.GetAction();
            }

            Environment.Apply(EnvironmentIteractions);
        }
    }
}