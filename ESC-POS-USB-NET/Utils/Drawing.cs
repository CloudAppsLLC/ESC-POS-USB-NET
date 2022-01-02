using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Drawing;
using ESC_POS_USB_NET.Enums;

namespace ESC_POS_USB_NET.Utils
{
    class itemReturnObj
    {
        public itemReturnObj(float y, bool isItemTaxable)
        {
            this.y = y;
            this.isItemTaxable = isItemTaxable;
        }

        public float y { get; set; }
        public bool isItemTaxable { get; set; }
    }
    class Drawing
    {
        private static readonly float fontWidth = 15f;

        StringFormat drawFormatCenter = new StringFormat();


        private static readonly float width = 300;
        private static readonly float lineWidth = 0.8f;

        private static readonly Font regular = new Font("Tajawal", 12, FontStyle.Regular);
        private static readonly Font bold = new Font("Tajawal", 12, FontStyle.Bold);
        private static readonly Font large = new Font("Tajawal", 12, FontStyle.Bold);
        private static readonly Font extraLarge = new Font("Tajawal", 40, FontStyle.Bold);
        private static readonly SolidBrush drawBrush = new SolidBrush(Color.Black);
        private static readonly SolidBrush drawWhiteBrush = new SolidBrush(Color.White);

       private static readonly Pen blackPen = new Pen(Color.Black, 1F);
       


        public static float DrawFullFaw(Graphics ds, float y, string value, bool bold, bool semibold, bool start)
        {
            /*
             var textFormat = new CanvasTextFormat()
             {
                 FontFamily = bold ? "Assets/Tajawal-Bold.ttf#Tajawal" : "Assets/Tajawal-Regular.ttf#Tajawal",
                 FontSize = bold && !semibold ? 20f : 14f,
             };

             CanvasTextLayout textLayout = new CanvasTextLayout(ds, value, textFormat, width - 30, 0);

             int c = start ? 0 : (int)(width / 2) - (int)(textLayout.DrawBounds.Width / 2);

             Rectangle rect = new RectangleF(c, y, width - c - 20, textLayout.DrawBounds.Y);

             ds.DrawString(value, rect, Color.Black, textFormat);

             return ((float)textLayout.DrawBounds.Height * 1.7f) + 1f;
            */

            ds.DrawString(value, regular, drawBrush, new RectangleF(0, y, 280, 0F));
            return 1f;
        }

        public static float DrawNonTaxable(Graphics ds, float y, string title, string languageOne, string languageTwo, bool reverse, bool bold)
        {
            /*
            var textFormat = new CanvasTextFormat()
            {
                FontFamily = bold ? "Assets/Tajawal-Bold.ttf#Tajawal" : "Assets/Tajawal-Regular.ttf#Tajawal",
                FontSize = 14f,
            };

            CanvasTextLayout valueLayout;
            var txt = "**";
            txt += utils.GetTranslation(title, languageOne);
            CanvasTextLayout txtLayout = new CanvasTextLayout(ds, txt, textFormat, 250, 0);
            Rect rect;

            if (!string.IsNullOrEmpty(languageTwo))
            {
                var txt2 = "**";
                txt2 += utils.GetTranslation(title, languageTwo);
                CanvasTextLayout txt2Layout = new CanvasTextLayout(ds, txt2, textFormat, 250, 0);
                valueLayout = new CanvasTextLayout(ds, "**", textFormat, width - (int)txtLayout.DrawBounds.Width - (int)txt2Layout.DrawBounds.Width - 20, 0);
                rect = new Rect((int)(width / 2) - (int)(valueLayout.DrawBounds.Width / 2), y, width - (int)txtLayout.DrawBounds.Width - (int)txt2Layout.DrawBounds.Width - 20, valueLayout.DrawBounds.Y);

                if (reverse)
                {

                    ds.DrawText(txt2, new Vector2(0, y), Colors.Black, textFormat);

                    ds.DrawText(txt, new Vector2(width - (int)txtLayout.DrawBounds.Width, y), Colors.Black, textFormat);
                }
                else
                {
                    ds.DrawText(txt, new Vector2(0, y), Colors.Black, textFormat);
                    ds.DrawText(txt2, new Vector2(width - (int)txt2Layout.DrawBounds.Width, y), Colors.Black, textFormat);
                }
            }
            else
            {
                valueLayout = new CanvasTextLayout(ds, "**", textFormat, width - (int)txtLayout.DrawBounds.Width - 20, 0);

                if (reverse)
                {

                    rect = new Rect(0, y, width - (int)txtLayout.DrawBounds.Width, valueLayout.DrawBounds.Y);
                    ds.DrawText(txt, new Vector2(width - (int)txtLayout.DrawBounds.Width, y), Colors.Black, textFormat);
                }
                else
                {
                    rect = new Rect(width - (int)valueLayout.DrawBounds.Width, y, width - (int)txtLayout.DrawBounds.Width, valueLayout.DrawBounds.Y);
                    ds.DrawText(txt, new Vector2(0, y), Colors.Black, textFormat);

                }
            }

            return (float)valueLayout.DrawBounds.Height + 20f;
            */
            ds.DrawString(title, regular, drawBrush, new RectangleF(0, y, 280, 0F));
            return 20f;
        }

