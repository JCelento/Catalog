﻿using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EletronicPartsCatalog.Api.Domain;
using EletronicPartsCatalog.Infrastructure;
using EletronicPartsCatalog.Infrastructure.Errors;
using EletronicPartsCatalog.Infrastructure.Security;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EletronicPartsCatalog.Features.Users
{
    public class Create
    {
        public class UserData
        {
            public string Username { get; set; }

            public string Email { get; set; }

            public string Password { get; set; }

            public string PasswordConfirmation { get; set; }

        }

        public class UserDataValidator : AbstractValidator<UserData>
        {
            public UserDataValidator()
            {
                RuleFor(x => x.Username).NotNull().WithMessage(" O campo username é obrigatório.");
                RuleFor(x => x.Username).NotEmpty().WithMessage(" O campo username deve ser preenchido.");
                RuleFor(x => x.Email).NotNull().WithMessage(" O campo e-mail é obrigatório.");
                RuleFor(x => x.Email).NotEmpty().WithMessage(" O campo de e-mail deve ser preenchido.");
                RuleFor(x => x.Email).EmailAddress().WithMessage(" O campo e-mail deve ser um endereço de email valido.");
                RuleFor(x => x.Password).NotNull().WithMessage(" O campo senha é obrigatório.");
                RuleFor(x => x.Password).NotEmpty().WithMessage(" O campo de senha deve ser preechido.");
                RuleFor(x => x.PasswordConfirmation).NotNull().WithMessage(" O campo username é obrigatório..");
                RuleFor(x => x.PasswordConfirmation).NotEmpty().WithMessage(" O campo de confirmação de senha deve ser preenchido.");
                RuleFor(x => x.PasswordConfirmation).Matches(a => a.Password).WithMessage(" A senha e a confirmação devem ser iguais.");
            }
        }

        public class Command : IRequest<UserEnvelope>
        {
            public UserData User { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.User).NotNull().SetValidator(new UserDataValidator());
            }
        }

        public class Handler : IRequestHandler<Command, UserEnvelope>
        {
            private readonly EletronicPartsCatalogContext _context;
            private readonly IPasswordHasher _passwordHasher;
            private readonly IJwtTokenGenerator _jwtTokenGenerator;
            private readonly IMapper _mapper;

            public Handler(EletronicPartsCatalogContext context, IPasswordHasher passwordHasher, IJwtTokenGenerator jwtTokenGenerator, IMapper mapper)
            {
                _context = context;
                _passwordHasher = passwordHasher;
                _jwtTokenGenerator = jwtTokenGenerator;
                _mapper = mapper;
            }

            public async Task<UserEnvelope> Handle(Command message, CancellationToken cancellationToken)
            {
                if (await _context.Persons.Where(x => x.Username == message.User.Username).AnyAsync(cancellationToken))
                {
                    throw new RestException(HttpStatusCode.BadRequest, new { User = $"Username {message.User.Username} is already taken." });
                }

                if (await _context.Persons.Where(x => x.Email == message.User.Email).AnyAsync(cancellationToken))
                {
                    throw new RestException(HttpStatusCode.BadRequest, new { User = $"E-mail {message.User.Email} is already taken." });
                }

                var salt = Guid.NewGuid().ToByteArray();
                var person = new Person
                {
                    Username = message.User.Username,
                    Email = message.User.Email,
                    Hash = _passwordHasher.Hash(message.User.Password, salt),
                    Salt = salt
                };

                _context.Persons.Add(person);
                await _context.SaveChangesAsync(cancellationToken);
                var user = _mapper.Map<Person, User>(person);
                user.Token = await _jwtTokenGenerator.CreateToken(person.Username);
                return new UserEnvelope(user);
            }
        }
    }
}
