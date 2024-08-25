// See https://aka.ms/new-console-template for more information

// Initialize the MepostClient with your API key

using Mepost.Clients;
using Mepost.Models.Requests;

var mepostClient = new MepostClient("mp-1ea79c19c8f3cb5160bc7a2cbf6524672ae7b70c578a4749f3c5149e9bec1366");

// Create the transactional email request
var request = new SendTransactionalRequest
{
    FromEmail = "test@testis.mepost.io",
    FromName = "Information",
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
    Customization = new Dictionary<string, string>
    {
        { "key1", "value1" },
        { "key2", "value2" }
    },
};

try
{
    // Send the transactional email
    var response = await mepostClient.SendTransactionalAsync(request);

    // Check the response
    if (response != null)
    {
        Console.WriteLine($"Email scheduled with ID: {response.Data.Uuid}");
    }
    else
    {
        Console.WriteLine("Failed to schedule the email.");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Error sending transactional email: {ex.Message}");
}