        public static float DrawRaw(Graphics ds, float y, string value, string title, string languageOne, string languageTwo, bool reverse, bool bold, float fontSize = 14f, bool isValueBold = false)
        {
            /*
            var textFormat = new CanvasTextFormat()
            {
                FontFamily = bold ? "Assets/Tajawal-Bold.ttf#Tajawal" : "Assets/Tajawal-Regular.ttf#Tajawal",
                FontSize = fontSize,
            };


            var BoldtextFormat = new CanvasTextFormat()
            {
                FontFamily = "Assets/Tajawal-Bold.ttf#Tajawal",
                FontSize = 23f,
            };
            CanvasTextLayout valueLayout;
            CanvasTextLayout txtLayout;
            CanvasTextLayout txt2Layout;
            var txt = utils.GetTranslation(title, languageOne);
            var txt2 = "";

            Rect rect;
            Rect rectTxt;
            Rect rectTxt2;
            if (!string.IsNullOrEmpty(languageTwo))
            {
                txt2 = utils.GetTranslation(title, languageTwo);
                float requestedWidth = 250;
                valueLayout = new CanvasTextLayout(ds, value, textFormat, requestedWidth, 0);
                txtLayout = new CanvasTextLayout(ds, txt, textFormat, 250, 0);
                txt2Layout = new CanvasTextLayout(ds, txt2, textFormat, 250, 0);

                int valueWidth = (int)(valueLayout.DrawBounds.Width > (width / 2) ? 45 : (valueLayout.DrawBounds.Width / 2));

                int diff = (int)(width / 2) - valueWidth;
                rect = new Rect(diff, y, width - diff, valueLayout.DrawBounds.Y);


                if (reverse)
                {
                    rectTxt2 = new Rect(0, y, (width / 2 - valueLayout.DrawBounds.Width - 10), txt2Layout.DrawBounds.Y);
                    rectTxt = new Rect(width - (int)txtLayout.DrawBounds.Width, y, (width / 2 - valueLayout.DrawBounds.Width - 10), txtLayout.DrawBounds.Y);
                    ds.DrawText(txt2, rectTxt2, Colors.Black, textFormat);
                    ds.DrawText(value, rect, Colors.Black, textFormat);
                    ds.DrawText(txt, rectTxt, Colors.Black, textFormat);
                }
                else
                {
                    rectTxt = new Rect(0, y, width - txtLayout.DrawBounds.Width, txtLayout.DrawBounds.Y);
                    rectTxt2 = new Rect(width - (int)txt2Layout.DrawBounds.Width, y, width - valueLayout.DrawBounds.Width - txt2Layout.DrawBounds.Width, txt2Layout.DrawBounds.Y);
                    ds.DrawText(txt, rectTxt, Colors.Black, textFormat);
                    ds.DrawText(value, rect, Colors.Black, textFormat);
                    ds.DrawText(txt2, rectTxt2, Colors.Black, textFormat);
                }
            }
            else
            {
                valueLayout = new CanvasTextLayout(ds, value, textFormat, width * 2 / 3, 0);
                txtLayout = new CanvasTextLayout(ds, txt, textFormat, width / 3, 0);
                if (reverse)
                {

                    rect = new Rect(0, y, width - valueLayout.DrawBounds.Width, valueLayout.DrawBounds.Y);
                    rectTxt = new Rect(width - (int)txtLayout.DrawBounds.Width, y, width - (int)txtLayout.DrawBounds.Width, txtLayout.DrawBounds.Y);
                    ds.DrawText(value, rect, Colors.Black, textFormat);
                    ds.DrawText(txt, rectTxt, Colors.Black, textFormat);
                }
                else
                {

                    rect = new Rect(width - (int)valueLayout.DrawBounds.Width, y, width - (int)valueLayout.DrawBounds.Width, valueLayout.DrawBounds.Y);
                    rectTxt = new Rect(0, y, width - txtLayout.DrawBounds.Width, txtLayout.DrawBounds.Y);

                    ds.DrawText(txt, rectTxt, Colors.Black, textFormat);
                    ds.DrawText(value, rect, Colors.Black, textFormat);
                }
            }

            if (txt2.Length > 16)
            {

                return (float)valueLayout.DrawBounds.Height + (float)txt2.Length + 8f;
            }
            else if (txt.Length > 16)
            {
                return (float)valueLayout.DrawBounds.Height + (float)txt.Length + 8f;
            }
            else
            {
                return (float)txtLayout.DrawBounds.Height + 8f;
            }
        }

        public static float DrawHeaderWithTotal(CanvasDrawingSession ds, float y, string languageOne, string languageTwo)
        {
            var textFormat = new CanvasTextFormat()
            {
                FontFamily = "Assets/Tajawal-Bold.ttf#Tajawal",
                FontSize = 14f,
            };

            var qty = utils.GetTranslation("QTY", languageOne);
            CanvasTextLayout qtyLayout = new CanvasTextLayout(ds, qty, textFormat, 250, 0);
            ds.DrawText(qty, new Vector2(0, y), Colors.Black, textFormat);

            var item = utils.GetTranslation("ITEM", languageOne);
            ds.DrawText(item, new Vector2(50, y), Colors.Black, textFormat);

            var total = utils.GetTranslation("TOTAL", languageOne);
            CanvasTextLayout totalLayout = new CanvasTextLayout(ds, total, textFormat, 250, 0);
            ds.DrawText(total, new Vector2(width - (int)totalLayout.DrawBounds.Width, y), Colors.Black, textFormat);

            float yx = (float)qtyLayout.DrawBounds.Height + 3f;
            if (!string.IsNullOrEmpty(languageTwo))
            {

                qty = utils.GetTranslation("QTY", languageTwo);
                ds.DrawText(qty, new Vector2(0, yx + y), Colors.Black, textFormat);

                item = utils.GetTranslation("ITEM", languageTwo);
                ds.DrawText(item, new Vector2(50, yx + y), Colors.Black, textFormat);

                total = utils.GetTranslation("TOTAL", languageTwo);
                CanvasTextLayout total2Layout = new CanvasTextLayout(ds, total, textFormat, 250, 0);
                ds.DrawText(total, new Vector2(width - (int)total2Layout.DrawBounds.Width, yx + y), Colors.Black, textFormat);

                yx += 14f;
            }

            return yx;
            */
            ds.DrawString(title, regular, drawBrush, new RectangleF(0, y, 280, 0F));
            return 14f;
        }

