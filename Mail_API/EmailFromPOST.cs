namespace Mail_API;

public class EmailFromPOST
{ 
    //model that will be used to retreive data from the POST request))
    public string subject { get; set; } //subject of the email received from POST
    public string body { get; set; } //body of the email
    public List<string> receivers { get; set; } //list of receivers
    
}
