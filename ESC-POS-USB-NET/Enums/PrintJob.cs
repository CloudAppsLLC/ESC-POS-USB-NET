using System;
using System.Collections.Generic;
using System.Text;
using Timestamp = Google.Protobuf.WellKnownTypes.Timestamp;

namespace ESC_POS_USB_NET.Enums
{
    class Order
    {
        public string branch_id { get; set; }

        public string client_id { get; set; }

        public string order_ref { get; set; }

        public string order_id { get; set; }

        public string order_number { get; set; }

        public double address_id { get; set; }

        public string customer_cell { get; set; }

        public string customer_name { get; set; }

        public string customer_id { get; set; }

        public string email { get; set; }

        public Timestamp order_date { get; set; }

        public double order_delivery_fee { get; set; }

        public string order_delivery_from { get; set; }

        public string order_delivery_to { get; set; }

        public string order_details { get; set; }

        public string cancelation_reason { get; set; }

        public string terminal_id { get; set; }

        public string order_lat { get; set; }
        public string refund_reason { get; set; }

        public string order_lng { get; set; }

        public double total_calories { get; set; }

        public double total { get; set; }

        public string order_status_id { get; set; }

        public double people_count { get; set; }

        public double reservation_id { get; set; }

        public string table_id { get; set; }

        public string table_name { get; set; }

        public string area_id { get; set; }

        public string area_name { get; set; }

        public int? waiting_id { get; set; }

        public string order_type { get; set; }

        public string source { get; set; }

        public string receipt { get; set; }

        public bool isVoid { get; set; }

        public bool isPaid { get; set; }
        public bool isRefund { get; set; }

        public string currency { get; set; }

        public string user_id { get; set; }

        public double tax { get; set; }

        public double taxes_charges { get; set; }

        public double discount { get; set; }


        public double loyalty_amount { get; set; }

        public string promo_code { get; set; }

        public string vat_number { get; set; }

        public bool order_printed { get; set; }


        public int? driver_id { get; set; }

        public bool driver_paid_lazywait_fee { get; set; }

        public DateTime? driver_paid_lazywait_fee_date { get; set; }

        public double? driver_lazywait_fee { get; set; }

        public double? driver_fee { get; set; }

        public int? esclation { get; set; }

        public bool? sms_ready_sent { get; set; }

        public DateTime? sms_ready_sent_time { get; set; }

        public double subtotal { get; set; }

        public double tax_percentage { get; set; }

        public double change { get; set; }

        public double received_amount { get; set; }

        public Timestamp order_pickup_date { get; set; }

        public List<order_item> order_items { get; set; }

        public List<order_payment> order_payments { get; set; }

        public List<order_tax> order_taxes { get; set; }
        public List<printedTax> printed_taxes { get; set; }
        public List<order_item> canceled_items { get; set; }

        public List<orderDiscount> order_discounts { get; set; }

        public string closing_id { get; set; }

        public string country_code { get; set; }

        public string user_name { get; set; }
        public List<order_item> unprinted_order_items { get; set; }

        public string ebill_email_sent { get; set; }
        public string ebill_sent { get; set; }
        public string qr { get; set; }
        public string group_id { get; set; }
        public string group_name { get; set; }
        public string externial_id { get; set; }
        public string receiptId { get; set; }
        public string channelOrderId { get; set; }
        public string channelOrderDisplayId { get; set; }
    }

    
    public class orderDiscount
    {

        public string order_discount_id { get; set; }

        public string order_id { get; set; }

        public string discount_id { get; set; }


        public bool? is_percentage { get; set; }


        public double amount { get; set; }


        public string note { get; set; }

        public string branch_id { get; set; }

        public string client_id { get; set; }

    }

    
    public class order_payment
    {

        public string branch_id { get; set; }

        public string client_id { get; set; }

        public double? order_payment_id { get; set; }

        public string name_lan_p { get; set; }

        public string name_lan_s { get; set; }

