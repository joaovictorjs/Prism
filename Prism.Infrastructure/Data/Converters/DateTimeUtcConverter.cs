using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Prism.Infrastructure.Data.Converters;

public class DateTimeUtcConverter : ValueConverter<DateTime, DateTime>
{
    public DateTimeUtcConverter()
        : base(toValue => toValue, fromValue => DateTime.SpecifyKind(fromValue, DateTimeKind.Utc))
    { }
}
