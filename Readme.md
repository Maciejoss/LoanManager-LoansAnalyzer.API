LoansAnalyzer is a project created for purpose of Web Application and .NET Framework course on Faculty of Mathematics and Information Science on Warsaw University of Technology.

LoansAnalyzer.API - the core backend repository of the project.

Core customer functionalities of the system include:
- Signing in or registering as a new user with Google account.
- Choosing a loan amount and number of installments to receive offers from 2+ mocked banks.
- Ability to apply for selected offer.
- Downloading additional information form in .pdf file provided by mocked bank.
- Uploading filled up form and sending in to the bank.
- Email notifications on changing inquiry status.
- Ability to view inquiry status.
- Ability to edit personal data.


Crucial bank employee functionalities include:
- Signing in via Google account.
- Viewing all inquiries sent to the bank.
- Manual reviewing of .pdf files filled and sent by customers.


Libraries used in this repository:
- Google.Apis.Auth
- Swashbuckle.AspNetCore
- System.IdentityModel.Tokens.Jwt
- Microsoft.EntityFrameworkCore
