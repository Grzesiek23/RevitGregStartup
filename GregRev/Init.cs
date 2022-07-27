using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using System.Reflection;
using GregRev.Commands;

namespace GregRev
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class Init : IExternalApplication
    {
        private const string TabName = "Greg's Tab";

        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            PrepareRibbon(application);

            return Result.Succeeded;

        }

        private void PrepareRibbon(UIControlledApplication application)
        {

            application.CreateRibbonTab(TabName);

            var myPanel = application.CreateRibbonPanel(TabName, "Greg's panel");

            var myButton = new PushButtonData(
               "myButton",
               "My first button",
               Assembly.GetExecutingAssembly().Location, 
               typeof(MyCommand).ToString())
            {
                ToolTip = "Lorem ipsum dolor sit amet, consectetur adipiscing elit."
            };

            myPanel.AddItem(myButton);
        }
    }
}
