using ESC_POS_USB_NET.Enums;
using ESC_POS_USB_NET.Extensions;
using ESC_POS_USB_NET.Interfaces.Command;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESC_POS_USB_NET.EpsonCommands
{
    public class BarCode : IBarCode
    {
        public static readonly byte GS = 0x1D;
        public byte[] Code128(string code,Positions printString=Positions.NotPrint)
        {
            return new byte[] { 29, 119, 2 } // Width
                .AddBytes(new byte[] { 29, 104, 50 }) // Height
                .AddBytes(new byte[] { 29, 102, 1 }) // font hri character
                .AddBytes(new byte[] { 29, 72, printString.ToByte() }) // If print code informed
                .AddBytes(new byte[] { 29, 107, 73 }) // printCode
                .AddBytes(new[] { (byte)(code.Length + 2) })
                .AddBytes(new[] { '{'.ToByte(), 'C'.ToByte() })
                .AddBytes(code)
                .AddLF();
        }

        public byte[] Code39(string code, Positions printString = Positions.NotPrint)
        {
            return new byte[] { 29, 119, 2 } // Width
                .AddBytes(new byte[] { 29, 104, 50 }) // Height
                .AddBytes(new byte[] { 29, 102, 0 }) // font hri character
                .AddBytes(new byte[] { 29, 72, printString.ToByte() }) // If print code informed
                .AddBytes(new byte[] { 29, 107, 4 })
                .AddBytes(code)
                .AddBytes(new byte[] { 0 })
                .AddLF();
        }

        public byte[] Ean13(string code, Positions printString = Positions.NotPrint)
        {
            if (code.Trim().Length != 13)
                return new byte[0];

            return new byte[] { 29, 119, 2 } // Width
                .AddBytes(new byte[] { 29, 104, 50 }) // Height
                .AddBytes(new byte[] { 29, 72, printString.ToByte() }) // If print code informed
                .AddBytes(new byte[] { 29, 107, 67, 12 })
                .AddBytes(code.Substring(0, 12))
                .AddLF();
        }

        public virtual byte[] PrintBarcode(BarcodeType type, string barcode, BarcodeCode code = BarcodeCode.CODE_B)
        {
            //DataValidator.ValidateBarcode(type, code, barcode);
            return BarcodeBytes(type, barcode, code);
        }

        public byte[] BarcodeBytes(BarcodeType type, string barcode, BarcodeCode code)
        {
            // For CODE128, prepend the first 2 characters as 0x7B and the CODE type, and escape 0x7B characters.
            if (type == BarcodeType.CODE128)
            {
                if (code == BarcodeCode.CODE_C)
                {
                    byte[] b = Encoding.ASCII.GetBytes(barcode);
                    byte[] ob = new byte[b.Length / 2];
                    for (int i = 0, obc = 0; i < b.Length; i += 2)
                    {
                        ob[obc++] = (byte)(((b[i] - '0') * 10) + (b[i + 1] - '0'));
                    }

                    barcode = Encoding.ASCII.GetString(ob);
                }

                barcode = barcode.Replace("{", "{{");
                barcode = $"{(char)0x7B}{(char)code}" + barcode;
            }

            var command = new List<byte> { GS, Barcodes.PrintBarcode, (byte)type, (byte)barcode.Length };
            command.AddRange(barcode.ToCharArray().Select(x => (byte)x));
            return command.ToArray();
        }

        public virtual byte[] SetBarcodeHeightInDots(int height) => new byte[] { GS, Barcodes.SetBarcodeHeightInDots, (byte)height };
        //public virtual byte[] SetBarWidth(BarWidth width) => new byte[] { GS, Barcodes.SetBarWidth, (byte)width };

        public static class Barcodes
        {
            public static readonly byte PrintBarcode = 0x6B;
            public static readonly byte SetBarcodeHeightInDots = 0x68;
            public static readonly byte SetBarWidth = 0x77;
            public static readonly byte SetBarLabelPosition = 0x48;
            public static readonly byte SetBarLabelFont = 0x66;

            public static readonly byte Set2DCode = 0x28;
            public static readonly byte AutoEnding = 0x00;
            public static readonly byte[] SetPDF417NumberOfColumns = { 0x03, 0x00, 0x30, 0x41 };
            public static readonly byte[] SetPDF417NumberOfRows = { 0x03, 0x00, 0x30, 0x42 };
            public static readonly byte[] SetPDF417DotSize = { 0x03, 0x00, 0x30, 0x43 };
            public static readonly byte[] SetPDF417CorrectionLevel = { 0x04, 0x00, 0x30, 0x45, 0x30 };
            public static readonly byte[] StorePDF417Data = { 0x00, 0x30, 0x50, 0x30 };
            public static readonly byte[] PrintPDF417 = { 0x03, 0x00, 0x30, 0x51, 0x30 };

            public static readonly byte[] SelectQRCodeModel = { 0x04, 0x00, 0x31, 0x41 };
            public static readonly byte[] SetQRCodeDotSize = { 0x03, 0x00, 0x31, 0x43 };
            public static readonly byte[] SetQRCodeCorrectionLevel = { 0x03, 0x00, 0x31, 0x45 };
            public static readonly byte[] StoreQRCodeData = { 0x31, 0x50, 0x30 };
            public static readonly byte[] PrintQRCode = { 0x03, 0x00, 0x31, 0x51, 0x30 };
        }
    }
}

