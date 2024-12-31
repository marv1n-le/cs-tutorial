using CS15_Mail.MailUtils;
using CS15_Mail.Service;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;


// Register services and configure options before app is built
builder.Services.AddOptions();
var mailSettings = configuration.GetSection("MailSettings");
builder.Services.Configure<MailSettings>(mailSettings); // Configure MailSettings
builder.Services.AddTransient<SendMailService>(); // Add SendMailService

var app = builder.Build();

app.UseRouting();
app.MapGet("/", () => "Hello World!");
app.UseEndpoints(ep =>
{
    ep.MapGet("/TestSendMail", async context =>
    {
        var message = await MailUtils.SendMail("anhldse170084@gmail.com", "ducanhle.iter@gmail.com", "Test send mail", "Hello from mail");
        await context.Response.WriteAsync(message); //fail vi chua co SMTP server (mailTransporter)
    });

    ep.MapGet("/TestGmail", async context =>
    {
        var message = await MailUtils.SendGmail("anhldse170084@fpt.edu.vn", "ktel esbf buuy coaa", "ádfasdf@gmail.com", "Test send mail ", "<!DOCTYPE html>\n<html>\n<head>\n    <style>\n        body {\n            font-family: Arial, sans-serif;\n            background-color: #f9f9f9;\n            color: #333;\n            margin: 0;\n            padding: 0;\n        }\n        .email-container {\n            max-width: 600px;\n            margin: 20px auto;\n            background-color: #ffffff;\n            padding: 20px;\n            border-radius: 8px;\n            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);\n        }\n        .header {\n            text-align: center;\n            padding-bottom: 20px;\n            border-bottom: 2px solid #f0f0f0;\n        }\n        .header h1 {\n            color: #0073e6;\n        }\n        .content {\n            margin-top: 20px;\n            line-height: 1.6;\n        }\n        .footer {\n            margin-top: 20px;\n            text-align: center;\n            font-size: 12px;\n            color: #888;\n        }\n        .btn {\n            display: inline-block;\n            padding: 10px 20px;\n            margin-top: 20px;\n            background-color: #0073e6;\n            color: #fff;\n            text-decoration: none;\n            border-radius: 4px;\n        }\n        .btn:hover {\n            background-color: #005bb5;\n        }\n    </style>\n</head>\n<body>\n    <div class=\"email-container\">\n        <div class=\"header\">\n            <h1>Welcome to Our Service!</h1>\n        </div>\n        <div class=\"content\">\n            <p>Hello <strong>Nicole Dang</strong>,</p>\n            <p>Thank you for signing up for our service. We’re excited to have you on board!</p>\n            <p>To get started, click the button below to verify your email address:</p>\n            <a href=\"https://example.com/verify-email\" class=\"btn\">Verify Email</a>\n            <p>If you have any questions, feel free to contact our support team at <a href=\"mailto:support@example.com\">support@example.com</a>.</p>\n            <p>Best regards,</p>\n            <p><strong>Marvin Le</strong></p>\n        </div>\n        <div class=\"footer\">\n            <p>&copy; 2024 Example Company. All rights reserved.</p>\n        </div>\n    </div>\n</body>\n</html>");
        await context.Response.WriteAsync(message); 
    });
    
    ep.MapGet("/TestSendMailService", async context =>
    {
        var sendMailService = context.RequestServices.GetService<SendMailService>();
        var mailContent = new SendMailService.MailContent();
        mailContent.To = "ducanhismyname@gmail.com";
        mailContent.Subject = "Test send mail service";
        mailContent.Body = "<h1>Hello from mail service</h1>";
        var message = await sendMailService.SendMail(mailContent);
        await context.Response.WriteAsync(message);
    });
});



app.Run();
