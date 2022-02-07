using Urho;
using Urho.Gui;
using Urho.Resources;
using Urho.IO;
using System;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;

using System.Collections;

namespace Doom
{
    /// <summary>
    /// Actual game application to display a Menu of options and available SceneComponent
    /// </summary>
	public class Doom : GameApplication
    {
        ListView listView;

        bool isMobile = false;
        protected SceneComponent currentSample = null;
        Type[] samples;

        Dictionary<string, Type> samplesList = new Dictionary<string, Type>();

        public class TypeComparer : IComparer<Type>
        {
            public int Compare(Type x, Type y)
            {
                return (new CaseInsensitiveComparer()).Compare(x.ToString(), y.ToString());
            }
        }



        public Doom(ApplicationOptions options) : base(options) { }


        /// <summary>
        /// Initialize all engine objects here
        /// </summary>
        protected override void Start()
        {
            base.Start();

            Input.KeyDown += HandleKeyDown;

            isMobile = (Platform == Platforms.iOS || Platform == Platforms.Android);
            //
            // play a particular scene
            //
            currentSample = Activator.CreateInstance<DoomMap2D>();
            currentSample.Run();

            //CreateUI();

            //FindAvailableSamples();

            //PopulateSamplesList();
        }


        void CreateUI()
        {
            //
            // get the default style sheet for GUI
            //
            XmlFile uiStyle = ResourceCache.GetXmlFile("UI/DefaultStyle.xml");
            //
            // Set style to the UI root so that elements will inherit it
            //
            UI.Root.SetDefaultStyle(uiStyle);
            //
            // list of availabe options
            //
            listView = UI.Root.CreateChild<ListView>(new StringHash("ListView"));
            listView.SetAlignment(HorizontalAlignment.Center, VerticalAlignment.Center);
            listView.Size = new IntVector2(Graphics.Width/2, Graphics.Height);
            listView.SetStyleAuto();
            listView.SetFocus(true);
            Input.SetMouseVisible(true);

            UI.Root.Resized += OnUIResized;

        }

        private void OnUIResized(ResizedEventArgs obj)
        {
            listView.Size = new IntVector2(Graphics.Width/2, Graphics.Height);
        }

        string ExtractSampleName(Type sample)
        {
            return sample.ToString().Split('.')[1];
        }
        void FindAvailableSamples()
        {
            //
            // Find all Scenes (type of SceneComponent) in the bin folder
            //
            samples = typeof(SceneComponent).Assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(SceneComponent)) && t != typeof(SceneComponent)).ToArray();

            Array.Sort(samples, new TypeComparer());

            foreach (var sample in samples)
            {
                string SampleName = ExtractSampleName(sample);

                if (isMobile && SampleName == "PBRMaterials") // PBRMaterials doesn't work well on mobiles
                    continue;

                samplesList[SampleName] = sample;
            }

        }

        void PopulateSamplesList()
        {

        }

        void ListAddSceneEntry(string name)
        {
            Button button = new Button();
            button.MinHeight = 80;
            button.SetStyleAuto();
            button.Name = name;

            button.Released += OnEntrySelected;

            var title = button.CreateChild<Text>(new StringHash("Text"));
            title.SetAlignment(HorizontalAlignment.Center, VerticalAlignment.Center);
            title.Value = name;
            title.SetFont(ResourceCache.GetFont("Fonts/Anonymous Pro.ttf"), 40);

            listView.AddItem(button);
        }

        private void OnEntrySelected(ReleasedEventArgs obj)
        {
            Button button = obj.Element as Button;
            string name = button?.Name;
            switch (name)
            {
                case "Play":
                    //
                    // play the first scene in the list
                    //
                    var junk = samplesList.First();
                    if (junk.Key != null)
                    {
                        name = junk.Key;
                        currentSample = (SceneComponent)Activator.CreateInstance(samplesList[name]);
                    }
                    else
                        return;

                    break;
                case "Options":
                    return;
                  
                case "Exit":
                    Exit();
                    return;
            }
            //
            // Not the first 3 entries
            //
            currentSample = (SceneComponent)Activator.CreateInstance(samplesList[name]);

            if (currentSample != null)
            {
                UI.Root.RemoveChild(listView);
                listView = null;
                UI.Root.Resized -= OnUIResized;
                Input.SetMouseVisible(false);
                Input.SetMouseMode(MouseMode.Relative);
                currentSample.RequestToExit += SampleRequetedToExit;
                currentSample.Run();
                //currentSample.backButton.Released += OnBackButtonReleased;
                //currentSample.infoButton.Released += OnInfoButttonReleased;
                Graphics.WindowTitle = name;
            }

        }

        private void SampleRequetedToExit()
        {
            ExitSample();
        }

        private void OnInfoButttonReleased(ReleasedEventArgs obj)
        {
            currentSample.ToggleInfo();
        }

        private void OnBackButtonReleased(ReleasedEventArgs obj)
        {
            ExitSample();
        }

        void ExitSample()
        {
            Exit();
            //if (currentSample != null)
            //{
            //    //currentSample.backButton.Released -= OnBackButtonReleased;
            //    //currentSample.infoButton.Released -= OnInfoButttonReleased;
            //    currentSample.RequestToExit -= SampleRequetedToExit;
            //    currentSample.Exit();
            //    currentSample.UnSubscribeFromAllEvents();
            //    currentSample.Dispose();
            //    currentSample = null;
            //    UI.Root.RemoveAllChildren();
            //    CreateUI();
            //    PopulateSamplesList();
            //    Graphics.WindowTitle = "Urho.Net Samples";
            //    Input.SetMouseVisible(true);
            //}
        }
        void HandleKeyDown(KeyDownEventArgs e)
        {

            switch (e.Key)
            {
                case Key.Esc:
                    if (currentSample != null)
                    {
                        ExitSample();
                    }
                    else
                    {
                        Exit();
                    }
                    return;
            }
        }
    }
}
