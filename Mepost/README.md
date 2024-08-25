# Mepost SDK

**Mepost SDK** is a .NET library for interacting with the Mepost API, providing a simple interface for sending transactional emails, managing email groups, subscribers, and more. This SDK is compatible with .NET Standard 2.0, making it usable across a wide range of .NET platforms.

## Features

- Send transactional and marketing emails.
- Manage email groups and subscribers.
- Interact with IP groups and domain settings.
- Comprehensive error handling.

## Installation

You can install the Mepost SDK via NuGet Package Manager or the .NET CLI:

### Package Manager

```bash
Install-Package Mepost -Version 1.0.0
```

### .NET CLI

```bash
dotnet add package Mepost --version 1.0.0
```

## Getting Started

Here's a quick example of how to use the Mepost SDK to send a transactional email:

### 1. Initialize the Client

```csharp
using Mepost;

var mepostClient = new MepostClient("your_api_key");
```

### 2. Create a Transactional Email Request

```csharp
var request = new SendTransactionalRequest
{
    FromEmail = "sender@example.com",
    FromName = "Sender Name",
    Subject = "Test Transactional Email",
    Text = "This is the plain text version of the email.",
    Html = "<p>This is the <strong>HTML</strong> version of the email.</p>",
    To = new List<To>
    {
        new To
        {
            Email = "recipient@example.com",
            Name = "Recipient Name",
        }
    },
    Headers = new Dictionary<string, string>
    {
        { "X-Custom-Header", "Custom Value" }
    },
    Attachments = new List<AttachmentDto>
    {
        new AttachmentDto
        {
            FileName = "document.pdf",
            Base64Content = Convert.ToBase64String(System.IO.File.ReadAllBytes("path_to_your_file/document.pdf"))
        }
    }
};
```

### 3. Send the Email

```csharp
try
{
    var response = await mepostClient.SendTransactionalAsync(request);
    Console.WriteLine($"Email scheduled with ID: {response.Data.Uuid}");
}
catch (Exception ex)
{
    Console.WriteLine($"Error sending email: {ex.Message}");
}
```

## API Documentation

For a comprehensive guide to using the Mepost SDK, refer to the [API documentation](https://docs.mepost.io).

## Contributing

Contributions are welcome! Please check the [contributing guidelines](https://github.com/mepost-io/mepost-sdk/blob/main/CONTRIBUTING.md) before submitting a pull request.

## License

This project is licensed under the MIT License - see the [LICENSE](https://github.com/mepost-io/mepost-sdk/blob/main/LICENSE) file for details.

## Support

If you encounter any issues, please open an issue on the [GitHub repository](https://github.com/mepost-io/mepost-sdk/issues).
