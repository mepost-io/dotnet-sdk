using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Mepost.Models.Responses
{
    public class Response<T>
    {
        [JsonProperty("success", Required = Required.Always)]
        public bool Success { get; set; }

        [JsonProperty("data", Required = Required.AllowNull)]
        public T Data { get; set; } // Data is now nullable

        [JsonProperty("errors", Required = Required.AllowNull)]
        public List<ErrorResponse> Errors { get; set; }
    }

    public class ErrorResponse
    {
        [JsonProperty("code")] public int Code { get; set; }

        [JsonProperty("message")] public string Message { get; set; }

        [JsonProperty("type")] public string Type { get; set; }
    }


    public class AddDomainResponse
    {
        public DNSRecord Dkim { get; set; }
        public DNSRecord Dmarc { get; set; }
        public string Domain { get; set; }
        public DNSRecord Spf { get; set; }
    }

    public class CancelWarmUpResponse
    {
        public string CancelledAt { get; set; }
        public string IpAddress { get; set; }
        public string StartedAt { get; set; }
    }

    public class GetMessageInfoResponse
    {
        public string Email { get; set; }
        public int EmailClicksCount { get; set; }
        public List<EmailClickDetail> EmailClicksDetail { get; set; }
        public int EmailReadsCount { get; set; }
        public List<EmailReadDetail> EmailReadsDetail { get; set; }
        public string State { get; set; }
        public string Subject { get; set; }
        public string TemplateId { get; set; }
    }

    public class GetScheduleInfoResponse
    {
        public ScheduleDetails Details { get; set; }
        public int EmailReadsCount { get; set; }
        public int EmailReadsUnique { get; set; }
        public int HardBounceCount { get; set; }
        public int LinkClicksCount { get; set; }
        public int OtherBounceCount { get; set; }
        public string SenderFromEmail { get; set; }
        public string SenderFromName { get; set; }
        public int SoftBounceCount { get; set; }
        public string State { get; set; }
        public string Subject { get; set; }
        public string TemplateId { get; set; }
        public int UnsubscribeCount { get; set; }
    }

    public class RemoveDomainResponse
    {
        public string Domain { get; set; }
        public string RemovedAt { get; set; }
    }

    public class SetIpGroupResponse
    {
        public string IpAddress { get; set; }
        public IPGroup IpGroup { get; set; }
    }

    public class StartWarmUpResponse
    {
        public string EndAt { get; set; }
        public string IpAddress { get; set; }
        public string StartAt { get; set; }
        public string Status { get; set; }
    }

    public class DNSRecord
    {
        public string Content { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }

    public class EmailClickDetail
    {
        public string City { get; set; }
        public string CountryCode { get; set; }
        public string Ip { get; set; }
        public string Url { get; set; }
    }

    public class EmailReadDetail
    {
        public string City { get; set; }
        public string CountryCode { get; set; }
        public string Ip { get; set; }
    }

    public class ScheduleDetails
    {
        public List<EmailTransactionEvent> Clicks { get; set; }
        public List<EmailTransactionEvent> HardBounces { get; set; }
        public List<EmailTransactionEvent> Reads { get; set; }
        public List<EmailTransactionEvent> SoftBounces { get; set; }
        public List<EmailTransactionEvent> Unsubscribes { get; set; }
    }

    public class EmailTransactionEvent
    {
        public string BounceCode { get; set; }
        public string City { get; set; }
        public string CountryCode { get; set; }
        public string CreatedAt { get; set; }
        public string Data { get; set; }
        public string EventType { get; set; }
        public string Id { get; set; }
        public string Ip { get; set; }
        public string StatId { get; set; }
        public string SubscriberId { get; set; }
        public string TransactionId { get; set; }
    }

    public class IPGroup
    {
        public int CompanyId { get; set; }
        public string CreatedAt { get; set; }
        public List<IpAddress> IpAddresses { get; set; }
        public string Name { get; set; }
        public string UpdatedAt { get; set; }
        public string Uuid { get; set; }
    }

    public class IpAddress
    {
        public int CompanyId { get; set; }
        public string CreatedAt { get; set; }
        public string Ip { get; set; }
        public int IpGroupId { get; set; }
        public string ReverseDNS { get; set; }
        public string Status { get; set; }
        public string UpdatedAt { get; set; }
        public string Uuid { get; set; }
    }

    public class Subscriber
    {
        [JsonProperty("bounced")] public bool Bounced { get; set; }

        [JsonProperty("confirmCode")] public string ConfirmCode { get; set; }

        [JsonProperty("confirmIp")] public string ConfirmIp { get; set; }

        [JsonProperty("confirmed")] public bool Confirmed { get; set; }

        [JsonProperty("createdAt")] public DateTime CreatedAt { get; set; }

        [JsonProperty("customFields")] public List<CustomField> CustomFields { get; set; }

        [JsonProperty("emailAddress")] public string EmailAddress { get; set; }

        [JsonProperty("emailGroupId")] public int EmailGroupId { get; set; }

        [JsonProperty("subscribedAt")] public DateTime SubscribedAt { get; set; }

        [JsonProperty("unsubscribed")] public bool Unsubscribed { get; set; }

        [JsonProperty("updatedAt")] public DateTime UpdatedAt { get; set; }

        [JsonProperty("uuid")] public string Uuid { get; set; }
    }

    public class CustomField
    {
        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("value")] public string Value { get; set; }
    }

    public class BaseResult<T>
    {
        [JsonProperty("data")] public List<T> Data { get; set; }

        [JsonProperty("total")] public int Total { get; set; }
    }

    public class Schedule
    {
        [JsonProperty("approved")] public bool Approved { get; set; }

        [JsonProperty("authorizedToSend")] public bool AuthorizedToSend { get; set; }

        [JsonProperty("createdAt")] public DateTime CreatedAt { get; set; }

        [JsonProperty("creditAmount")] public decimal CreditAmount { get; set; }

        [JsonProperty("emailGroupId")] public int EmailGroupId { get; set; }

        [JsonProperty("jobStatus")] public string JobStatus { get; set; }

        [JsonProperty("jobType")] public string JobType { get; set; }

        [JsonProperty("reason")] public string Reason { get; set; }

        [JsonProperty("resultType")] public string ResultType { get; set; }

        [JsonProperty("scheduledAt")] public DateTime ScheduledAt { get; set; }

        [JsonProperty("statId")] public string StatId { get; set; }

        [JsonProperty("template")] public Template Template { get; set; }

        [JsonProperty("updatedAt")] public DateTime UpdatedAt { get; set; }

        [JsonProperty("uuid")] public string Uuid { get; set; }
    }

    public class Template
    {
        [JsonProperty("config")] public string Config { get; set; }

        [JsonProperty("createdAt")] public DateTime CreatedAt { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("rawHtml")] public string RawHtml { get; set; }

        [JsonProperty("rawText")] public string RawText { get; set; }

        [JsonProperty("subject")] public string Subject { get; set; }

        [JsonProperty("updatedAt")] public DateTime UpdatedAt { get; set; }

        [JsonProperty("uuid")] public string Uuid { get; set; }
    }

    public class EmailGroupWithCounts
    {
        [JsonProperty("companyId")] public int CompanyId { get; set; }

        [JsonProperty("createdAt")] public DateTime CreatedAt { get; set; }

        [JsonProperty("generalScore")] public int GeneralScore { get; set; }

        [JsonProperty("isWeb")] public bool IsWeb { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("newsletterScore")] public int NewsletterScore { get; set; }

        [JsonProperty("priority")] public int Priority { get; set; }

        [JsonProperty("totalActiveSubscriber")]
        public int TotalActiveSubscriber { get; set; }

        [JsonProperty("totalBounced")] public int TotalBounced { get; set; }

        [JsonProperty("totalSubscriber")] public int TotalSubscriber { get; set; }

        [JsonProperty("totalUnsubscribe")] public int TotalUnsubscribe { get; set; }

        [JsonProperty("updatedAt")] public DateTime UpdatedAt { get; set; }

        [JsonProperty("uuid")] public string Uuid { get; set; }
    }

    public class EmailGroup
    {
        [JsonProperty("companyId")] public int CompanyId { get; set; }

        [JsonProperty("createdAt")] public DateTime CreatedAt { get; set; }

        [JsonProperty("generalScore")] public int GeneralScore { get; set; }

        [JsonProperty("isWeb")] public bool IsWeb { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("newsletterScore")] public int NewsletterScore { get; set; }

        [JsonProperty("priority")] public int Priority { get; set; }

        [JsonProperty("totalActiveSubscriber")]
        public int TotalActiveSubscriber { get; set; }

        [JsonProperty("totalSubscriber")] public int TotalSubscriber { get; set; }

        [JsonProperty("totalUnsubscribe")] public int TotalUnsubscribe { get; set; }

        [JsonProperty("updatedAt")] public DateTime UpdatedAt { get; set; }

        [JsonProperty("uuid")] public string Uuid { get; set; }
    }

    public class CompanyDomain
    {
        [JsonProperty("awsRegion")] public string AwsRegion { get; set; }

        [JsonProperty("awsVerified")] public bool AwsVerified { get; set; }

        [JsonProperty("company")] public Company Company { get; set; }

        [JsonProperty("companyId")] public int CompanyId { get; set; }

        [JsonProperty("createdAt")] public DateTime CreatedAt { get; set; }

        [JsonProperty("dkimContent")] public string DkimContent { get; set; }

        [JsonProperty("dkimName")] public string DkimName { get; set; }

        [JsonProperty("dkimPrivateKey")] public string DkimPrivateKey { get; set; }

        [JsonProperty("dkimSelector")] public string DkimSelector { get; set; }

        [JsonProperty("dkimVerified")] public bool DkimVerified { get; set; }

        [JsonProperty("dmarcContent")] public string DmarcContent { get; set; }

        [JsonProperty("dmarcName")] public string DmarcName { get; set; }

        [JsonProperty("dmarcVerified")] public bool DmarcVerified { get; set; }

        [JsonProperty("domain")] public string Domain { get; set; }

        [JsonProperty("hasAwsIdentity")] public bool HasAwsIdentity { get; set; }

        [JsonProperty("isVerified")] public bool IsVerified { get; set; }

        [JsonProperty("spfcontent")] public string SpfContent { get; set; }

        [JsonProperty("spfname")] public string SpfName { get; set; }

        [JsonProperty("spfverified")] public bool SpfVerified { get; set; }

        [JsonProperty("updatedAt")] public DateTime UpdatedAt { get; set; }

        [JsonProperty("uuid")] public string Uuid { get; set; }
    }

    public class Company
    {
        [JsonProperty("companyPlan")] public CompanyPlan CompanyPlan { get; set; }

        [JsonProperty("companyPlanID")] public int CompanyPlanId { get; set; }

        [JsonProperty("createdAt")] public DateTime CreatedAt { get; set; }

        [JsonProperty("footerHtml")] public string FooterHtml { get; set; }

        [JsonProperty("footerText")] public string FooterText { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("ownerId")] public int OwnerId { get; set; }

        [JsonProperty("priority")] public int Priority { get; set; }

        [JsonProperty("updatedAt")] public DateTime UpdatedAt { get; set; }

        [JsonProperty("uuid")] public string Uuid { get; set; }
    }

    public class CompanyPlan
    {
        [JsonProperty("companyID")] public int CompanyId { get; set; }

        [JsonProperty("createdAt")] public DateTime CreatedAt { get; set; }

        [JsonProperty("currentUsage")] public int CurrentUsage { get; set; }

        [JsonProperty("endedAt")] public DateTime EndedAt { get; set; }

        [JsonProperty("lastBilled")] public DateTime LastBilled { get; set; }

        [JsonProperty("pricingPlan")] public PricingPlan PricingPlan { get; set; }

        [JsonProperty("pricingPlanID")] public int PricingPlanId { get; set; }

        [JsonProperty("selectedContactsLimit")]
        public int SelectedContactsLimit { get; set; }

        [JsonProperty("selectedDataRetention")]
        public int SelectedDataRetention { get; set; }

        [JsonProperty("selectedEmailLimit")] public int SelectedEmailLimit { get; set; }

        [JsonProperty("startedAt")] public DateTime StartedAt { get; set; }

        [JsonProperty("status")] public string Status { get; set; }

        [JsonProperty("updatedAt")] public DateTime UpdatedAt { get; set; }

        [JsonProperty("uuid")] public string Uuid { get; set; }
    }

    public class PricingPlan
    {
        [JsonProperty("createdAt")] public DateTime CreatedAt { get; set; }

        [JsonProperty("dailyLimit")] public int DailyLimit { get; set; }

        [JsonProperty("maximumEmail")] public int MaximumEmail { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("planType")] public string PlanType { get; set; }

        [JsonProperty("updatedAt")] public DateTime UpdatedAt { get; set; }

        [JsonProperty("uuid")] public string Uuid { get; set; }
    }
}
