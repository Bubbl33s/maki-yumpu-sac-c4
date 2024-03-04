using MakiYumpuSAC.Models;

namespace MakiYumpuSAC.Services.Contract
{
    public interface IEmailService
    {
        void SendEmail(EmailDTO request);
    }
}
