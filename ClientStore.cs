using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace testIdentity
{
    public class ClientStore
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
    {
      new ApiResource("all", "all")
    };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
    {
      new IdentityResources.OpenId()
    };
        }

        public static IEnumerable<Client> GetClients()
        {
            yield return new Client
            {
                ClientName = "Client Credential Flow",
                ClientId = "client_credential_flow",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets =
  {
    new Secret("client_credential_flow_secret".Sha256())
  },
                AllowedScopes =
  {
    "all"
  },
                AllowOfflineAccess = false,
                AccessTokenLifetime = 60
            };

            yield return new Client
            {
                ClientName = "Resource Owner Flow",
                ClientId = "resource_owner_flow",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets =
  {
    new Secret("resource_owner_flow_secret".Sha256())
  },
                AllowedScopes =
  {
    IdentityServerConstants.StandardScopes.OpenId,
    IdentityServerConstants.StandardScopes.OfflineAccess
  },
                AllowOfflineAccess = true,
                RefreshTokenUsage = TokenUsage.ReUse,
                AccessTokenLifetime = 60,
                RefreshTokenExpiration = TokenExpiration.Absolute,
                AbsoluteRefreshTokenLifetime = 300
            };
        }
    }
}
