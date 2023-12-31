﻿using FunksjonellProgrammering.Shared.Primitives;

namespace FunksjonellProgrammering.UserApi;

public record User(Name Name, Role Role)
{
    public Name Name { get; } = Name ?? throw new ArgumentNullException(nameof(Name));
    public Role Role { get; } = Role ?? throw new ArgumentNullException(nameof(Role));
}