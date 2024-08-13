using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace GeekShopping.IdentityServer
{
    public static class Config
    {
        public const string Admin = "Admin";
        public const string Client = "Client";
        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
               new IdentityResources.OpenId(),
               new IdentityResources.Email(),
               new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
                {
                    new ApiScope(name: "geek_shopping", displayName: "GeekShopping Server"),
                    new ApiScope(name: "read", displayName: "Read Data"),
                    new ApiScope(name: "write", displayName: "Write Data"),
                    new ApiScope(name: "delete", displayName: "Delete Data"),
                };

        public static IEnumerable<Client> Clients =>
            new List<Client>
                {
                    // machine to machine client (from quickstart 1)
                    new Client
                        {
                            ClientId = "client",

                            // no interactive user, use the clientid/secret for authentication
                            AllowedGrantTypes = GrantTypes.ClientCredentials,

                            // secret for authentication
                            ClientSecrets =
                            {
                                new Secret("secret".Sha256())
                            },

                            // scopes that client has access to
                            AllowedScopes = { "read", "write", "profile" }
                        },
                    // interactive ASP.NET Core Web App
                        new Client
                        {
                            ClientId = "geek_shopping",
                            ClientSecrets = { new Secret("my_super_secret".Sha256()) },

                            AllowedGrantTypes = GrantTypes.Code,
            
                            // where to redirect to after login
                            RedirectUris = { "https://localhost:4430/signin-oidc" },

                            // where to redirect to after logout
                            PostLogoutRedirectUris = { "https://localhost:4430/signout-callback-oidc" },

                            AllowedScopes = new List<string> 
                            {
                                IdentityServerConstants.StandardScopes.OpenId,
                                IdentityServerConstants.StandardScopes.Profile,
                                IdentityServerConstants.StandardScopes.Email,
                                "geek_shopping"
                            }
                        }
                };
    }
}