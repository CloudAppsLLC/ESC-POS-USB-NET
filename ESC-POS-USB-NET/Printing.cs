using ESC_POS_USB_NET.Enums;
using System;
using System.Text;
using Timestamp = Google.Protobuf.WellKnownTypes.Timestamp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Drawing.Printing;
using System.Drawing;
using ESC_POS_USB_NET.Interfaces.Printer;

namespace ESC_POS_USB_NET.Printing
{
    class Printing
    {
        public static string LazyWaitPOS = "iVBORw0KGgoAAAANSUhEUgAAAHUAAAAdCAYAAACUoyOLAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsQAAA7EAZUrDhsAAAXCaVRYdFhNTDpjb20uYWRvYmUueG1wAAAAAAA8P3hwYWNrZXQgYmVnaW49Iu+7vyIgaWQ9Ilc1TTBNcENlaGlIenJlU3pOVGN6a2M5ZCI/PiA8eDp4bXBtZXRhIHhtbG5zOng9ImFkb2JlOm5zOm1ldGEvIiB4OnhtcHRrPSJBZG9iZSBYTVAgQ29yZSA1LjYtYzE0MiA3OS4xNjA5MjQsIDIwMTcvMDcvMTMtMDE6MDY6MzkgICAgICAgICI+IDxyZGY6UkRGIHhtbG5zOnJkZj0iaHR0cDovL3d3dy53My5vcmcvMTk5OS8wMi8yMi1yZGYtc3ludGF4LW5zIyI+IDxyZGY6RGVzY3JpcHRpb24gcmRmOmFib3V0PSIiIHhtbG5zOnhtcD0iaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wLyIgeG1sbnM6ZGM9Imh0dHA6Ly9wdXJsLm9yZy9kYy9lbGVtZW50cy8xLjEvIiB4bWxuczpwaG90b3Nob3A9Imh0dHA6Ly9ucy5hZG9iZS5jb20vcGhvdG9zaG9wLzEuMC8iIHhtbG5zOnhtcE1NPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvbW0vIiB4bWxuczpzdEV2dD0iaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wL3NUeXBlL1Jlc291cmNlRXZlbnQjIiB4bXA6Q3JlYXRvclRvb2w9IkFkb2JlIFBob3Rvc2hvcCBDQyAoV2luZG93cykiIHhtcDpDcmVhdGVEYXRlPSIyMDE5LTA3LTE1VDExOjI2OjQ3KzAzOjAwIiB4bXA6TW9kaWZ5RGF0ZT0iMjAxOS0xMi0yOVQxNTowMTozOSswMzowMCIgeG1wOk1ldGFkYXRhRGF0ZT0iMjAxOS0xMi0yOVQxNTowMTozOSswMzowMCIgZGM6Zm9ybWF0PSJpbWFnZS9wbmciIHBob3Rvc2hvcDpDb2xvck1vZGU9IjMiIHhtcE1NOkluc3RhbmNlSUQ9InhtcC5paWQ6OTRjNzU0YzctZjBjMi1mMDQ5LWFjZDItZmVkODUx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";

        public void PrintJob(PrintJob job, string branchJson, string terminalJson, bool is_both, string planguage = null)
        {
            try
            {
                PrintDocument recordDoc = new PrintDocument();
                recordDoc.DocumentName = "Testing Printer";
                recordDoc.DefaultPageSettings.PaperSize = new PaperSize("Custom", 300, 4000);
                recordDoc.PrintPage += new PrintPageEventHandler((sender2, e2) => PrintTestPageHandler(sender2, e2, "this is testing")); // function below
                recordDoc.PrintController = new StandardPrintController(); // hides status dialog popup
                                                                           //Main Printer

                if (job.printer != null)
                {
                    recordDoc.PrinterSettings.PrinterName = job.printer.printer_name;
                    recordDoc.Print();
                    recordDoc.Dispose();
                }
            }
            catch (Exception e)
            {
                // return false;
            }
            //return true;
        }

        private void PrintTestPageHandler(object sender, PrintPageEventArgs e, string text)
        {
            try
            {
                float x = 0;
                float y = 5;
                float width = 290.0F; // max width I found through trial and error
                float height = 0F;

                //Fonts
                Graphics graphics = e.Graphics;
                byte[] powered_by = Convert.FromBase64String(LazyWaitPOS);
                Image power_stamp = Image.FromStream(new MemoryStream(powered_by));
                graphics.DrawImage(power_stamp, (width / 2) - (power_stamp.Width / 4), y, (power_stamp.Width / 2), (power_stamp.Height / 2));
                y += 39F;
            }
            catch (Exception ex)
            {
          
            }
        }
    }
}
