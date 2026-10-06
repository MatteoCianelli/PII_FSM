namespace Ucu.Poo.Fsm
{
    public class MusicPlayer : StateMachine
    {
        public MusicPlayer()
        : base(new Stopped())
        {
            Playing playing = new Playing();
            this.AddState(playing);
            Paused paused = new Paused();
            this.AddState(paused);

            Play play = new Play();
            Pause pause = new Pause();
            Stop stop = new Stop();

            this.CurrentState.AddTransition(play, playing);
            playing.AddTransition(pause, paused);
            playing.AddTransition(stop, this.CurrentState);
            paused.AddTransition(play, playing);
            paused.AddTransition(stop, this.CurrentState);
        }
    }
}