        public static itemReturnObj DrawInvoiceItems(Graphics ds, float y, List<order_item> order_items, int rounds, string languageOne, string languageTwo, bool printBarcode, string currency, bool isCanceled, bool print_with_vat, double vat = 0)
        {
            itemReturnObj returnObj = new itemReturnObj(0, false);
            /*
            
            var textFormat = new CanvasTextFormat()
            {
                FontFamily = "Assets/Tajawal-Regular.ttf#Tajawal",
                FontSize = 14f,
            };

            float yx = 0;
            bool IsThereItemNotTaxable = false;
            foreach (order_item item in order_items)
            {
                string qty = item.quantity + " x";
                CanvasTextLayout qtyLayout = new CanvasTextLayout(ds, qty, textFormat, 250, 0);
                ds.DrawText(qty, new Vector2(0, yx + y), Colors.Black, textFormat);

                string name_lan_p = "";
                if (String.Equals(languageOne, "ar") && !string.IsNullOrWhiteSpace(item.name_lan_s))
                {

                    name_lan_p = item.name_lan_s ?? "";
                }
                else
                {
                    name_lan_p = item.name_lan_p ?? "";
                }


                var price_name = "";
                if (String.Equals(languageOne, "ar") && !string.IsNullOrWhiteSpace(item.order_item_price.name_lan_s))
                {

                    price_name = item.order_item_price.name_lan_s ?? "";
                }
                else
                {
                    price_name = item.order_item_price.name_lan_p ?? "";
                }
                if (!string.IsNullOrWhiteSpace(price_name)) { name_lan_p += " - " + price_name; }
                if (item.not_taxable)
                {
                    name_lan_p += "  **";
                    IsThereItemNotTaxable = true;
                }
                string total = "";
                if (isCanceled)
                {
                    double item_price = GetItemPrice(item.price, item.quantity, print_with_vat, (item.taxable ?? false) && !item.not_taxable, vat);
                    total = "-" + item_price.ToString("F" + rounds) + " " + currency;
                }
                else
                {

                    double item_price = GetItemPrice(item.price, item.quantity, print_with_vat, (item.taxable ?? false) && !item.not_taxable, vat);
                    total = item_price.ToString("F" + rounds) + " " + currency;

                }
                CanvasTextLayout totalLayout = new CanvasTextLayout(ds, total, textFormat, 250, 0);
                ds.DrawText(total, new Vector2(width - (int)totalLayout.DrawBounds.Width, yx + y), Colors.Black, textFormat);

                CanvasTextLayout name_lan_p_layout = new CanvasTextLayout(ds, name_lan_p, textFormat, width - (int)totalLayout.DrawBounds.Width - (int)qtyLayout.DrawBounds.Width - 40, 0);
                Rect rect = new Rect(50, yx + y, width - (int)totalLayout.DrawBounds.Width - (int)qtyLayout.DrawBounds.Width - 40, name_lan_p_layout.DrawBounds.Y);
                ds.DrawText(name_lan_p, rect, Colors.Black, textFormat);
                if (isCanceled)
                {

                    ds.DrawLine(0f, (float)(name_lan_p_layout.DrawBounds.Y) + yx + y + (float)name_lan_p_layout.DrawBounds.Height / 2, (float)(width * 0.7), (float)(name_lan_p_layout.DrawBounds.Y) + yx + y + (float)name_lan_p_layout.DrawBounds.Height / 2, Colors.Black);
                }
                yx += (float)name_lan_p_layout.DrawBounds.Height + 3f;

                if (!string.IsNullOrEmpty(languageTwo))
                {

                    string name_lan_s = item.name_lan_s ?? "";
                    price_name = item.order_item_price.name_lan_s ?? "";
                    if (!string.IsNullOrWhiteSpace(price_name)) { name_lan_s += " - " + price_name; }
                    CanvasTextLayout name_lan_s_layout = new CanvasTextLayout(ds, name_lan_s, textFormat, width - (int)totalLayout.DrawBounds.Width - (int)qtyLayout.DrawBounds.Width - 40, 0);
                    Rect rect_s = new Rect(50, yx + y, width - (int)totalLayout.DrawBounds.Width - (int)qtyLayout.DrawBounds.Width - 40, name_lan_s_layout.DrawBounds.Y);
                    ds.DrawText(name_lan_s, rect_s, Colors.Black, textFormat);
                    if (isCanceled)
                    {

                        ds.DrawLine(0f, (float)(name_lan_s_layout.DrawBounds.Y) + yx + y + (float)name_lan_s_layout.DrawBounds.Height / 2, (float)(width * 0.7), (float)(name_lan_s_layout.DrawBounds.Y) + yx + y + (float)name_lan_s_layout.DrawBounds.Height / 2, Colors.Black);
                    }
                    yx += (float)name_lan_s_layout.DrawBounds.Height + 3f;

                }

                if (printBarcode && item.order_item_price != null && !string.IsNullOrEmpty(item.order_item_price.barcode))
                {
                    yx += (float)qtyLayout.DrawBounds.Height + 3f;
                    string barcode = "-- " + item.order_item_price.barcode + " --";
                    ds.DrawText(barcode, new Vector2(50, yx + y), Colors.Black, textFormat);
                }

                if (!string.IsNullOrEmpty(item.details))
                {
                    yx += (float)qtyLayout.DrawBounds.Height + 3f;
                    CanvasTextLayout item_details_layout = new CanvasTextLayout(ds, item.details, textFormat, width - (int)totalLayout.DrawBounds.Width - (int)qtyLayout.DrawBounds.Width - 40, 0);
                    Rect details_rect = new Rect(50, yx + y, width - (int)totalLayout.DrawBounds.Width - (int)qtyLayout.DrawBounds.Width - 40, item_details_layout.DrawBounds.Y);
                    ds.DrawText(item.details, details_rect, Colors.Black, textFormat);
                    yx += (float)item_details_layout.DrawBounds.Height + 3f;
                }

                if (item.addons.Count > 0)
                {
                    foreach (order_item_addon addon in item.addons)
                    {
                        yx += (float)qtyLayout.DrawBounds.Height;

                        bool is_qty = addon.quantity != null && addon.quantity > 0;
                        string symbol = is_qty ? "✓" : "✗";
                        ds.DrawText(symbol, new Vector2(50, yx + y), Colors.Black, textFormat);
                        if (Math.Round((decimal)addon.quantity) > 0)
                        {
                            ds.DrawText(Math.Round((decimal)addon.quantity).ToString() + "x ", new Vector2(70, yx + y), Colors.Black, textFormat);
                        }

                        CanvasTextLayout item_addon_layout;
                        if (String.Equals(languageOne, "ar") && !string.IsNullOrWhiteSpace(addon.name_lan_s))
                        {
                            item_addon_layout = new CanvasTextLayout(ds, addon.name_lan_s, textFormat, width - (int)totalLayout.DrawBounds.Width - (int)qtyLayout.DrawBounds.Width - 90, 0);

                        }
                        else
                        {
                            item_addon_layout = new CanvasTextLayout(ds, addon.name_lan_p, textFormat, width - (int)totalLayout.DrawBounds.Width - (int)qtyLayout.DrawBounds.Width - 90, 0);
                        }
                        Rect addon_rect = new Rect(100, yx + y, width - (int)totalLayout.DrawBounds.Width - (int)qtyLayout.DrawBounds.Width - 90, item_addon_layout.DrawBounds.Y);
                        if (String.Equals(languageOne, "ar") && !string.IsNullOrWhiteSpace(addon.name_lan_s))
                        {
                            ds.DrawText(addon.name_lan_s, addon_rect, Colors.Black, textFormat);
                        }
                        else
                        {
                            ds.DrawText(addon.name_lan_p, addon_rect, Colors.Black, textFormat);

                        }

                        double addon_total = GetAddonPrice(addon.price, addon.quantity, item.quantity, print_with_vat, (item.taxable ?? false) && !item.not_taxable, vat);
                        string addon_total_str = addon_total.ToString("F" + rounds) + " " + currency;


                        CanvasTextLayout addonTotalLayout = new CanvasTextLayout(ds, addon_total_str, textFormat, 250, 0);
                        ds.DrawText(addon_total_str, new Vector2(width - (int)addonTotalLayout.DrawBounds.Width, yx + y), Colors.Black, textFormat);

                        yx += (float)item_addon_layout.DrawBounds.Height;
                        if (!string.IsNullOrEmpty(languageTwo))
                        {
                            CanvasTextLayout item_addon_layout_s = new CanvasTextLayout(ds, addon.name_lan_s, textFormat, width - (int)totalLayout.DrawBounds.Width - (int)qtyLayout.DrawBounds.Width - 90, 0);
                            Rect addon_rect_s = new Rect(100, yx + y, width - (int)totalLayout.DrawBounds.Width - (int)qtyLayout.DrawBounds.Width - 90, item_addon_layout_s.DrawBounds.Y);
                            ds.DrawText("" + addon.name_lan_s, addon_rect_s, Colors.Black, textFormat);
                            yx += (float)item_addon_layout_s.DrawBounds.Height;


                        }
                    }
                }

                yx += (float)qtyLayout.DrawBounds.Height + 3f;

            }

            returnObj.y = yx;
            returnObj.isItemTaxable = IsThereItemNotTaxable;
            return returnObj;
            */
            ds.DrawString("item", regular, drawBrush, new RectangleF(0, y, 280, 0F));
            return returnObj;
        }

