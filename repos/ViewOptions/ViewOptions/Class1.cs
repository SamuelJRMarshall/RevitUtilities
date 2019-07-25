using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

namespace ViewOptions
{
    //Made by Sam.
    [Transaction(TransactionMode.Manual)]

    public class Class1 : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //Get application and document objects
            UIApplication uiapp = commandData.Application;
            Application application = uiapp.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            string currentSection = "Hasn't started running yet";

            try
            {
                SaveAs();
                Deleting();
                //Save();
            }

            catch(Exception e)
            {
                TaskDialog.Show($"Error, at {currentSection}:", e.Message);
                return Result.Failed;
            }

            return Result.Succeeded;

            void SaveAs()
            {
                //Get information of current opened revit file
                ModelPath revitCentralFile = ModelPathUtils.ConvertUserVisiblePathToModelPath(doc.PathName);

                //Open the model detached from central
                OpenOptions openOptions = new OpenOptions();
                openOptions.DetachFromCentralOption = DetachFromCentralOption.DetachAndDiscardWorksets;


                //Close and open model again
                var placeholderFile = @"P:\Technical Documents\CSharp\Revit\Addins\Shared\View Cleaner\Test.rvt";
                var docPlaceholder = uiapp.OpenAndActivateDocument(placeholderFile);
                doc.Close(false);

                Document openedDoc = application.OpenDocumentFile(revitCentralFile, openOptions);
                string path = revitCentralFile.ToString();
                openedDoc.SaveAs(path);
                string newCentralFile = ModelPathUtils.ConvertUserVisiblePathToModelPath(openedDoc.PathName).ToString();
                openedDoc.Close(true);

                var docPlaceHolderAgain = uiapp.OpenAndActivateDocument(newCentralFile);
                docPlaceholder.Document.Close(false);

            }

            void Deleting()
            {
                doc = uiapp.ActiveUIDocument.Document;

                // Plan views
                currentSection = "Delete Plan Views";

                FilteredElementCollector viewCollector = new FilteredElementCollector(doc);
                ICollection<ElementId> collection = viewCollector.OfClass(typeof(ViewPlan)).ToElementIds();

                Transaction transaction = new Transaction(doc, currentSection);
                transaction.Start(currentSection);
                doc.Delete(collection);
                transaction.Commit();


                // Section views
                currentSection = "Delete Section Views";

                viewCollector = new FilteredElementCollector(doc);
                collection = viewCollector.OfClass(typeof(ViewSection)).ToElementIds();

                transaction.Start(currentSection);
                doc.Delete(collection);
                transaction.Commit();


                // Drafting views
                currentSection = "Delete Drafting Views";

                viewCollector = new FilteredElementCollector(doc);
                collection = viewCollector.OfClass(typeof(ViewDrafting)).ToElementIds();

                transaction.Start(currentSection);
                doc.Delete(collection);
                transaction.Commit();


                // Schedules views
                currentSection = "Delete Schedule Views";

                viewCollector = new FilteredElementCollector(doc);
                collection = viewCollector.OfClass(typeof(ViewSchedule)).ToElementIds();

                transaction.Start(currentSection);
                doc.Delete(collection);
                transaction.Commit();


                //-----------------------------------------------------------------------------------------------------
                // Get the Proj Info views

                // Sheet views
                currentSection = "Delete Sheets Views";

                collection.Clear();
                viewCollector = new FilteredElementCollector(doc);
                ICollection<Element> sheets = viewCollector.OfClass(typeof(ViewSheet)).ToElements();

                foreach (Element sheet in sheets)
                {
                    if (sheet.Name == "Project Info")
                    {

                    }
                    else
                    {
                        collection.Add(sheet.Id);
                    }
                }

                transaction.Start(currentSection);
                doc.Delete(collection);
                transaction.Commit();


                // 3D views
                currentSection = "Delete 3D Views";

                collection.Clear();
                viewCollector = new FilteredElementCollector(doc);
                ICollection<Element> threeDs = viewCollector.OfClass(typeof(View3D)).ToElements();

                foreach (Element threeD in threeDs)
                {
                    if (threeD.Name == "Project Info")
                    {

                    }
                    else
                    {
                        collection.Add(threeD.Id);
                    }
                }

                transaction.Start(currentSection);
                doc.Delete(collection);
                transaction.Commit();
            }

            void Save()
            {
                doc.Save();
            }
        }

        

       

    }

}
