using System;
using System.Collections.Generic;
using System.Linq;

namespace Ucu.Poo.Fsm
{
    public class StateMachine
    {
        private Dictionary<Type, State> states = new Dictionary<Type, State>();

        public IReadOnlyCollection<State> States
        {
            get
            {
                return this.states.Values.ToList<State>().AsReadOnly();
            }
        }

        public State CurrentState { get; private set; }

        public StateMachine(State firstState)
        {
            this.CurrentState = firstState;
            states.Add(firstState.GetType(), firstState);
        }

        public void AddState(State state)
        {
            if (!this.states.ContainsKey(state.GetType()))
            {
                this.states.Add(state.GetType(), state);
            }
        }

        public bool ProcessInput(Input input)
        {
            State nextState = this.CurrentState.GetNextState(input);
            if (nextState == null)
            {
                return false;
            }

            this.CurrentState.OnExit();
            this.CurrentState = nextState;
            this.CurrentState.OnEnter();
            return true;
        }

        public bool ProcessInputs(Input[] inputs)
        {
            foreach (Input input in inputs)
            {
                State nextState = this.CurrentState.GetNextState(input);
                if (nextState == null)
                {
                    return false;
                }

                this.CurrentState.OnExit();
                this.CurrentState = nextState;
                this.CurrentState.OnEnter();
            }

            return true;
        }
    }
}