        public static float DrawReason(Graphics ds, float y, string reason)
        {
            /*
            var textFormat = new CanvasTextFormat()
            {
                FontFamily = "Assets/Tajawal-Regular.ttf#Tajawal",
                FontSize = 14f,
            };
            CanvasTextLayout txtLayout = new CanvasTextLayout(ds, reason, textFormat, 250, 0);
            ds.DrawText(reason, new Vector2(0, y), Colors.Black, textFormat);
            return (float)txtLayout.DrawBounds.Height + 7f;
            */
            ds.DrawString(reason, regular, drawBrush, new RectangleF(0, y, 280, 0F));
            return 14f;
        }

        public static float DrawTotals(Graphics ds, float y, double? num, string title, string vat, int rounds, bool bold, string languageOne, string languageTwo, bool reverse, string currency)
        {
            string value = num != null ? (num ?? 0).ToString("F" + rounds) : "";
            if (num != null)
            {
                value += " " + currency;
            }

            /*
            var textFormat = new CanvasTextFormat()
            {
                FontFamily = bold ? "Assets/Tajawal-Bold.ttf#Tajawal" : "Assets/Tajawal-Regular.ttf#Tajawal",
                FontSize = 14f,
            };



            CanvasTextLayout valueLayout = new CanvasTextLayout(ds, value, textFormat, 250, 0);
            var txt = utils.GetTranslation(title, languageOne);
            if (!string.IsNullOrEmpty(vat)) { txt += "(" + vat + "%)"; }
            CanvasTextLayout txtLayout = new CanvasTextLayout(ds, txt, textFormat, 250, 0);


            if (!string.IsNullOrEmpty(languageTwo))
            {
                var txt2 = utils.GetTranslation(title, languageTwo);
                if (!string.IsNullOrEmpty(vat)) { txt2 += "(" + vat + "%)"; }
                CanvasTextLayout txt2Layout = new CanvasTextLayout(ds, txt2, textFormat, 250, 0);

                float end = width - 80;


                if (reverse)
                {
                    ds.DrawText(txt2, new Vector2(0, y), Colors.Black, textFormat);
                    ds.DrawText(txt, new Vector2(end - (int)txtLayout.DrawBounds.Width, y), Colors.Black, textFormat);
                    ds.DrawText(value, new Vector2(width - (int)valueLayout.DrawBounds.Width, y), Colors.Black, textFormat);

                }
                else
                {
                    ds.DrawText(txt, new Vector2(0, y), Colors.Black, textFormat);
                    ds.DrawText(txt2, new Vector2(end - (int)txt2Layout.DrawBounds.Width, y), Colors.Black, textFormat);
                    ds.DrawText(value, new Vector2(width - (int)valueLayout.DrawBounds.Width, y), Colors.Black, textFormat);
                }
            }
            else
            {
                ds.DrawText(txt, new Vector2(0, y), Colors.Black, textFormat);
                ds.DrawText(value, new Vector2(width - (int)valueLayout.DrawBounds.Width, y), Colors.Black, textFormat);
            }

            return (float)valueLayout.DrawBounds.Height + 7f;
            */
            ds.DrawString(value, regular, drawBrush, new RectangleF(0, y, 280, 0F));
            return 14f;
        }

