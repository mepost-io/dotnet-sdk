using System.Collections.Generic;

namespace Mepost.Models.Requests
{
    public class AddDomainRequest
    {
        public string Domain { get; set; }
    }

    public class CancelScheduledMessageRequest
    {
        public string ScheduledMessageId { get; set; }
    }

    public class CancelWarmUpRequest
    {
        public string IpAddress { get; set; }
    }

    public class CreateIpGroupRequest
    {
        public string GroupName { get; set; }
    }

    public class CreateNewGroupRequest
    {
        public string Name { get; set; }
        public List<To> To { get; set; }
    }

    public class CreateSubscriberRequest
    {
        public List<To> To { get; set; }
    }

    public class DeleteSubscriberRequest
    {
        public List<string> Emails { get; set; }
    }

    public class RenameGroupRequest
    {
        public string Name { get; set; }
    }

    public class SendMarketingRequest
    {
        public List<AttachmentDto> Attachments { get; set; }
        public Dictionary<string, string> Customization { get; set; }
        public string FromEmail { get; set; }
        public string FromName { get; set; }
        public Dictionary<string, string> Headers { get; set; }
        public string Html { get; set; }
        public string IpGroup { get; set; }
        public string ReturnPath { get; set; }
        public string ScheduledAt { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
        public List<string> To { get; set; }
    }

    public class SendMessageByTemplateRequest
    {
        public MessageDto Message { get; set; }
        public string TemplateId { get; set; }
    }

    public class SendTransactionalRequest
    {
        public List<AttachmentDto> Attachments { get; set; }
        public Dictionary<string, string> Customization { get; set; }
        public string FromEmail { get; set; }
        public string FromName { get; set; }
        public Dictionary<string, string> Headers { get; set; }
        public string Html { get; set; }
        public string IpGroup { get; set; }
        public string ReturnPath { get; set; }
        public string ScheduledAt { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
        public List<To> To { get; set; }
    }

    public class SetIpGroupRequest
    {
        public string GroupName { get; set; }
        public string IpAddress { get; set; }
    }

    public class StartWarmUpRequest
    {
        public string IpAddress { get; set; }
    }

    // Supporting DTO classes

    public class To
    {
        public Dictionary<string, string> Customization { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }

    public class AttachmentDto
    {
        public string Base64Content { get; set; }
        public string FileName { get; set; }
    }

    public class MessageDto
    {
        public List<AttachmentDto> Attachments { get; set; }
        public Dictionary<string, string> Customization { get; set; }
        public string FromEmail { get; set; }
        public string FromName { get; set; }
        public Dictionary<string, string> Headers { get; set; }
        public string Html { get; set; }
        public string IpGroup { get; set; }
        public string ReturnPath { get; set; }
        public string ScheduledAt { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
        public List<To> To { get; set; }
    }
}
