using System.Threading.Tasks;

namespace SprungGermanServices
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
