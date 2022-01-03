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
    public sealed class Printing: IPrinting
    {
        /*
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
        */
    }
}