        public static float DrawVATInclusive(Graphics ds, float y, double? num, string title, string vat, int rounds, bool bold, string languageOne, string languageTwo, bool reverse, string currency)
        {
            /*
            var textFormat = new CanvasTextFormat()
            {
                FontFamily = bold ? "Assets/Tajawal-Bold.ttf#Tajawal" : "Assets/Tajawal-Regular.ttf#Tajawal",
                FontSize = 14f,
            };

            var text2Format = new CanvasTextFormat()
            {
                FontFamily = bold ? "Assets/Tajawal-Bold.ttf#Tajawal" : "Assets/Tajawal-Regular.ttf#Tajawal",
                FontSize = 14f,
                Direction = CanvasTextDirection.RightToLeftThenTopToBottom
            };



            Rect rectTxt;
            Rect rectTxt2;

            var txt = utils.GetTranslation(title, languageOne);
            if (!string.IsNullOrEmpty(vat)) { txt += "(" + vat + "%)"; }
            CanvasTextLayout txtLayout = new CanvasTextLayout(ds, txt, textFormat, 250, 0);

            float height = (float)txtLayout.DrawBounds.Height;
            if (!string.IsNullOrEmpty(languageTwo))
            {
                var txt2 = utils.GetTranslation(title, languageTwo);
                CanvasTextLayout txt2Layout = new CanvasTextLayout(ds, txt2, text2Format, 250, 0);

                if (txt2Layout.DrawBounds.Height > txtLayout.DrawBounds.Height)
                {
                    height = (float)txt2Layout.DrawBounds.Height;
                }



                if (reverse)
                {
                    rectTxt = new Rect(width - (int)txtLayout.DrawBounds.Width - 50, y, txt2Layout.DrawBounds.Width, txtLayout.DrawBounds.Y);
                    rectTxt2 = new Rect(0, y, txt2Layout.DrawBounds.Width, txt2Layout.DrawBounds.Y);

                    ds.DrawText(txt2, rectTxt2, Colors.Black, textFormat);
                    ds.DrawText(txt, rectTxt, Colors.Black, textFormat);
                }
                else
                {
                    rectTxt2 = new Rect(width - (int)txtLayout.DrawBounds.Width - 40, y, width / 2, txt2Layout.DrawBounds.Y);
                    rectTxt = new Rect(0, y, txtLayout.DrawBounds.Width, txtLayout.DrawBounds.Y);

                    ds.DrawText(txt, rectTxt, Colors.Black, textFormat);
                    ds.DrawText(txt2, rectTxt2, Colors.Black, text2Format);
                }
            }
            else
            {

                ds.DrawText(txt, new Vector2(0, y), Colors.Black, textFormat);
                //ds.DrawText(value, new Vector2(width - (int)valueLayout.DrawBounds.Width, y), Colors.Black, textFormat);
            }



            return height + 7f;
            */
            var txt = utils.GetTranslation(title, languageOne);
            ds.DrawString(txt, regular, drawBrush, new RectangleF(0, y, 280, 0F));
            return 14f;
        }

