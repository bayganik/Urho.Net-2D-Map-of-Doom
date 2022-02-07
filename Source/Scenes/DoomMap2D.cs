using System;
using Urho;
using System.Collections.Generic;
using Urho.Urho2D;
using mmDoomLib;

namespace Doom
{
    /*
     * Example of using 2D sprites & animations
     * Simple 2D camera is added
     * use PageUp/PageDown to Zoom in/out
     */
    public class DoomMap2D : SceneComponent
    {
        Map myMap;
        World myWorld;
        GameOptions myOptions;
        List<NodeInfo> spriteNodes;
        GameContent content;
        CustomGeometry geom;

        const uint NumSprites = 200;

        [Preserve]
        public DoomMap2D() : base(new ApplicationOptions(assetsFolder: "Data;CoreData")) { }

        protected override void Start()
        {
            base.IsLogoVisible = false;
            base.Start();

            string WadLoc = AppDomain.CurrentDomain.BaseDirectory + @"Data\Wad\doom2.wad";

            content = GameContent.CreateDummy(WadLoc);
            myOptions = new GameOptions();
            myOptions.Map = 1;                //start with MAP01
            myWorld = new World(content, myOptions);
            myMap =   new Map(content, myWorld);
            
            CreateScene();

            
            SetupViewport();
            SubscribeToEvents();
        }
        private void PostRenderUpdate(PostRenderUpdateEventArgs e)
        {
            // this requires that you have already added a DebugRenderer
            // component in your scene object
            var debugRenderer = MyScene.GetComponent<DebugRenderer>();
            //
            // another way of doing this as a debug, but this will happen every frame,
            // use the DrawMap() method to define the Geometry and be done
            //
            //float offsetX = 200f;
            //float offsetY = 200f;
            //int scale = 30;
            if (debugRenderer != null)
            {
                //
                // Take the line definitions and draw a 2D map (top view)
                //
                //foreach (LineDef ld in myMap.Lines)
                //{
                //    var upperBound = new Vector3(ld.Vertex1.X.ToFloat() / scale + offsetX,
                //                                 ld.Vertex1.Y.ToFloat() / scale + offsetY,
                //                                 0.0f);
                //    var lowerBound = new Vector3(ld.Vertex2.X.ToFloat() / scale + offsetX,
                //                                 ld.Vertex2.Y.ToFloat() / scale + offsetY,
                //                                 0.0f);

                //    debugRenderer.AddLine(upperBound, lowerBound, Color.White, false);
                //}
            }
        }
        protected override void Stop()
        {
            UnSubscribeFromEvents();
            base.Stop();
        }

        void SubscribeToEvents()
        {
            this.Engine.PostRenderUpdate += PostRenderUpdate;
        }

        void UnSubscribeFromEvents()
        {
            this.Engine.PostRenderUpdate -= PostRenderUpdate;
        }

