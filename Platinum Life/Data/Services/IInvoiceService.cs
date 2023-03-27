using PlatinumLife.Models;

namespace Platinum_Life.Data.Services
{
	public interface IInvoiceService
	{
		Task<IEnumerable<Invoice>> GetInvoicesAsync();

		Task<Invoice> GetInvoiceAsync(int invoiceId);

		Task CreateInvoiceAsync(Invoice invoice);

		Task <Invoice> UpdateInvoiceAsync(int invoiceId, Invoice newInvoice);

		void DeleteInvoice(int invoiceId);
	}
}

