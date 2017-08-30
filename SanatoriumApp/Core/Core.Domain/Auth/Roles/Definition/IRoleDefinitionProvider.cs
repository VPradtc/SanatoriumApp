using System;
using Core.Domain.Definition;

namespace Core.Domain.Auth.Roles.Definition
{
    public interface IRoleDefinitionProvider : IDefinitionProvider<RoleDefinition>
    {
        RoleDefinition GetByIdentifier(RoleIdentifier identifier);
    }
}
