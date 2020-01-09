# testIdentity




https://www.red-gate.com/simple-talk/dotnet/net-tools/working-with-identity-server-4/
http://docs.identityserver.io/en/latest/topics/apis.html

https://github.com/IdentityServer
https://www.scottbrady91.com/Identity-Server/Getting-Started-with-IdentityServer-4




dotnet watch run


https://localhost:5001/token 
POST

grant_type=client_credentials
scope=all
client_id=client_credential_flow
client_secret=client_credential_flow_secret

https://localhost:5001/token 
POST
username=username
password=password
grant_type=password
scope=openid+offline_access
client_id=resource_owner_flow
client_secret=resource_owner_flow_secret

Refresh Token
To get a refresh token, it needs the refresh token that comes with the resource owner token response. Do this to get a new access token:
https://localhost:5001/token 
POST
grant_type=refresh_token
client_id=resource_owner_flow
client_secret=resource_owner_flow_secret
refresh_token=GVP13…Xsy1Vu4M

https://localhost:5001/.well-known/openid-configuration
GET