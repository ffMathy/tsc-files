using System;
using System.Runtime.InteropServices.JavaScript;

using ScreepsDotNet.API.Arena;

namespace ScreepsDotNet
{
    public static partial class Program
    {
        private static IGame? game;

        public static void Main()
        {
            // Keep the entrypoint platform independent and let Init (which is called from js) create the game instance
            // This keeps the door open for unit testing later down the line
        }

        [JSExport]
        internal static void Init()
        {
            game = new Native.Arena.NativeGame();
        }

        [JSExport]
        internal static void Loop()
        {
            if (game == null) { return; }
            Console.WriteLine($"Hello world from C#, the current tick is {game.Utils.GetTicks()}");
        }
    }
}