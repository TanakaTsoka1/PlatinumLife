using Microsoft.AspNetCore.Mvc;
using Platinum_Life.Data.Services;
using PlatinumLife.Models;
using PdfSharpCore;
using PdfSharpCore.Pdf;
using TheArtOfDev.HtmlRenderer.PdfSharp;
using static System.Runtime.InteropServices.JavaScript.JSType;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Platinum_Life.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IInvoiceService _service;

        public InvoiceController(IInvoiceService service)
        {
            _service = service;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var invoices = await _service.GetInvoicesAsync();
            return View(invoices);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Invoice invoice)
        {
            if (!ModelState.IsValid)
            {
                return View(invoice);
            }

            await _service.CreateInvoiceAsync(invoice);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var invoice = await _service.GetInvoiceAsync(id);
            if (invoice == null)
            {
                return View("Not Found ");
            }

            return View(invoice);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Invoice invoice)
        {

            if (!ModelState.IsValid)
            {
                return View(invoice);
            }

            await _service.UpdateInvoiceAsync(id, invoice);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var invoice = await _service.GetInvoiceAsync(id);
            if (invoice == null)
            {
                return View("Not Found");
            }

            return View(invoice);
        }


        public async Task<ActionResult> Sign(int id)
        {
            var document = new PdfDocument();


            string imgeurl = "signature.webp";
            ;

            Invoice header = await _service.GetInvoiceAsync(id);
            string htmlcontent = "<div style='width:100%; text-align:center'>";
            htmlcontent += "<h2>Platinum Life</h2>";

            if (header != null)
            {
                htmlcontent += "<h2> Invoice No:" + header.InvoiceId + " & Invoice Date: " +  header.InvoiceDate.Date + "</h2>";
                htmlcontent += "<h3> Department : " + header.Department + "</h3>";
                htmlcontent += "<h3> Submitter :" + header.Submitter + " </h3>";
                htmlcontent += "<div>";
            }



            htmlcontent += "<table style ='width:100%; border: 1px solid #000'>";
            htmlcontent += "<thead style='font-weight:bold'>";
            htmlcontent += "<tr>";
            htmlcontent += "<td style='border:1px solid #000'> Bank </td>";
            htmlcontent += "<td style='border:1px solid #000'>Account</td >";
            htmlcontent += "<td style='border:1px solid #000'> Description </td>";
            htmlcontent += "<td style='border:1px solid #000'> Recipient </td>";
            htmlcontent += "<td style='border:1px solid #000'>Approver</td >";

            htmlcontent += "</tr>";
            htmlcontent += "</thead >";

            htmlcontent += "<tbody>";

            htmlcontent += "<tr>";
            htmlcontent += "<td>" + header.PaymentRecipientBank + "</td>";
            htmlcontent += "<td>" + header.PaymentRecipientAccount + "</td>";
            htmlcontent += "<td>" + header.PaymentDescription + "</td>";
            htmlcontent += "<td>" + header.PaymentRecipientName + "</td>";
            htmlcontent += "<td>" + header.SigningManager + "</td>";
            htmlcontent += "</tr>";

            htmlcontent += "</tbody>";

            htmlcontent += "</table>";
            htmlcontent += "</div>";


            PdfGenerator.AddPdfPages(document, htmlcontent, PageSize.A4);

            byte[]? response = null;
            using (MemoryStream ms = new MemoryStream())
            {
                document.Save(ms);
                response = ms.ToArray();
            }
            string Filename = "Invoice_" + id + ".pdf";
            return File(response, "application/pdf", Filename);
        }
    }
}

