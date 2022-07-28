namespace Task_Interview.ViewModel
{
    public class InvoiceDetailsVM
    {
        public long Id { get; set; }
        public long InvoiceHeaderId { get; set; }
        public string ItemName { get; set; } 
        public string Customer { get; set; }
        public double ItemCount { get; set; }
        public double ItemPrice { get; set; }
        public DateTime InvoiceDate { get; set; }
        public double TotalPriceForProduct { get { return ItemCount * ItemPrice; } }
    }
}
