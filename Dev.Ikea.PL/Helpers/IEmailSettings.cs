using Dev.Ikea.DAL.Models;

namespace Dev.Ikea.PL.Helpers
{
    public interface IEmailSettings
    {
        public void SendEmail(Email Email);
    }
}
