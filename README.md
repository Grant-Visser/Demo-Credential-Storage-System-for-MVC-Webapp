# Demo Credential Storage System for MVC Webapp

This asp.net webapp uses a custom config file to add keys and values to the appsettings field in the Web.config of the app. The idea is that you exclude this other file from your source control system, in order to keep it secret. 

## Private.config
```xml
<?xml version="1.0"?>
<!--
  Remember to exclude this file from your source control. Otherwise you defeat the purpose of all of this.  
  -->
 <appSettings>
   <add key="App1Password" value="2JxnpWUK55kFCJ9AfMnJ" />
   <add key="App2Password" value="This is another password" />
   <add key="Test Password" value="TestPassword" />
 </appSettings>
```

Private.config is used to store all passowords/sensitive information in a Key:value pair. 

## Web.config changes
```xml
<appSettings file="Private.config">
    <add key="webpages:Version" value="3.0.0.0" />
...
</appSettings>
```
Subtle changes mean that Web.Config merges with Private.Config at runtime, expanding the usable appSettings key:value pairs into the ones separated and hidden.

## PasswordManagement Class
### Construction
```csharp
PasswordManagement passwordManagementInstance = PasswordManagement.getInstance();
```
Due to the use of the threadsafe singleton pattern, a classical constructor cannot be called.
### Getting Values
```csharp
string val = passwordManagementInstance.getValue("Key");
```
Returns a string value related to the key or an appropriate error message if the key could not be found. 