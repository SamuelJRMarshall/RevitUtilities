using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using RobotOM;


namespace ClassLibrary3
{
    [System.Runtime.InteropServices.ComVisibleAttribute(true), GuidAttribute("C966CD58-D144-49E6-801A-828CDD3DD44F")]
       public class Class1 : IRobotAddIn
    {
        
        private IRobotApplication iapp = null;
        public bool Connect(RobotApplication robot_app, int add_in_id, bool first_time)
        {
            iapp = robot_app;
            return true;
        }

        public bool Disconnect()
        {
            iapp = null;
            return true;
        }

        public void DoCommand(int cmd_id)
        {
           
            // or execute any of your command for eg    new Form1().Show();
        }

        public double GetExpectedVersion()
        {
            return 10;
        }

        public int InstallCommands(RobotCmdList cmd_list)
        {
            cmd_list.New(1, "My Command 1"); // Text in Robot menu
            return cmd_list.Count;
        }
    }

}
