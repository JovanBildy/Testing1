using OpenTK.Windowing.Desktop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearnOpenTK.Common;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Mathematics;

namespace Pertemuan1
{
    static class Constants
    {
        public const string path = "../../../Shaders/";
    }
    internal class Window : GameWindow
    {
        //Asset2d[] _object = new Asset2d[5];
       
        //List<Assetd3d> objectlist = new List<Assetd3d>();



        //float[] vertices =
        //{
        ////position         //colors
        // -0.5f,-0.5f,0.0f, 1.0f,0.0f,0.0f, //-> vertex 1,merah
        // 0.5f,-0.5f,0.0f,  0.0f,1.0f,0.0f,  //-> vertex 2,hijau
        // 0.0f,0.5f,0.0f,   0.0f,0.0f,1.0f //-> vertex 3,biru
        //};


        //float[] vertices =
        //{
        //    0.5f,0.5f,0.0f,//top right
        //    0.5f,-0.5f,0.0f,//bottom right
        //    -0.5f,-0.5f,0.0f,//bottom left
        //    -0.5f,0.5f,0.0f//top left
        //};

        // Obj 3D
        List<Assetd3d> objectList = new List<Assetd3d>();
        double _time;
        float degr = 0;


        public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
        {

        }

        protected override void OnLoad()
        {
            base.OnLoad();
            //Ganti Background warna
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
            //  _object[0] = new Asset2d(
            //      new float[]
            //      {
            //          -0.75f,0.0f,0.0f,
            //          -0.5f,0.5f,0.0f,
            //          -0.25f,0.0f,0.0f
            //      },
            //      new uint[]
            //      {

            //      }
            //  );
            //  _object[1] = new Asset2d(
            //     new float[]
            //     {
            //          0.75f,0.0f,0.0f,
            //          0.5f,0.5f,0.0f,
            //          0.25f,0.0f,0.0f
            //     },
            //     new uint[]
            //     {

            //     }
            // );
            //  _object[2] = new Asset2d(
            //    new float[]
            //    {

            //    },
            //    new uint[]
            //    {

            //    }

            // );
            //  _object[3] = new Asset2d(
            //      new float[1080],

            //      new uint[]
            //      {

            //      }

            //   );
            //  _object[4] = new Asset2d(
            //   new float[]
            //   {

            //   },
            //   new uint[]
            //   {

            //   }

            //);


            //  _object[0].load(Constants.path + "shader.vert", Constants.path + "shader.frag");
            //  _object[1].load(Constants.path + "shader.vert", Constants.path + "shader.frag");
            //  //_object[2].createCircle(0.0f, -0.5f, 0.25f);
            //  _object[2].createEllips(0.0f, -0.5f, 0.25f, 0.5f);
            //  _object[2].load(Constants.path + "shader.vert", Constants.path + "shader.frag");
            //  _object[3].load(Constants.path + "shader.vert", Constants.path + "shader.frag");

            //var ellipsoid1 = new Assetd3d(new OpenTK.Mathematics.Vector3(0, 0.5f, 1));
            //ellipsoid1.createEllipsoid(0, 0, 0, 0.4f, 0.4f, 0.4f);
            //objectlist.Add(ellipsoid1);

            //foreach (Assetd3d i in objectlist)
            //{
            //    i.load();
            //}

            var box = new Assetd3d(new Vector3(1, 1, 0));
            box.createBoxVertices(0, 0, 0, 0.5f);
            objectList.Add(box);

            foreach (Assetd3d i in objectList)
            {
                i.load(Constants.path + "shader.vert", Constants.path + "shader.frag", Size.X, Size.Y);
            }
        }

        //_object3d[0] = new Assetd3d();
        //_object3d[0].createBoxVertices(0, 0, 0, 0.5f);
        //_object3d[0].load(Constants.path + "shader.vert", Constants.path + "shader.frag");

    


        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            //_object[0].render(0);
            //_object[1].render(0);
            //_object[2].render(1);

            //if (_object[3].getVerticesLength())
            //{
            //    List<float> _verticesTemp = _object[3].createCurvedBezier();
            //    _object[4].setvertices(_verticesTemp.ToArray());
            //    _object[4].load(Constants.path + "shader.vert", Constants.path + "shader.frag");
            //    _object[4].render(3);
            //}
            //_object[3].render(2);

            _time += 100.0 * args.Time;
            Matrix4 temp = Matrix4.Identity;
            //degr += MathHelper.DegreesToRadians(0.05f);
            //temp = temp * Matrix4.CreateRotationX(degr);
            //temp = temp * Matrix4.CreateRotationY(degr);

            foreach (Assetd3d i in objectList)
            {
                i.render(3, _time, temp);
            }

            SwapBuffers();
        }

        //Agar gambar bisa tetap ditengah ketika windownya di resize
        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);
            Console.WriteLine("Ini Resize");
            GL.Viewport(0, 0, Size.X, Size.Y);
        }

        //Untuk mengecek apakah menerima inputan dari keyboard atau tidak
        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);

            var input = KeyboardState;
            var mouse_input = MouseState;

            
            if(input.IsKeyDown(Keys.Escape))
            {
                Close();
            }
            if(input.IsKeyReleased(Keys.A))
            {
                Console.WriteLine("Keyboard A sudah tidak ditekan");
            }
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);
            if(e.Button == MouseButton.Left)
            {
                float _x = (MousePosition.X - Size.X/2)/(Size.X/2);
                float _y = -(MousePosition.Y - Size.Y/2)/(Size.Y/2);

                Console.Write("x = " + _x + "y = " + _y);
                //_object[3].updateMousePosition(_x, _y);

            }
        }
    }
}
