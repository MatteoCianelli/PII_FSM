namespace Ucu.Poo.Fsm
{
    public class Transition
    {
        public State NextState { get; private set; }

        public Input TriggerInput { get; private set; }

        public Transition(Input triggerInput, State nextState)
        {
            this.NextState = nextState;
            this.TriggerInput = triggerInput;
        }

        public bool IsTriggeredBy(Input input)
        {
            return input.GetType() == this.TriggerInput.GetType();
        }
    }
}