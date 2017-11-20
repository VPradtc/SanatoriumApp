using System.Collections.Generic;
using System.Linq;

namespace Core.Domain.Auth.Roles.Definition
{
    public class RoleDefinitionProvider : IRoleDefinitionProvider
    {
        private readonly ICollection<RoleDefinition> _definitions =
            new List<RoleDefinition>
            {
                new RoleDefinition
                {
                    Identifier = RoleIdentifier.Admin,
                },
                new RoleDefinition
                {
                    Identifier = RoleIdentifier.MedicalStaff,
                },
                new RoleDefinition
                {
                    Identifier = RoleIdentifier.UtilityStaff,
                },
            };

        public ICollection<RoleDefinition> GetAll()
        {
            return _definitions;
        }

        public RoleDefinition GetByIdentifier(RoleIdentifier identifier)
        {
            return _definitions.SingleOrDefault(d => d.Identifier == identifier);
        }
    }
}
