using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RobotOM;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace ColumnSort3._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

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
            int ULSCase = -1;
            for (int i = 0; i < robotCaseCollection.Count; i++)
            {
                try
                {
                    IRobotCase robotCase = robapp.Project.Structure.Cases.Get(i);
                    if (robotCase != null)
                    {
                        listBox1.Items.Add(robotCase.Name);
                        if (robotCase.Name == "ULS")
                        {
                            ULSCase = i - 1;
                        }
                    }
                }
                catch(Exception e)
                {

                }
                    
                
            }

            listBox1.SelectedIndex = ULSCase;

            robapp = null;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