        public static float DrawTaxes(Graphics ds, float y, List<printedTax> order_taxes, int rounds, string languageTwo, bool reverse, string currency)
        {
            /*
            float yx = 0;
            if (order_taxes != null)
            {

                foreach (printedTax tax in order_taxes)
                {
                    var textFormat = new CanvasTextFormat()
                    {
                        FontFamily = "Assets/Tajawal-Regular.ttf#Tajawal",
                        FontSize = 14f,
                    };

                    string value = tax.total.ToString("F" + rounds);
                    value += " " + currency;
                    CanvasTextLayout valueLayout = new CanvasTextLayout(ds, value, textFormat, 250, 0);
                    var txt = tax.name_lan_p;
                    if (tax.isPercent)
                    {
                        txt += "(" + tax.amount + "%)";
                    }
                    else
                    {
                        txt += "(" + tax.amount + ")";
                    }

                    CanvasTextLayout txtLayout = new CanvasTextLayout(ds, txt, textFormat, 250, 0);

                    if (!string.IsNullOrEmpty(languageTwo))
                    {
                        var txt2 = tax.name_lan_s;
                        if (tax.isPercent)
                        {
                            txt2 += "(" + tax.amount + "%)";
                        }
                        else
                        {
                            txt2 += "(" + tax.amount + ")";
                        }
                        CanvasTextLayout txt2Layout = new CanvasTextLayout(ds, txt2, textFormat, 250, 0);

                        float end = width - 80;


                        if (reverse)
                        {
                            ds.DrawText(txt2, new Vector2(0, yx + y), Colors.Black, textFormat);
                            ds.DrawText(txt, new Vector2(end - (int)txtLayout.DrawBounds.Width, yx + y), Colors.Black, textFormat);
                            ds.DrawText(value, new Vector2(width - (int)valueLayout.DrawBounds.Width, y), Colors.Black, textFormat);

                        }
                        else
                        {
                            ds.DrawText(txt, new Vector2(0, yx + y), Colors.Black, textFormat);
                            ds.DrawText(txt2, new Vector2(end - (int)txt2Layout.DrawBounds.Width, yx + y), Colors.Black, textFormat);
                            ds.DrawText(value, new Vector2(width - (int)valueLayout.DrawBounds.Width, yx + y), Colors.Black, textFormat);
                        }
                    }
                    else
                    {



                        ds.DrawText(txt, new Vector2(0, yx + y), Colors.Black, textFormat);
                        ds.DrawText(value, new Vector2(width - (int)valueLayout.DrawBounds.Width, yx + y), Colors.Black, textFormat);

                    }
                    yx += (float)valueLayout.DrawBounds.Height + 7f;
                }
            }
            return yx;
            */

            ds.DrawString("tax", regular, drawBrush, new RectangleF(0, y, 280, 0F));
            return 14f;
        }

