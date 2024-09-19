using FluentValidation;

namespace Evently.Modules.Event.Application.Events.CancelEvent;

internal sealed class CancelEventCommandValidator : AbstractValidator<CancelEventCommand>
{
    public CancelEventCommandValidator()
    {
        RuleFor(c => c.EventId).NotEmpty();
    }
}
