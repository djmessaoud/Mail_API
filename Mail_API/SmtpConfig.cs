namespace Mail_API;

public class SmtpConfig
{
    //Model for SMTP config))
    public string server { get; set; } //server of the smtp
    public int port { get; set; } //port to be used
    public string username { get; set; } //username for authentication to the smtp
    public string password { get; set; } //password to be used to auth with username & server
}