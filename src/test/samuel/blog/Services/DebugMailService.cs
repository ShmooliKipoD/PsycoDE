using System.Diagnostics;

namespace blog.Services
{
    public class DebugMailService : IMailService {

        public void SendMail(string to, string from, string subject, string body) {
            
            Debug.WriteLine($"Sending mail to: {to} from {from} subject {subject}");

        }
    }
}