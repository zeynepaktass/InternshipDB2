using System;
using System.Net.Mail;
using System.Linq;
using Internship_App2.Models; // Make sure to include the correct namespace for your models

public class EmailService
{
	private readonly string _smtpServer;
	private readonly int _smtpPort;

	public EmailService(IConfiguration configuration)
	{
		_smtpServer = configuration["Email:SmtpServer"];
		_smtpPort = int.Parse(configuration["Email:SmtpPort"]);
	}

	public void SendApprovalEmail(string studentEmail)
	{
		// Implement logic to send approval email using configured settings
		// (avoid including password directly in code)
		MailMessage mail = new MailMessage();
		// ... (set From, To, Subject, Body)
		SmtpClient smtp = new SmtpClient(_smtpServer, _smtpPort);
		// ... (set credentials from environment variable or configuration file)
		smtp.Send(mail);
	}

	public void SendRejectionEmail(string studentEmail)
	{
		// Implement similar logic for rejection email
	}
}
