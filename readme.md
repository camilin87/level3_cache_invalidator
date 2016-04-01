# Level3 Cache Invalidator  
Automatically invalidates Level3 Cache for the specified urls.

# Command Line Usage  
1. Compile the application  
2. Execute it in the following way  
```
clear_level3_cache.exe YOUR_API_KEY YOUR_API_SECRET subdomain1.mydomain.com,subdomain2.mydomain.com youremail@yourcompany.com
```

# [Octopus](https://octopus.com/) Usage  
1. Create a Run Script Step Template with the following variables [How?](http://docs.octopusdeploy.com/display/OD/Step+Templates)

- `level3_api_key`
- `level3_api_secret`
- `level3_notification_email`
- `level3_invalidation_urls`

2. In the script type select `C#`  
3. Paste all the code from [Level3Utils.cs](https://github.com/camilin87/level3_cache_invalidator/blob/master/clear_level3_cache/Level3Utils.cs)  
4. Paste the following code snippet  
```
var inputReader = new OctopusInput();
new CacheInvalidatorProgram(inputReader).Execute();
```
5. Save it. Use it in your other Octopus projects.  

# How does it work?  
The application sends two Http requests to the [Level3 REST Api](https://mediaportal.level3.com/webhelp/help/MediaPortalHelp_Left.htm#CSHID=API%2FAPI_KeysTop.htm|StartTopic=Content%2FAPI%2FAPI_KeysTop.htm|SkinName=NewSkin1).  

The first request is sent to `https://ws.level3.com/key/v1.0` to obtain an `AccessGroupId`. [Level 3 Key Documentation](https://mediaportal.level3.com/webhelp/help/Content/API/API_Specs/Key.htm)  
The second request is sent to `https://ws.level3.com/invalidations/v1.0/YOUR_ACCESS_GROUP_ID` to invalidate the cache for the specified properties. [Level 3 Invalidations Documentation](https://mediaportal.level3.com/webhelp/help/Content/API/API_Specs/Inval_POST.htm)  

## Understanding the code  
All of the code that actually does something is in the file [Level3Utils.cs](https://github.com/camilin87/level3_cache_invalidator/blob/master/clear_level3_cache/Level3Utils.cs). Putting all of those classes in the same file was a necessary evil to simplify the integration with Octopus.  

The entry point of the application is the class `CacheInvalidatorProgram`. It receives an `IInputReader` and an `ILogger` so that it can be reused in multiple environments.  

The class `CacheInvalidator` is the one responsible for creating and transmitting the Http requests.  
