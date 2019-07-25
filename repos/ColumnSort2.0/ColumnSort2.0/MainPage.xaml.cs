using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using RobotOM;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ColumnSort2._0
{
    
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            GetCases();
        }

        public void GetCases()
        {

            RobotApplication robapp = new RobotApplication();

            if (robapp == null)
            {
                return;
            }


            IRobotCaseCollection robotCaseCollection = robapp.Project.Structure.Cases.GetAll();
            List<string> cases = new List<string>();
            int ULSCase = -1;
            IRobotCase robotCase = robapp.Project.Structure.Cases.Get(1);
            for (int i = 0; i < robotCaseCollection.Count; i++)
            {

                try
                {
                    robapp.Project.Structure.Cases.Get(i);
                    robotCase = robapp.Project.Structure.Cases.Get(i);
                }
                catch (Exception)
                {
                    continue;
                    throw new Exception("Case Collection error");
                }
                finally
                {
                    robapp = null;
                }



                if (robotCase != null)
                {
                    cases.Add(robotCase.Name);
                    TextBlock.Text += robotCase.Name;
                    if (robotCase.Name == "ULS")
                    {
                        ULSCase = i - 1;
                    }
                }
            }

            listBox1.ItemsSource = cases;
            listBox1.SelectedIndex = ULSCase;

            if (listBox1.SelectedIndex == -1)
            {
                listBox1.SelectedIndex = 0;
            }


            robapp = null;
        }
    }
}
