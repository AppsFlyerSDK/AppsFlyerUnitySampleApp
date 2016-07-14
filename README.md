
<h2>AppsFlyer Unity Sample App</h2>

Instructions for AppsFlyer's Unity Sample App project:

Open the Sample App Project using Unity.

Inside "Sample" folder, open "StartUp.cs".

In "StartUp.cs", enter your AppsFlyer Dev Key inside the "init"/"setAppsFlyerKey" function, and your Package Name / AppID inside "setAppID" function" -


<pre><code>void Start () {
		

    #if UNITY_IOS 

    AppsFlyer.setAppsFlyerKey ("YOUR_DEV_KEY");
    AppsFlyer.setAppID ("YOUR_APP_ID");

    ...

    #elif UNITY_ANDROID

    AppsFlyer.init ("YOUR_DEV_KEY");
    AppsFlyer.setAppID ("YOUR_PACKAGE_NAME"); 
		
    ...

	</code></pre>

<h3>Note: If you are building for Android, you should change the project's package name in Player Setting.</h3>

Go to your AppsFlyer dashboard and add the app using the Package Name / App ID you configured in the code.

Create a custom tracking link from your AppsFlyer dashboard - 
<a href="https://support.appsflyer.com/hc/en-us/articles/207033836-Custom-Media-Source-Configuration-e-g-E-mail-or-User-Invites-">More Information</a>
	
Click the link on your device (Make sure to add <b>&advertising_id="Your_Device_Google_Advertising_Id"</b> for Android or <b>&IDFA="Your_Device_IDFA"</b> for iOS at the end of your tracking link). <a href="https://support.appsflyer.com/hc/en-us/articles/207031996--Whitelisting-a-Test-Device">More Information</a>


Install the App on your device. You should be seeing the Attribution result on the screen.

If you received the "Install Type: Non Organic" message on the app, you can go to your AppsFlyer dashboard and see the non-organic install there.
    
For a Non-Organic install - click the "Track Event" to track a custom purchase event. You can then see the revenue and event on your AppsFlyer dashboard.


[iOS Integration Guide](http://support.appsflyer.com/entries/25458906-iOS-SDK-Integration-Guide-v2-5-3-x-New-API-).

[Android Integration Guide](http://support.appsflyer.com/entries/22801952-Android-SDK-Integration-Guide).
