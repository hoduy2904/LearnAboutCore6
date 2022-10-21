namespace LearnAboutNet6.Services
{
    public interface IMailServices
    {
        public bool SendMail(string subject, string body, string email);
    }
}
