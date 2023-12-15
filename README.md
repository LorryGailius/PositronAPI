# PoistronAPI
An ASP.NET Web API for a POS System made in PS Software Design Course

# Prerequisites
There is an appsettings.json file missing inside the project. In order to run the project create a new appsettings.json file with the following information.
Fill in the ```[Field]``` with your personal information

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=[Your Host];Port=[Your Ports];Username=[Your Username];Password=[Your Password];Database=[Your Database]"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```
