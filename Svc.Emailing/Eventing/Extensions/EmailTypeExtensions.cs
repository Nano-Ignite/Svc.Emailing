using System;
using Svc.Emailing.Models.Data.Enums;

namespace Svc.Emailing.Eventing.Extensions;

internal static class EmailTypeExtensions
{
    internal static string GetEmailTemplate(this EmailType emailType)
    {
        return emailType switch
        {
            EmailType.Welcome => "d-57c85ec2586c45b584c135f0d51d3cd2",
            EmailType.ForgotPassword => "d-92898a882c3b43a6bca113973b469a60",
            EmailType.ChangeEmail => "d-c6117c943e6e4c47b718ca9279053f64",
            EmailType.None => "",
            _ => throw new ArgumentOutOfRangeException(nameof(emailType), emailType, null)
        };
    }
}