using System;
using System.Reflection;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.Windows.Media;
using System.Drawing.Imaging;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;
using System.Collections.Generic;
using System.Linq;

namespace RevitRibbonHelloWorld
{
    public class Class1 : IExternalApplication
    {
        // Both OnStartup and OnShutdown must be implemented as public method
        public Result OnStartup(UIControlledApplication application)
        {
            // Add a new ribbon panel
            RibbonPanel ribbonPanel = application.CreateRibbonPanel("Design2e Extensions");

            // Create a push button to trigger a command add it to the ribbon panel.
            string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;
            PushButtonData buttonData = new PushButtonData("cmdViewCleaner",
               "View Cleaner", thisAssemblyPath, "RevitRibbonHelloWorld.HelloWorld");

            PushButton pushButton = ribbonPanel.AddItem(buttonData) as PushButton;
            
            // Optionally, other properties may be assigned to the button
            // a) tool-tip
            pushButton.ToolTip = "Clean out the views that are not called 'Project Info'.";
            //pushButton.ToolTipImage = new BitmapImage(new Uri(@"C:\ProgramData\Autodesk\Revit\Addins\2019\scalpel_16.png"));
            
            // b) large bitmap
            pushButton.LargeImage = new BitmapImage(new Uri(@"C:\ProgramData\Autodesk\Revit\Addins\2019\scalpel_16.png"));

            return Result.Succeeded;
        }
        public Result OnShutdown(UIControlledApplication application)
        {
            // nothing to clean up in this simple case
            return Result.Succeeded;
        }

    }
    /// <remarks>
    /// The "HelloWorld" external command. The class must be Public.
    /// </remarks>
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class HelloWorld : IExternalCommand
    {
        // The main Execute method (inherited from IExternalCommand) must be public
        public Autodesk.Revit.UI.Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //Connect to revit
            UIApplication uiapp = commandData.Application;
            Application application = uiapp.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            string currentSection = "Hasn't started running yet";

            try
            {
                TaskDialog.Show("Revit", Method());
            }
            catch(Exception e)
            {
                //Show error
                TaskDialog.Show($"Error, at {currentSection}:", e.Message);
                return Result.Failed;
            }
            return Result.Succeeded;

            //---------------------------------------------------------------------------------------------------------
            string Method()
            {
                FilteredElementCollector viewcollector = new FilteredElementCollector(doc);
                ICollection<Element> viewcollection = viewcollector.OfClass(typeof(ViewPlan)).ToElements();
                string levels = "";
                
                View active = uidoc.ActiveView;
                ElementId levelId = null;
                uidoc.RequestViewChange();
                Parameter level = active.LookupParameter("Associated Level");

                levels = level.AsString();

                return levels;
            }

            void ShowResults()
            {
                TaskDialog.Show("Revit", "Hello World");
            }
        }

    }
}

