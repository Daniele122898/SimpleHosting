# Simple Hosting
This is a tiny c# utility to serve static files. Just create a wwwroot folder wherever you launch the app from and it'll serve whatever is in it. 

You can change port like this:
```
dotnet SimpleHosting.dll --urls http://0.0.0.0:80
```

Support single page applications (SPA) such as react / Angular by setting the IsSpa to true in the appsettings.json Serving config. 
