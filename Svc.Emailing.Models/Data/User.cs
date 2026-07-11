using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Nano.Data.Abstractions.Eventing.Annotations;
using Nano.Data.Abstractions.Models;

namespace Svc.Emailing.Models.Data;

/// <summary>
/// User.
/// </summary>
[Subscribe]
public class User : BaseEntity
{
    /// <summary>
    /// Full Name.
    /// </summary>
    [Required]
    [MaxLength(256)]
    public virtual string FullName { get; set; } = null!;

    /// <summary>
    /// Is Active.
    /// </summary>
    [Required]
    [EmailAddress]
    public virtual string EmailAddress { get; set; } = null!;

    /// <summary>
    /// Is Active.
    /// </summary>
    [Required]
    [DefaultValue(true)]
    public virtual bool IsActive { get; set; } = true;

    /// <summary>
    /// Emails
    /// </summary>
    [Required]
    public virtual IEnumerable<Email> Emails { get; set; } = new List<Email>();
}