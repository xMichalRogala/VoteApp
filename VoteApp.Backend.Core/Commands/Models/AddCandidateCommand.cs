﻿using MediatR;
using VoteApp.Backend.Core.Data.Entities;

namespace VoteApp.Backend.Core.Commands.Models
{
    public class AddCandidateCommand : IRequest<Candidate>
    {
        public string Name { get; private set; } = string.Empty;

        public AddCandidateCommand(string name)
        {
            Name = name;
        }
    }
}