        public static float DrawPaymentInfo(Graphics ds, float y, string info, string title, string vat, int rounds, bool bold, string languageOne, string languageTwo, bool reverse)
        {
            /*
            var textFormat = new CanvasTextFormat()
            {
                FontFamily = bold ? "Assets/Tajawal-Bold.ttf#Tajawal" : "Assets/Tajawal-Regular.ttf#Tajawal",
                FontSize = 14f,
            };


            CanvasTextLayout valueLayout = new CanvasTextLayout(ds, info, textFormat, 250, 0);
            var txt = utils.GetTranslation(title, languageOne);
            if (!string.IsNullOrEmpty(vat)) { txt += "(" + vat + "%)"; }
            CanvasTextLayout txtLayout = new CanvasTextLayout(ds, txt, textFormat, 250, 0);


            if (!string.IsNullOrEmpty(languageTwo))
            {
                var txt2 = utils.GetTranslation(title, languageTwo);
                if (!string.IsNullOrEmpty(vat)) { txt2 += "(" + vat + "%)"; }
                CanvasTextLayout txt2Layout = new CanvasTextLayout(ds, txt2, textFormat, 250, 0);

                float end = width - 80;


                if (reverse)
                {
                    ds.DrawText(txt2, new Vector2(0, y), Colors.Black, textFormat);
                    ds.DrawText(txt, new Vector2(end - (int)txtLayout.DrawBounds.Width, y), Colors.Black, textFormat);
                    ds.DrawText(info, new Vector2(width - (int)valueLayout.DrawBounds.Width, y), Colors.Black, textFormat);

                }
                else
                {
                    ds.DrawText(txt, new Vector2(0, y), Colors.Black, textFormat);
                    ds.DrawText(txt2, new Vector2(end - (int)txt2Layout.DrawBounds.Width, y), Colors.Black, textFormat);
                    ds.DrawText(info, new Vector2(width - (int)valueLayout.DrawBounds.Width, y), Colors.Black, textFormat);
                }
            }
            else
            {
                if (reverse)
                {
                    ds.DrawString(info, new Vector2(0, y), Colors.Black, textFormat);
                    ds.DrawString(txt, new Vector2(width - (int)txtLayout.DrawBounds.Width, y), Colors.Black, textFormat);
                }
                else
                {
                    ds.DrawString(txt, new Vector2(0, y), Colors.Black, textFormat);
                    ds.DrawString(info, new Vector2(width - (int)valueLayout.DrawBounds.Width, y), Colors.Black, textFormat);
                }
            }

            return (float)valueLayout.DrawBounds.Height + 3f;
            */

            ds.DrawString(title, regular, drawBrush, new RectangleF(0, y, 280, 0F));
            return 14f;
        }

