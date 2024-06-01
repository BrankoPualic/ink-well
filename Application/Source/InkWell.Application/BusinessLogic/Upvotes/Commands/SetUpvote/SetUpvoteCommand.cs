using InkWell.Application.Abstractions.Messaging;
using InkWell.Application.Dtos.Upvote;

namespace InkWell.Application.BusinessLogic.Upvotes.Commands.SetUpvote;
public sealed record SetUpvoteCommand(EntryUpvoteDto Upvote) : ICommand;