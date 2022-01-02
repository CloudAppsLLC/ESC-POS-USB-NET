using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Numerics;
using ESC_POS_USB_NET.Enums;
using System.Drawing;
using System.Drawing.Printing;
using ESC_POS_USB_NET.Utils;

namespace ESC_POS_USB_NET.Utils
{
    class ItemSlip
    {
        public static Graphics CreateKitchenTicket(order_item[] items, Order order, string branchJson, bool isCanceled, string terminal, bool isReprint = false)
        {
            Bitmap bitmap = new Bitmap(1000, 800, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            Graphics graphics = Graphics.FromImage(bitmap);
            return graphics;
        }
    }
}
