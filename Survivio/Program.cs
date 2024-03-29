﻿using System;

namespace Survivio
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (SurvivioMain game = new SurvivioMain())
                game.Run();
        }
    }
#endif
}
