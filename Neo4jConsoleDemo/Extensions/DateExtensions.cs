using Neo4j.Driver;

namespace Neo4jConsoleDemo.Extensions;

public static class DateExtensions
{
    public static DateOnly ToDateOnly(this LocalDate d) => new(d.Year, d.Month, d.Day);
}
