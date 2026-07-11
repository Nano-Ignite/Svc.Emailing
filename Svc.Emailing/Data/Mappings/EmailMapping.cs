using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nano.Data.Mappings;
using Newtonsoft.Json;
using Svc.Emailing.Models.Data;
using Svc.Emailing.Models.Data.Enums;

namespace Svc.Emailing.Data.Mappings;

/// <inheritdoc />
public class EmailMapping : BaseEntityMapping<Email>
{
    /// <inheritdoc />
    public override void Configure(EntityTypeBuilder<Email> builder)
    {
        if (builder == null)
            throw new ArgumentNullException(nameof(builder));

        base.Configure(builder);

        builder
            .HasOne(x => x.User)
            .WithMany(x => x.Emails)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        builder
            .Property(x => x.Type)
            .HasDefaultValue(EmailType.None)
            .IsRequired();

        builder
            .HasIndex(x => x.Type);

        builder
            .Property(x => x.Data)
            .HasConversion(
                x => JsonConvert.SerializeObject(x),
                x => JsonConvert.DeserializeObject(x)!);
    }
}