        public Timestamp payment_date { get; set; }

        public double payment_amount { get; set; }

        public string terminal_id { get; set; }

        public string note { get; set; }

        public string closing_id { get; set; }

        public string order_ref { get; set; }
        public POSPayment pos_payment { get; set; }

    }

    
    public class POSPayment
    {
        public string Status { get; set; }
        public string Response_Code { get; set; }
        public string ECR_number { get; set; }
        public string Trans_Amount { get; set; }
        public string Card_Number { get; set; }
        public string Card_Expiry_Date { get; set; }
        public string Card_Type { get; set; }
        public string Approval_No { get; set; }
        public string Response_message { get; set; }
        public string Trans_Date { get; set; }
        public string Trans_Time { get; set; }
        public string RRN { get; set; }
        public DateTime? payment_date { get; set; }
        public string pos_provider { get; set; }
    }
    
    class order_tax
    {

        public string branch_id { get; set; }

        public string client_id { get; set; }

        public double amount { get; set; }

        public string name_lan_p { get; set; }

        public string name_lan_s { get; set; }

        public bool? isPercent { get; set; }

        public string tax_id { get; set; }

        public double tax_value { get; set; }

    }
    class order_item
    {

        public string branch_id { get; set; }

        public string client_id { get; set; }

        public string order_ref { get; set; }

        public string order_item_id { get; set; }

        public string menu_item_id { get; set; }

        public string menu_category_id { get; set; }

        public string name_lan_s { get; set; }

        public string name_lan_p { get; set; }

        public string cat_name_lan_s { get; set; }


        public string cat_name_lan_p { get; set; }

        public double? quantity { get; set; }

        public string details { get; set; }

        public string order_id { get; set; }

        public double? price { get; set; }

        //public double total_calories { get; set; }

        public string price_id { get; set; }

        public string printer_id { get; set; }
        /*  
         public string price_name_lan_p { get; set; }
          
         public string price_name_lan_s { get; set; }*/

        //public double? cost { get; set; }

        //public double? order_discount { get; set; }

        //public double? order_taxes { get; set; }

        //public double subtotal { get; set; }

        //public double? tax_percentage { get; set; }

        public List<order_item_addon> addons { get; set; }

        public List<order_item_discount> discounts { get; set; }

        public order_item_price order_item_price { get; set; }

        //public Dictionary<string, string> translated { get; set; }


        public bool? taxable { get; set; }

        public bool? cat_taxable { get; set; }

        public List<order_tax> taxes { get; set; }

        public bool? stock_enabled { get; set; }

        public List<string> sources_ids { get; set; }

        public List<Source> sources { get; set; }

        //public DateTime? order_item_ready { get; set; }

        //public DateTime? order_ready { get; set; }
        public bool not_taxable { get; set; }
    }

    class order_item_addon
    {

        public string branch_id { get; set; }

        public string client_id { get; set; }

        public string order_addon_id { get; set; }

        public string name_lan_s { get; set; }

        public string name_lan_p { get; set; }

        public double? price { get; set; }

        public string addon_id { get; set; }

        public bool? is_without { get; set; }

        public double? calories { get; set; }

        public bool is_addon { get; set; }

        public string menu_category_id { get; set; }

        public double? quantity { get; set; }

        public translated translated { get; set; }

    }
    
    class order_item_discount
    {

        public string branch_id { get; set; }

        public string client_id { get; set; }

        public string item_discount_id { get; set; }

        public double amount { get; set; }

        public string order_item_discount_id { get; set; }

        public string discount_name { get; set; }

        public bool? is_percentage { get; set; }


        public string menu_item_id { get; set; }

        public string menu_category_id { get; set; }

        public double value { get; set; }

    }

    
    class order_item_price
    {

        public string branch_id { get; set; }

        public string client_id { get; set; }

        public string name_lan_p { get; set; }

        public string name_lan_s { get; set; }

        public double price { get; set; }

        public string price_id { get; set; }

        public string barcode { get; set; }

