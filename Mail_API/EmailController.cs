using System.Data;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace Mail_API;
[Route("api/mails")]
[ApiController]


public class EmailController :ControllerBase
{
    private EmailService _emailService; //Email service // отправка почты и конфинурация
    private readonly string _connectionString; 
    //конструктор с иницялизации connString & emailService 
    public EmailController(EmailService _MailService, IConfiguration _configuration) 
    {
        _connectionString = _configuration.GetConnectionString("web_api_test");
        _emailService = _MailService;
    }
    //The GET request functionality
    [HttpGet]
    public async Task<IActionResult> GetMails()
    {
        using (IDbConnection dbConnection = new MySqlConnection(_connectionString)) //Connection to DB
        {
            try
            {
                dbConnection.Open();
                //Query для получении все почты на таблицу)
                string selectQuery = @"SELECT * FROM emails_sent";
                //Running the query
                var db_result = (await dbConnection.QueryAsync<Email>(selectQuery))
                    .Select(email => {     //Converting the receivers list from string to a List
                        email.ReceiversList = email.receivers.Split(';').ToList();
                        return email;
                    }).ToList();
                return Ok(db_result); //Returning the result
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }
    }
    //Function to send Email and add to DB [POST] reqest
    [HttpPost]
    public async Task<IActionResult> SendEmail([FromBody] EmailFromPOST email)
    {
       var mail_result= _emailService.sendEmail(email); //отправка почты через нащ Service
       var email_db = new Email() //создание обект для добавление в БД
       {
           subject = email.subject,
           body = email.body,
           receivers = String.Join(";", email.receivers), //Joining list to a one string using ';'
           Result = mail_result, //Result will be taken from the result of the mail sent (Default:Success)
           FailedMessage = "",
           email_date = DateTime.Now
       };
       //If result of mail is not success then we adjust  variables accordingly
       if (mail_result != "Success") 
       {
           email_db.FailedMessage = mail_result;
           email_db.Result = "Failed";
       }
       //Connecting to DB for insertion
       using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
       {
           //INSERT QUERY!))
           string insertQuery = @"INSERT INTO emails_sent (subject, body, receivers, Result, FailedMessage, email_date) 
                               VALUES (@subject, @body, @receivers, @Result, @FailedMessage, @email_date);";
            //RUN INSERT QUERY)
           var db_result = await dbConnection.ExecuteAsync(insertQuery, email_db);
        
       }
       //Depending on the reslt of the mail, we will send respond))
       if (mail_result == "Success") return Ok("Message sent!");
       else return BadRequest(mail_result);
    }
}