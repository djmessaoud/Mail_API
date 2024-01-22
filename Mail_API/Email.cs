using System.Text.Json.Serialization;

namespace Mail_API;

public class Email //Email model for Read/Insert in the Database
{
    public int Id { get; set; } //Id of the Email in DB
    public string subject { get; set; } //subject of the email sent 
    public string body { get; set; } //the body of the email
  [JsonIgnore] public string receivers { get; set; } //Will use this one to insert into the db as one string (to not consume space) 
    public DateTime email_date { get; set; } //хотел DateOnly ну были проблемы в Dapper
    public List<string> ReceiversList { get; set; } //Will use this one to Display as a list and correctly serialize in JSON for the GET request
    public string Result { get; set; } //Result property of the email (Success/Fail)
    public string FailedMessage { get; set; } //message in case email failed to be sent
}