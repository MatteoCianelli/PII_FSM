//------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//------------------------------------------------------------------------------

using Ucu.Poo.Fsm;
using System;

namespace Ucu.Poo.Fsm
{
    /// <summary>
    /// El programa principal.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Punto de entrada al programa principal.
        /// </summary>
        public static void Main()
        {
            // Crea un reproductor de música, una secuencia de entradas y
            // procesa esas entradas con el reproductor de música.
            MusicPlayer musicPlayer = new MusicPlayer();

            // Inputs
            Play play = new Play();
            Pause pause = new Pause();
            Stop stop = new Stop();

            musicPlayer.ProcessInput(play);
            Console.WriteLine(musicPlayer.CurrentState.GetType() == typeof(Playing));
            musicPlayer.ProcessInput(stop);
            Console.WriteLine(musicPlayer.CurrentState.GetType() == typeof(Stopped));

            Input[] inputs = new Input[]
            {
                new Play(),
                new Pause(),
                new Play(),
                new Stop()
            };

            musicPlayer.ProcessInputs(inputs);
            Console.WriteLine(musicPlayer.CurrentState.GetType() == typeof(Stopped));
        }
    }
}
