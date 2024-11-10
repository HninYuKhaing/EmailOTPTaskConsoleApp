This project provides an implementation of an Email OTP module with the following functionalities:

OTP Generation: Generates a 6-digit random OTP code.
Email Sending: Sends the OTP code to user email addresses that end with specific domains.
OTP Validation: Validates the OTP entered by the user with 1 min timeouts and attempt limits to 10 times.

Email Functionality:
--------------------
<b>Assumptions:</b><br/>
The function send_email(email_address, email_body) is set up to send emails and is assumed to work correctly. If it successfully sends an email, it returns true; if not, it returns false.
<br/><b>Testing:</b><br/>
It validates the format of email address.
Only email addresses ending in .dso, .org or .sg can receive OTP codes. The check for these domains is not case-sensitive.

OTP Generation:
----------------
<b>Assumptions:</b><br/>
Generate 6-digit raddom OTP code and send it to user email.
Simulate as success and return true.
Hash the OTP to avoid storing OTPs in plain text.
<br/><b>Testing:</b><br/>
Enter the correct OTP within 10 attempts and within 1 minutes.
Enter the incorrect OTP within 10 attempts and within 1 minute and show verification OTP failed.
Enter the incorrect OTP within 10 attempts and over 1 minute and show OTP verification timed out.
After 10 attempts, entering OTP is not allowed.
After 1 minute, entering OTP is not allowed.

Future Enhancements
-------------------
Concurrency Handling for multiple users<br/>
Error Logging for monitoring and logging<br/>
Localization for email content to support multiple languages

