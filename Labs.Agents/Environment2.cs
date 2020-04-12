﻿using System;
using System.Linq;

namespace Labs.Agents
{
    public class Environment2<TAgent, TState> : Action2Environment<Environment2<TAgent, TState>, TAgent, TState, AgentInteraction<TAgent, Action2>>
        where TAgent : IAgent<Environment2<TAgent, TState>, TAgent, TState> 
        where TState : AgentState2<Environment2<TAgent, TState>, TAgent, TState>
    {
        public Environment2(Random random, int width, int height) : base(random, width, height)
        {
        }

        protected override EnvironmentField<Environment2<TAgent, TState>, TAgent, TState, AgentInteraction<TAgent, Action2>> CreateField(int x, int y)
        {
            return new EnvironmentField<Environment2<TAgent, TState>, TAgent, TState, AgentInteraction<TAgent, Action2>>(this, x, y);
        }

        protected override AgentInteraction<TAgent, Action2> CreateInteraction(TAgent agent)
        {
            return new AgentInteraction<TAgent, Action2>(agent);
        }
    }
}
