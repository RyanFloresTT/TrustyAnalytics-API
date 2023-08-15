using TrustyAnalytics.Models;

namespace API.Models;

public class DbInitializer
{
    public static void Initialize(TrustyAnalyticContext context)
    {
        if (context.Analytics.Any())
        {
            return;
        }

        var analytic = new Analytic() { AnalyticId = 0, EventId = 0, Timestamp = new DateTime(), Value = 0};

        context.AddRange(analytic);
        context.SaveChanges();
    }
}
