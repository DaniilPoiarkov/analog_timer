using AnalogTimer.Contracts;
using ConsoleApplicationBuilder.Prompts;

namespace AnalogTimer.Implementations;

public class AnalogTimerPromptServiceBuilder : PromptServiceBuilder<IAnalogTimer>
{
    public AnalogTimerPromptServiceBuilder(IAnalogTimer entity)
        : base(entity)
    {
    }
}
