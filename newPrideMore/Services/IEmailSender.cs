using System.Threading.Tasks;

namespace newPrideMore.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message, string name);
    }
}
