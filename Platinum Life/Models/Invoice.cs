using System;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Platinum_Life.Data;


namespace PlatinumLife.Models
{
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }

        [Display(Name = "Submitter")]
        [Required(ErrorMessage ="Submitter Full name is required.")]
        public string Submitter { get; set; }

        [Display(Name = "Department")]
        [Required(ErrorMessage ="Invoice date is required.")]
        public Department Department { get; set; }

        [Display(Name = "Invoice Date")]
        [Required(ErrorMessage ="Invoice date is required.")]
        public DateTime InvoiceDate { get; set; }

        [Display(Name = "Payment Date")]
        [Required(ErrorMessage = "Payment date is required.")]
        public DateTime PaymentDate { get; set; }

        [Display(Name = "Recipient Name")]
        [Required(ErrorMessage = "Recipient name is required.")]
        public string PaymentRecipientName { get; set; }

        [Display(Name = "Recipient Bank")]
        [Required(ErrorMessage = "Recipient bank is required.")]

        public string PaymentRecipientBank { get; set; }

        [Display(Name = "Recipient Account")]
        [Required(ErrorMessage = "Recipient account is required.")]
        public string PaymentRecipientAccount { get; set; }

        [Display(Name = "Payment Description")]
        [Required(ErrorMessage = "Payment description is required.")]
        public string PaymentDescription { get; set; }

        [Display(Name = "Approved By")]
        [Required(ErrorMessage = "Signing manager is required.")]
        public string SigningManager { get; set; }
    }
}