//Texture Rectangle
using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.DirectX; 
using Microsoft.DirectX.Direct3D;


namespace TexturedRectangle

{
    public partial class Form1 : Form
    {
        Microsoft.DirectX.Direct3D.Device device;
        private CustomVertex.PositionTextured[] vertexes = new CustomVertex.PositionTextured[6];
        private Texture texture;
        public Form1()
        {
            InitializeComponent();
            InitDevice();
        }
        public void InitDevice() 
        {

            PresentParameters pp = new PresentParameters();
            pp.Windowed = true; pp.SwapEffect = SwapEffect.Discard;
            device = new Microsoft.DirectX.Direct3D.Device(0, DeviceType.Hardware, this,CreateFlags.HardwareVertexProcessing, pp);
            device.Transform.Projection = Matrix.PerspectiveFovLH(3.14f /4,device.Viewport.Width / device.Viewport.Height, 1f, 1000f);
            device.Transform.View = Matrix.LookAtLH(new Vector3(0, 0, 20), new Vector3(), new Vector3(0, 1, 0));
            device.RenderState.Lighting = false;



           
                                           
            vertexes[0] = new CustomVertex.PositionTextured(new Vector3(0, 2, 1), 0, 0);
            vertexes[1] = new CustomVertex.PositionTextured(new Vector3(0, -2, 1), 0, 1);
            vertexes[2] = new CustomVertex.PositionTextured(new Vector3(2, -2, 1), -1, 1);
            


            vertexes[3] = new CustomVertex.PositionTextured(new Vector3(2, -2, 1), 0, 0);
            vertexes[4] = new CustomVertex.PositionTextured(new Vector3(2, 2, 1), 0, 1);
            vertexes[5] = new CustomVertex.PositionTextured(new Vector3(0, 2, 1), -1, 1);


            texture = new Texture(device, new Bitmap("C:\\Users\\Inane\\OneDrive\\Desktop\\College\\GP\\Texture_2.png"), 0,Pool.Managed);


           
        }
        private void Form1_Load(object sender, EventArgs e) {}
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            MessageBox.Show("paint");
            device.Clear(ClearFlags.Target, Color.Cyan, 1.0f, 0);
            device.BeginScene();
            device.SetTexture(0, texture);
            device.VertexFormat = CustomVertex.PositionTextured.Format;
            device.DrawUserPrimitives(PrimitiveType.TriangleList, vertexes.Length / 3, vertexes);
            device.EndScene();
            device.Present();
        }

    }
}
