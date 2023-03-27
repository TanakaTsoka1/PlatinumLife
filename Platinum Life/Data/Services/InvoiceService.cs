using PlatinumLife.Models;
using Microsoft.EntityFrameworkCore;

namespace Platinum_Life.Data.Services
{
	public class InvoiceService: IInvoiceService
	{
        private readonly AppDbContext _context;

        public InvoiceService(AppDbContext context)
		{
            _context = context;
        }

        public async Task CreateInvoiceAsync(Invoice invoice)
        {
            await _context.Invoices.AddAsync(invoice);
            await _context.SaveChangesAsync();
        }

        public void DeleteInvoice(int invoiceId)
        {
            throw new NotImplementedException();
        }

        public async Task<Invoice> GetInvoiceAsync(int invoiceId)
        {

            var result = await _context.Invoices.FirstOrDefaultAsync(x => x.InvoiceId == invoiceId);

            return result;
        }

        public async Task<IEnumerable<Invoice>> GetInvoicesAsync()
        {
            return await _context.Invoices.ToListAsync();         
        }

        public async Task<Invoice> UpdateInvoiceAsync(int invoiceId, Invoice newInvoice)
        { 
            var invoice = _context.Update(newInvoice);

            var result = await _context.SaveChangesAsync();

            return newInvoice;
           
        }
    }
}

