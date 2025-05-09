
# PetShop Manager

The ASP.NET Core example application for Back End I classes.

## Keycloak Configuration

Run Keycloak using Docker executing the command below.

```bash
docker run -p 8080:8080 -e KC_BOOTSTRAP_ADMIN_USERNAME=admin -e KC_BOOTSTRAP_ADMIN_PASSWORD=admin quay.io/keycloak/keycloak:26.1.4 start-dev
```

When the Keycloak setup finishes access <http://localhost:8080/admin> using admin/admin as the development credentials.

Create a new realm on the top left select and name it `petshop-manager`.

Using the `petshop-manager` realm, create a new client and name it `petshop-manager-client` (client id). Enable the `Client Authentication` option on step 2. Add the redirect URI `https://localhost:7227/api/v1/authentication/login/oidc/redirect` on step 3.

After saving the new Client, still on the `petshop-manager-client` page:

- Go to 'Credentials' tab and grab client secret to update the `appsettings.Development.json` ($.Authentication.Keycloak.ClientSecret) from the project.

- Create two roles on 'Roles' tab: `Admin` and `Public` (roles evaluation is case sensitive).

Go to Client Scopes > Select 'roles' > go to Mappers tab > select 'client roles' > then on Mapper details enable the 'Add to ID token' option, and change the 'Token Claim Name' to 'resource_access', then save.

Now go to `Users` and create a user, just give it a `Username` and add a password to it on tab `Credentials` after saving it.

Still on the user page, go to `Role Mapping` tab and assign the `petshop-manager-client` roles to it: `Public` and `Admin`.

You should now be able to request <https://localhost:7227/api/v1/authentication/login/oidc> in your browser and get the authentication through Keycloak (make sure the ASP.NET Core Web API project is running).

Use the `id_token` returned as the Bearer Token payload.