        protected override void OnUpdate(float timeStep)
        {
            base.OnUpdate(timeStep);

            float halfWidth = Graphics.Width * 0.5f * Application.PixelSize;
            float halfHeight = Graphics.Height * 0.5f * Application.PixelSize;
        }
        void CreateScene()
        {
            spriteNodes = new List<NodeInfo>();
            MyScene.CreateComponent<DebugRenderer>();
            //
            // Setup the camera
            //
            CameraNode.Position = (new Vector3(155.0f, 276.0f, -200.0f));
            Camera.Orthographic = false;

            //Camera.OrthoSize = (float)Graphics.Height * Application.PixelSize;

            //// Get sprite
            //Sprite2D sprite = ResourceCache.GetSprite2D("Urho2D/Aster.png");
            //if (sprite == null)
            //    return;

            float halfWidth = Graphics.Width * 0.5f * Application.PixelSize;
            float halfHeight = Graphics.Height * 0.5f * Application.PixelSize;


            //
            // Add camera controller system
            //
            AddNodeProcessing(new Camera2DSimpleMoveSystem(this, "camera"));

            Urho.Node node = MyScene.CreateChild("DoomMap");
            geom = node.CreateComponent<CustomGeometry>();
            //
            // Draw 2D of map
            //
            DrawMap();

        }
        //
        // override the key input process so 0-9 means something different
        //
        public override void HandleKeyDown(KeyDownEventArgs e)
        {
            bool mapRedraw = false;
            switch (e.Key)
            {
                case Key.N1:
                    myOptions.Map = 1;                //MAP01
                    myWorld = new World(content, myOptions);
                    myMap = new Map(content, myWorld);
                    mapRedraw = true;
                    break;

                case Key.N2:
                    myOptions.Map = 2;                //MAP02
                    myWorld = new World(content, myOptions);
                    myMap = new Map(content, myWorld);
                    mapRedraw = true;
                    break;
                case Key.N3:
                    myOptions.Map = 3;                //MAP03
                    myWorld = new World(content, myOptions);
                    myMap = new Map(content, myWorld);
                    mapRedraw = true;
                    break;

                case Key.N4:
                    myOptions.Map = 4;                //MAP04
                    myWorld = new World(content, myOptions);
                    myMap = new Map(content, myWorld);
                    mapRedraw = true;
                    break;

                case Key.N5:
                    myOptions.Map = 5;                //MAP05
                    myWorld = new World(content, myOptions);
                    myMap = new Map(content, myWorld);
                    mapRedraw = true;
                    break;

                case Key.N6:
                    myOptions.Map = 6;                //MAP06
                    myWorld = new World(content, myOptions);
                    myMap = new Map(content, myWorld);
                    mapRedraw = true;
                    break;

                case Key.N7:
                    myOptions.Map = 7;                //MAP07
                    myWorld = new World(content, myOptions);
                    myMap = new Map(content, myWorld);
                    mapRedraw = true;
                    break;

                case Key.N8:
                    myOptions.Map = 8;                //MAP08
                    myWorld = new World(content, myOptions);
                    myMap = new Map(content, myWorld);
                    mapRedraw = true;
                    break;

                case Key.N9:
                    myOptions.Map = 9;                //MAP09
                    myWorld = new World(content, myOptions);
                    myMap = new Map(content, myWorld);
                    mapRedraw = true;
                    break;

                case Key.N0:
                    myOptions.Map = 10;                //MAP10
                    myWorld = new World(content, myOptions);
                    myMap = new Map(content, myWorld);
                    mapRedraw = true;
                    break;
            }
            if (mapRedraw)
                DrawMap();
        }
        private void DrawMap()
        {
            float offsetX = 200f;
            float offsetY = 200f;
            int scale = 20;
            float size = 2;
            //
            // disp the map name and instruction
            //
            SimpleCreateInstructionsWithWasd("PageUp (Zoom in) PageDown (Zoom out)." + "\n" + myMap.Title + 
                "\n" + "0-9 to see maps.");

            geom.BeginGeometry(0, PrimitiveType.LineList);
            var material = new Material();
            material.SetTechnique(0, CoreAssets.Techniques.NoTextureUnlitVCol, MaterialQuality.Low, 1);
            geom.SetMaterial(material);
            //
            // LineDef coordinants
            //
            foreach (LineDef ldef in myMap.Lines)
            {
                //
                // Start of line
                //
                geom.DefineVertex(new Vector3(ldef.Vertex1.X.ToFloat() / scale + offsetX,
                                             ldef.Vertex1.Y.ToFloat() / scale + offsetY,
                                             0.0f));
                geom.DefineColor(Color.White);
                //
                // End point of line
                //
                geom.DefineVertex(new Vector3(ldef.Vertex2.X.ToFloat() / scale + offsetX,
                                             ldef.Vertex2.Y.ToFloat() / scale + offsetY,
                                             0.0f));
                geom.DefineColor(Color.White);

            }
            geom.Commit();
        }
        protected override string JoystickLayoutPatch => JoystickLayoutPatches.WithZoomInAndOut;

        class NodeInfo
        {
            public Urho.Node Node { get; set; }
            public Vector3 MoveSpeed { get; set; }
            public float RotateSpeed { get; set; }

            public NodeInfo(Urho.Node node, Vector3 moveSpeed, float rotateSpeed)
            {
                Node = node;
                MoveSpeed = moveSpeed;
                RotateSpeed = rotateSpeed;
            }
        }
    }
}