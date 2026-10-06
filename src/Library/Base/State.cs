using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Ucu.Poo.Fsm
{
    public class State
    {
        private List<Transition> transitions = new List<Transition>();

        public ReadOnlyCollection<Transition> Transitions
        {
            get
            {
                return this.transitions.AsReadOnly<Transition>();
            }
        }

        public void AddTransition(Input triggerInput, State nextState)
        {
            Transition transition = new Transition(triggerInput, nextState);
            transitions.Add(transition);
        }

        public State GetNextState(Input input)
        {
            foreach (Transition item in this.transitions)
            {
                if (item.IsTriggeredBy(input))
                {
                    return item.NextState;
                }
            }

            return null;
        }

        public void OnEnter()
        {
        }

        public void OnExit()
        {
        }
    }
}