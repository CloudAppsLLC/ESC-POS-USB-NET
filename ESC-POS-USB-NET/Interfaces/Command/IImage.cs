using ESC_POS_USB_NET.EpsonCommands;
using System.Drawing;

namespace ESC_POS_USB_NET.Interfaces.Command
{
    internal interface IImage
    {
        byte[] Print(byte[] image, int maxWidth, bool isLegacy, int color);
    }
}
