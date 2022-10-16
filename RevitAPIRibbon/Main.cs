using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace RevitAPIRibbon
{
    [Transaction(TransactionMode.Manual)]
    public class Main : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            string tabName = "RevitAPITraining";
            application.CreateRibbonTab(tabName);
            string utilsFolderPath = @"C:\Program Files\RevitAPITrainig\";

            var panel = application.CreateRibbonPanel(tabName, "5.3");

            var button1 = new PushButtonData("Система1", "5.1", 
                Path.Combine(utilsFolderPath,
                "RevitAPI51.dll"), 
                "RevitAPI51.Main");

            var button2 = new PushButtonData("Система2", "5.2",
                Path.Combine(utilsFolderPath,
                "RevitAPI52.dll"),
                "RevitAPI52.Main");

            Uri uriImage = new Uri(@"C:\Users\Zakhar\source\repos\RevitAPIRibbon\RevitAPIRibbon\Images\logo.jpg", UriKind.Absolute);
            BitmapImage largeImahe = new BitmapImage(uriImage);
            button1.LargeImage = largeImahe;
            button2.LargeImage = largeImahe;

            panel.AddItem(button1);
            panel.AddItem(button2);

            return Result.Succeeded;
        }
    }
}