        public double? cost { get; set; }

        public string menu_item_id { get; set; }

        public string menu_category_id { get; set; }

        public double? loyalty_points { get; set; }

        public double? calories { get; set; }


    }

    
    class translated
    {
        public string ar { get; set; }
        public string de { get; set; }
        public string en { get; set; }
        public string es { get; set; }
        public string fr { get; set; }
        public string hi { get; set; }
        public string id { get; set; }
        public string it { get; set; }
        public string ja { get; set; }
        public string ko { get; set; }
        public string ne { get; set; }
        public string nl { get; set; }
        public string pa { get; set; }
        public string pl { get; set; }
        public string pt { get; set; }
        public string ru { get; set; }
        public string yl { get; set; }
        public string tr { get; set; }
        public string ur { get; set; }

    }

    class PrintJob
    {
        public string id { get; set; }

        public string type { get; set; }

        public Order order { get; set; }

        public order_item[] order_items { get; set; }

        public bool kick { get; set; }

        public bool isCanceledItems { get; set; }

        public bool isReprint { get; set; }
        public Printer printer { get; set; }

        public string closing { get; set; }

        public string uri { get; set; }

    }

    public class CardPayment
    {
        public double? DEBIT { get; set; }
        public double? CREDIT { get; set; }
    }

    public class CashierClosing
    {
        public string branch_id { get; set; }

        public string client_id { get; set; }

        public string branch_name_lan_p { get; set; }

        public string branch_name_lan_s { get; set; }

        public string terminal_id { get; set; }

        public string terminal_name { get; set; }

        public double? loss { get; set; }

        public string user_name { get; set; }

        public string user_id { get; set; }

        public string closing_id { get; set; }

        public Timestamp closing_date { get; set; }

        public Timestamp cashier_opening_date { get; set; }
        public double? closing_drawer_cash_start { get; set; }

        public double? closing_drawer_cash_end { get; set; }

        public string closing_drawer_cash_start_user_name { get; set; }

        public string closing_bank_user_id { get; set; }

        public double? closing_bank_transfer { get; set; }

        public double? closing_cards_sales { get; set; }

        public double? closing_cards_sales_received { get; set; }

        public double? closing_cards_balanced { get; set; }

        public Dictionary<string, dynamic> closing_cards_balanced_per_type { get; set; }

        public double? closing_other_sales { get; set; }

        public double? closing_other_sales_received { get; set; }

        public double? closing_other_balanced { get; set; }

        public Dictionary<string, dynamic> closing_other_balanced_per_type { get; set; }

        public double? closing_cash_sales { get; set; }

        public double? closing_cash_sales_received { get; set; }

        public double? closing_cash_add { get; set; }

        public double? closing_cash_remove { get; set; }

        public double? closing_cash_balanced { get; set; }

        public double? closing_sales_total { get; set; }

        public double? closing_loyalty_sales { get; set; }

        public DrawerOpening[] without_sales_openings { get; set; }
        public CardPayment closing_cards_payments { get; set; }

        public Dictionary<string, dynamic> closing_payments_total { get; set; }

        public double? opening_drawer_cash_start { get; set; }

        public string opening_user_name { get; set; }

        public string opening_user_id { get; set; }

        public string closing_reason { get; set; }

        //public order_payment[] sales { get; set; }

        public string version { get; set; }
    }

    public class DrawerOpening
    {
        public Timestamp date { get; set; }

        public string drawer_opening_id { get; set; }

        public string closing_id { get; set; }

        public string user_id { get; set; }

        public string name { get; set; }

        public double? payment { get; set; }

        public string terminal_id { get; set; }

        public string branch_id { get; set; }

        public string client_id { get; set; }


    }



    public class Printer
    {
        public string branch_id { get; set; }

        public string bill_printer_id { get; set; }

        public string receipt_printer_id { get; set; }


        public string client_id { get; set; }

        public string printer_id { get; set; }

        public string printer_ip { get; set; }

