using FluentValidation;

namespace Evently.Modules.Events.Api.Events;

public sealed class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
{
    public CreateEventCommandValidator()
    {
        RuleFor(c => c.Title).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.Location).NotEmpty();
        RuleFor(c => c.StartsAtUtc).NotEmpty();
        RuleFor(c => c.EndsAtUtc).Must((cmd, endsatutc) => endsatutc > cmd.StartsAtUtc).When(c => c.EndsAtUtc.HasValue);
    }
}
