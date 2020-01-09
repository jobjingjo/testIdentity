# testIdentity




https://www.red-gate.com/simple-talk/dotnet/net-tools/working-with-identity-server-4/
http://docs.identityserver.io/en/latest/topics/apis.html

https://github.com/IdentityServer
https://www.scottbrady91.com/Identity-Server/Getting-Started-with-IdentityServer-4







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