        public static void DrawStamp(Graphics ds, float y, string title, string languageOne)
        {
            /*
            var stampTextFormat = new CanvasTextFormat()
            {
                FontFamily = "Assets/Tajawal-Bold.ttf#Tajawal",
                FontSize = 15f,
                HorizontalAlignment = CanvasHorizontalAlignment.Justified,
                VerticalAlignment = CanvasVerticalAlignment.Center,

            };

            ds.Transform = Matrix3x2.CreateRotation((float)(Math.PI * 17 * -1 / 180.0), new Vector2((width / 2) + 25, y));
            string text = utils.GetTranslation(title, languageOne);

            CanvasTextLayout txtLayout = new CanvasTextLayout(ds, text, stampTextFormat, 250, 0);

            double h = txtLayout.DrawBounds.Height / 2;
            double w = txtLayout.DrawBounds.Width / 2;

            Rect r = new Rect((width / 2) - w, y * 0.65, txtLayout.DrawBounds.Width * 2.5, textFormat.FontSize * 2f);
            ds.DrawRectangle(r, Colors.Black);

            ds.DrawText(text, new Vector2((float)(r.X + h * 3), (float)(r.Y + w * 0.75)), Colors.Black, stampTextFormat);
            ds.Transform = Matrix3x2.CreateRotation(0);
            */
            string text = utils.GetTranslation(title, languageOne);
            ds.DrawString(text, regular, drawBrush, new RectangleF(0, y, 280, 0F));
            //ds.Transform = Matrix3x2.CreateRotation(0);

        }

        public static float DrawLine(Graphics ds, float y)
        {
            //ds.DrawLine(new Vector2(0, y), new Vector2(width, y), Colors.Black, lineWidth);
            ds.DrawLine(blackPen, 0, y, width, y);
            return 1;
        }
        public static double GetItemPrice(double? price, double? qty, bool printWithVat, bool itemTaxable, double vat)
        {
            if (printWithVat && itemTaxable)
            {
                return ((price ?? 0) * (qty ?? 0)) * ((vat / 100) + 1);
            }
            else
            {
                return ((price ?? 0) * (qty ?? 0));
            }
        }
        public static double GetAddonPrice(double? price, double? addonQty, double? itemQty, bool printWithVat, bool itemTaxable, double vat)
        {
            if (printWithVat && itemTaxable)
            {
                return (price ?? 0) * (addonQty ?? 0) * (itemQty ?? 0) * ((vat / 100) + 1);
            }
            else
            {
                return (price ?? 0) * (addonQty ?? 0) * (itemQty ?? 0);
            }
        }
    }

}
