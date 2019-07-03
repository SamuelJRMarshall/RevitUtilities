/*
 * Created by SharpDevelop.
 * User: Sam Marshall
 * Date: 03/07/2019
 * Time: 12:15
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using System.Collections.Generic;
using System.Linq;

namespace RevitUtilities
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.DB.Macros.AddInId("DCB72A6D-CBFB-40DD-8AA7-28596A1C73CB")]
	public partial class ThisApplication
	{
		private void Module_Startup(object sender, EventArgs e)
		{

		}

		private void Module_Shutdown(object sender, EventArgs e)
		{

		}

		#region Revit Macros generated code
		private void InternalStartup()
		{
			this.Startup += new System.EventHandler(Module_Startup);
			this.Shutdown += new System.EventHandler(Module_Shutdown);
		}
		#endregion
		
		public void ViewMash()
		{
			TaskDialog.Show("helloworld", "good morning");
		}
		public void SamsMethod()
		{
			TaskDialog.Show("Message", "This works");
		}
		
		public void ViewList()
		{
			UIDocument uidoc = this.ActiveUIDocument;
			Document doc = uidoc.Document;
			FilteredElementCollector viewCollector = new FilteredElementCollector(doc);
			ICollection<ElementId> collectedViews = viewCollector.OfClass(typeof(ViewPlan)).ToElementIds();
			
			string viewList = "";
            int a = 0;
            	
            foreach (ElementId eId in collectedViews)
            {
            	ViewPlan view = doc.GetElement(eId) as ViewPlan;
            	string viewType = view.ViewType.ToString();
        		Element viewE = doc.GetElement(eId);
        		
            	if (view.Name != "" && view.GenLevel != null && ViewType.Equals(view.ViewType, ViewType.FloorPlan)  )
            	{
            		
            		
            		viewList += view.Name.ToString() + " " + view.GenLevel.Name.ToString() + " "
            	 + " " + viewType + Environment.NewLine;
            		a++;
            	}
            }
            
            TaskDialog.Show("ViewsInModel",viewList);
		}
		
		public void Test(){
			
			try
            {
                
                UIDocument uidoc = this.ActiveUIDocument;
				Document doc = uidoc.Document;
				Transaction transaction = new Transaction(doc, "Duplicate FamilyTemplate");
	            transaction.Start("Duplicate FamilyTemplate");
				FilteredElementCollector a = new FilteredElementCollector(doc).OfClass(typeof(ViewFamilyType));
				ViewFamilyType old_v = a.FirstOrDefault<Element>(e => e.Name.Equals("test")) as ViewFamilyType;
				ViewFamilyType new_v  = old_v.Duplicate("asdasd") as ViewFamilyType;
				ICollection<ElementId> delIds = doc.Delete(old_v.Id);
	            transaction.Commit();
                
            }

            catch(Exception e)
            {
                TaskDialog.Show("Error", e.Message);
                
            }

           
		}
		
		
		public void Test2(){
			UIDocument uidoc = this.ActiveUIDocument;
			Document doc = uidoc.Document;
			
			FilteredElementCollector viewCollector = new FilteredElementCollector(doc);
			ICollection<ElementId> collectedViews = viewCollector.OfClass(typeof(ViewPlan)).ToElementIds();
			string viewList = "";
			foreach (ElementId elId in collectedViews) {
				Element el = doc.GetElement(elId);
				if(el.Name != "" && el.GetTypeId().IntegerValue > 0){
		        	ViewFamilyType vft = el as ViewFamilyType;
		        	
		        	viewList += el.Name.ToString() + " "+ vft.FamilyName.ToString() +  Environment.NewLine;
				}
			}
			
			TaskDialog.Show("Gentle Screaming",viewList);
		
		}
		
		public void Test3(){
			UIDocument uidoc = this.ActiveUIDocument;
			Document doc = uidoc.Document;
			
			FilteredElementCollector b = new FilteredElementCollector(doc).OfClass(typeof(ViewPlan));
			FilteredElementCollector a = new FilteredElementCollector(doc).OfClass(typeof(ViewFamilyType));
			String asd = "";
			String asdsa = "";
			foreach (ViewPlan ele in b) {
				
				foreach (ViewFamilyType elef in a) {
					asd = elef.get_Parameter(BuiltInParameter.VIEW_TEMPLATE).AsString();
					asdsa = ele.get_Parameter(BuiltInParameter.ELEM_FAMILY_PARAM).AsString();
				}
					
			}
			
			TaskDialog.Show("Gentle Screaming",asd);
				
		}
		
		public void FindElements(){
			Document doc = this.ActiveUIDocument.Document;
			string info = "";
			FilteredElementCollector E = new FilteredElementCollector(doc).OfClass(typeof(ViewPlan));
			//Element e = E.FirstOrDefault<Element>();
			foreach (Element e in E) {
				

				if(e != null){
				FamilyInstance fi = e as FamilyInstance;
				FamilySymbol fs = fi.Symbol;
				Family family = fs.Family;
				info += family.Name + ": " + fs.Name + ": " + fi.Name + Environment.NewLine;
				}
			}
			TaskDialog.Show("Hello",info);
		}
		
		
		
		public void AllFamilyViewTypes(){
			
			try
            {
				List<String> names = new List<String>();
                Document doc = this.ActiveUIDocument.Document;
				FilteredElementCollector a = new FilteredElementCollector(doc).OfClass(typeof(ViewFamilyType));
				FilteredElementCollector b = new FilteredElementCollector(doc).OfClass(typeof(View));
				
				String allNames = "";
				foreach (ViewFamilyType c in a) {
					names.Add(c.Name.ToString());
					
				}
				
				foreach (View c in b) {
					//c.
				}
				
				foreach (var foo in names) {
					ViewFamilyType old_v = a.FirstOrDefault<Element>(e => e.Name.Equals(foo.ToString())) as ViewFamilyType;
					
					
					 
					
				}
				
				//ViewFamilyType new_v  = old_v.Duplicate("asdasd") as ViewFamilyType;
				
                
                TaskDialog.Show("Hello",allNames);
		
            }

            catch(Exception e)
            {
                TaskDialog.Show("Error", e.Message);
                
            }

           
		}
		
		public void Testing(){
			Document doc = this.ActiveUIDocument.Document;
			ICollection<Element> b = new FilteredElementCollector(doc).OfClass(typeof(View)).ToElements() ;
			String allNames = "";
			foreach (var a in b) {
				ElementId id = a.GetTypeId();
				if(id.IntegerValue > 0){
 				ElementType type = doc.GetElement( id ) as ElementType;
 				allNames += type.Name+ " " + a.Name + " " + type.FamilyName + Environment.NewLine;
				}
			} 
			TaskDialog.Show("Hello",allNames);
		}
		
		public void GetViewInformation(){
			Document doc = this.ActiveUIDocument.Document;
			ICollection<ElementId> cols = new FilteredElementCollector(doc).OfClass(typeof(View)).ToElementIds() ;
			String allNames = "";
			foreach (ElementId col in cols) {
				allNames += doc.GetElement(col).Name+ " " + GetElementTemplate(col, doc) + " " + GetElementLevel(col,doc)+ " "+ GetElementType(col,doc) +" "+ GetViewType(col, doc) + Environment.NewLine;
			}
			TaskDialog.Show("Hello",allNames);
		}
		
		public void RenameView(){
			try
            {
				
				
				Document doc = this.ActiveUIDocument.Document;
				ICollection<ElementId> cols = new FilteredElementCollector(doc).OfClass(typeof(ViewPlan)).ToElementIds() ;
				string name = "Rename View";
				Transaction transaction = new Transaction(doc, name);
				transaction.Start(name);
				
				foreach (ElementId col in cols) {
					
					//Get the A1 B2 part of the name
					//Into the switch case
					//Change the name based on case
					
					string viewType = GetElementType(col,doc);
					string identifier = viewType.Substring(viewType.Length - 5, 5);
					Element ele = doc.GetElement(col);
					
					View view = doc.GetElement(col) as View;
					
					//view.GetDependentElements
					
					switch (identifier){
					case "A1 B1":
						ele.Name =  ele.Name.Substring(0, ele.Name.Length-5) + identifier;
						break;
						
					case "A2 B1":
						ele.Name =  ele.Name.Substring(0, ele.Name.Length-5) + identifier;
						break;
						
					case "A3 B1":
						ele.Name =  ele.Name.Substring(0, ele.Name.Length-5) + identifier;
						break;
					
					case "A4 B2":
						ele.Name =  ele.Name.Substring(0, ele.Name.Length-5) + identifier;
						break;
					
					case "A4 B3":
						ele.Name =  ele.Name.Substring(0, ele.Name.Length-5) + identifier;
						break;
						
					case "A5 B2":
						ele.Name =  ele.Name.Substring(0, ele.Name.Length-5) + identifier;
						break;
					
					case "A5 B3":
						ele.Name =  ele.Name.Substring(0, ele.Name.Length-5) + identifier;
						break;
						
					case "A6 B2":
						ele.Name =  ele.Name.Substring(0, ele.Name.Length-5) + identifier;
						break;
					
					case "A6 B3":
						ele.Name =  ele.Name.Substring(0, ele.Name.Length-5) + identifier;
						break;
						
					default:
						break;
						
					}
				}
				

				transaction.Commit();
               
	            
            }

            catch(Exception e)
            {
                TaskDialog.Show("Error", e.Message);
                
            }
			
			
			
		}
		
		
		String GetElementLevel(ElementId id, Document doc){
			View view = doc.GetElement(id) as View;
			if(view.GenLevel != null){
				Level myLevel = doc.GetElement(view.GenLevel.Id) as Level;
				return view.GenLevel.Name.ToString();
			}
			
			return "Level error";
		}
		
		String GetElementTemplate(ElementId id, Document doc){
			View view = doc.GetElement(id) as View;
			if(view.ViewTemplateId.IntegerValue > 0){
				Element ele = doc.GetElement(view.ViewTemplateId);
				return ele.Name;
			}
			return "Template error";
		}
		
		String GetElementType(ElementId id, Document doc){
			ElementId elId = doc.GetElement(id).GetTypeId();
			if(elId.IntegerValue > 0){
				ElementType type = doc.GetElement( elId ) as ElementType;
				return type.Name;
			}
			
			return "Family Type error";
		}
		
		String GetViewType(ElementId id, Document doc){
			ElementId elId = doc.GetElement(id).GetTypeId();
			if(elId.IntegerValue > 0){
				ElementType type = doc.GetElement( elId ) as ElementType;
				return type.FamilyName;
			}
			
			return "View Type error";
		}
		
		String GetDependentViews(ElementId id, Document doc){
			View view = doc.GetElement(id) as View;
			String depViewNames = "";
			if(view != null){
				ICollection<ElementId> dependentViews = view.GetDependentViewIds();
				if(dependentViews.Any()){
					foreach (ElementId depId in dependentViews) {
						View depView = doc.GetElement(depId) as View;
						depViewNames += "\t     " + depView.Name.ToString() + Environment.NewLine;
					}
					depViewNames = "View: " + view.Name + Environment.NewLine + depViewNames + Environment.NewLine;
				}
			}
			
			return depViewNames;
		}
	
			
		public void DependentViewTest(){
			try{
				Document doc = this.ActiveUIDocument.Document;
				String words = "";
				ICollection<ElementId> cols = new FilteredElementCollector(doc).OfClass(typeof(ViewPlan)).ToElementIds() ;
				
				
				foreach (ElementId col in cols) {
					words += GetDependentViews(col,doc);
				}
				TaskDialog.Show("Message", words);
			}
			catch(Exception e){
				TaskDialog.Show("Error", e.Message);
			}
		}
		
		public void VisibilityGraphicsTest(){
			try{
				Document doc = this.ActiveUIDocument.Document;
				String words = "";
				ICollection<ElementId> cols = new FilteredElementCollector(doc).OfClass(typeof(View)).ToElementIds() ;
				foreach (ElementId col in cols) {
					View view = doc.GetElement(col) as View;
					
				}
				TaskDialog.Show("Message", words);
			}
			catch(Exception e){
				TaskDialog.Show("Error", e.Message);
			}
		
		}
		
		public void EmptyMethod(){
			
		}
	}
}