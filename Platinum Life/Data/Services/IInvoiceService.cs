using PlatinumLife.Models;

namespace Platinum_Life.Data.Services
{
	public interface IInvoiceService
	{
		Task<IEnumerable<Invoice>> GetInvoicesAsync();

		Task<Invoice> GetInvoiceAsync(int invoiceId);

		Task CreateInvoiceAsync(Invoice invoice);

		Invoice UpdateInvoice(int invoiceId, Invoice newInvoice);

		void DeleteInvoice(int invoiceId);
	}
}

