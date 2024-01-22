ASP.NET Core Web API

+ Send emails using **POST** request to /api/mails with a **JSON** data format:

**{
  "subject": "Email subject ",
  "body": "Email text",
  "receivers": ["receiver1@gmail.com"]
}**

The email data will be added to the database, plus the result of the operation (Success, Failure, FailureMessage)

+ Receive all emails sent from database with a **GET** request to /api/mails in a JSON format

  [
  {
    "id": 1,
    "subject": "string",
    "body": "string",
    "email_date": "2024-01-22T00:00:00",
    "receiversList": [
      "string"
    ],
    "result": "Success",
    "failedMessage": ""
  },
  {
    "id": 2,
    "subject": "string",
    "body": "string",
    "email_date": "2024-01-22T00:00:00",
    "receiversList": [
      "string1",
      "string2",
      "string3"
    ],
    "result": "Success",
    "failedMessage": ""
  }
  ]
