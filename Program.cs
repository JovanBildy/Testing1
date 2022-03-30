using System;
using LearnOpenTK.Common;
using OpenTK.Windowing.Desktop;

namespace Pertemuan1
{
    class Program
    {
        static void Main(string[] args)
        {
            var nativeWindowSettings = new NativeWindowSettings()
            {
                Size = new OpenTK.Mathematics.Vector2i(800,800),
                Title = "Pertemuan 2"
            };

            using(var window =  new Window(GameWindowSettings.Default,nativeWindowSettings))

            {
                window.Run();

            }
        }
    }
}
