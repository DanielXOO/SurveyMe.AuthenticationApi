using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;

namespace Authentication.Api.Configurations;

public static class Configurations
{
    public static IEnumerable<IdentityResource> Resources =>
        new List<IdentityResource>
        {
            new IdentityResources.OpenId()
        };

    public static IEnumerable<ApiScope> ApiScopes => new List<ApiScope>
    {
        new("UserInfoScope",  new[] {
            JwtClaimTypes.Name, 
            JwtClaimTypes.Id,
            JwtClaimTypes.Role
        }),
        new("ApisScope")
    };

    public static IEnumerable<Client> Clients =>
        new List<Client>
        {
            new()
            {
                ClientId = "client",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.OfflineAccess,
                    "UserInfoScope"
                },
                ClientSecrets =
                {
                    new Secret("client_secret".Sha256())
                },
                AllowOfflineAccess = true
            },
            new()
            {
                ClientId = "api",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes =
                {
                    "ApisScope"
                },
                ClientSecrets =
                {
                    new Secret("api_secret".Sha256())
                },
                AllowOfflineAccess = true
            }
        };

    public static IEnumerable<ApiResource> ApiResources =>
        new List<ApiResource>
        {
            new("Survey.Api")
            {
                ApiSecrets =
                {
                    new Secret("survey_secret".Sha256())
                },
                Scopes =
                {
                    "UserInfoScope",
                    "TestScope"
                }
            },
            new("Answers.Api")
            {
                ApiSecrets =
                {
                    new Secret("answers_secret".Sha256())
                },
                Scopes =
                {
                    "UserInfoScope"
                }
            },
            new("SurveyPersonOptions.Api")
            {
                ApiSecrets =
                {
                    new Secret("options_secret".Sha256())
                },
                Scopes =
                {
                    "UserInfoScope",
                    "ApisScope"
                }
            },
            new("Statistics.Api")
            {
                ApiSecrets =
                {
                    new Secret("statistics_secret".Sha256())
                },
                Scopes =
                {
                    "UserInfoScope"
                }
            },
            new("Persons.Api")
            {
                ApiSecrets =
                {
                    new Secret("persons_secret".Sha256())
                },
                Scopes =
                {
                    "UserInfoScope",
                    "ApisScope"
                }
            }
        };
}