        public string printer_port { get; set; }

        public string printer_brand { get; set; }

        public string printer_type { get; set; }

        public string paper_size { get; set; }

        public Boolean has_drawer { get; set; }

        public string printer_name { get; set; }

        public string display_name { get; set; }

        public string mac_address { get; set; }

        public string usb_path { get; set; }

        public string[] purpose { get; set; }


    }

    class Dictionary
    {
        public string en { get; set; }

        public string ar { get; set; }

        public string key { get; set; }

        public translated translated { get; set; }
    }

    class Source
    {

        public string[] branches_ids { get; set; }

        public string client_id { get; set; }



        public string name_lan_p { get; set; }

        public string name_lan_s { get; set; }

        public string source_id { get; set; }

        public string price_id { get; set; }

        public string menu_item_id { get; set; }

        public string menu_category_id { get; set; }
        public string photo { get; set; }
        public double pirce { get; set; }
        public string unit { get; set; }

        public double consumption { get; set; }
        public double alert_level { get; set; }


    }

    class WindowsDevices
    {
        public string printer_name { get; set; }
        public string ip_address { get; set; }
        public string mac_address { get; set; }
        public string target { get; set; }
    }

    class SelectedBranch
    {
        public string client_id { get; set; }
        public string branch_id { get; set; }
        public string name_lan_p { get; set; }
        public string name_lan_s { get; set; }

    }

    class printedTax
    {

        public string tax_id { get; set; }
        public string name_lan_p { get; set; }
        public string name_lan_s { get; set; }
        public bool isPercent { get; set; }

        public double total { get; set; }
        public double amount { get; set; }


    }

    class Settings
    {
        public string branch_id { get; set; }

        public string client_id { get; set; }

        public bool? print_price_with_vat { get; set; }

        public bool? print_order_id { get; set; }

        public bool? receipt_show_customer_no { get; set; }

        public bool? bill_show_customer_no { get; set; }

        public bool? bill_show_pickup_date { get; set; }

        public bool? receipt_print_terminal { get; set; }

        public bool? receipt_print_item_discount { get; set; }

        public bool? bill_show_address { get; set; }

        public bool? bill_show_phone_number { get; set; }

        public bool? receipt_show_product_barcode_number { get; set; }

        public bool? bill_show_item_comment { get; set; }

        public bool? hide_calories { get; set; }

        public bool? receipt_show_order_comment { get; set; }

        public bool? bill_show_order_comment { get; set; }

        public bool? receipt_show_paid_stamp { get; set; }

        public bool? bill_show_logo { get; set; }
        public bool? bill_show_barcode { get; set; }

        public string vat_note { get; set; }

        public string receipt_footer { get; set; }

        public bool? receipt_show_barcode { get; set; }

        public string bill_footer { get; set; }

        public string name_lan_p { get; set; }

        public string logo { get; set; }

        public string slogan { get; set; }

        public Langugage[] languages { get; set; }

        public Langugage[] order_language { get; set; }

        public int? order_print_copies { get; set; }

        public OrderTypes[] order_types { get; set; }

        public string address { get; set; }

        public string address1 { get; set; }

        public string bill_header { get; set; }

        public string receipt_header { get; set; }

        public string vatNumber { get; set; }

        public string phone { get; set; }

        public int? decimal_places { get; set; }

        public bool? order_show_table_name { get; set; }

        public string void_transaction_msg { get; set; }
        public string currency_lan_p { get; set; }

        public bool? order_show_servant_name { get; set; }
        public bool? order_show_customer_no { get; set; }

        public string reprint_order_items_msg { get; set; }
    }

    public class OrderTypes
    {
        public string branch_id { get; set; }

        public string client_id { get; set; }

        public string name_lan_p { get; set; }

        public string name_lan_s { get; set; }

    }

    public class Langugage
    {
        public string key { get; set; }

        public string type { get; set; }

        public string value { get; set; }

        public bool primary { get; set; }
    }


}
