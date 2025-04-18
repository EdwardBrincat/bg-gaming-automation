using NUnit.Framework;

namespace LightBDD.Framework.Scenarios;

public static class LightBddExtensions
{
    public static void IgnoreScenario(this StepExecution execution, string reason) => throw new IgnoreException(reason);
}
