using Domain;

namespace Application.Commands.AutoMarkingCommand;

public sealed record AutoMarkingCommand(Exam exam): ICommand<Exam>;
