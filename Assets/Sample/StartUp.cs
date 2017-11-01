using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class StartUp : MonoBehaviour {
	public GameObject text;
	private bool tokenSent;

	// Use this for initialization
	void Start () {
		Application.runInBackground = true;
		Screen.orientation = ScreenOrientation.Portrait;
		DontDestroyOnLoad (this);
		AppsFlyer.setIsDebug(true);

		#if UNITY_IOS 

		AppsFlyer.setAppsFlyerKey ("YOUR_DEV_KEY");
		AppsFlyer.setAppID ("YOUR_APP_ID");
		AppsFlyer.setIsDebug (true);
		AppsFlyer.getConversionData ();
		AppsFlyer.trackAppLaunch ();

		// register to push notifications for iOS uninstall
		UnityEngine.iOS.NotificationServices.RegisterForNotifications (UnityEngine.iOS.NotificationType.Alert | UnityEngine.iOS.NotificationType.Badge | UnityEngine.iOS.NotificationType.Sound);
		Screen.orientation = ScreenOrientation.Portrait;

		#elif UNITY_ANDROID

		AppsFlyer.init ("WdpTVAcYwmxsaQ4WeTspmh");

		//AppsFlyer.setAppID ("YOUR_APP_ID"); 

		// for getting the conversion data
		AppsFlyer.loadConversionData("StartUp");

		// for in app billing validation
//		 AppsFlyer.createValidateInAppListener ("AppsFlyerTrackerCallbacks", "onInAppBillingSuccess", "onInAppBillingFailure"); 

		//For Android Uninstall
		//AppsFlyer.setGCMProjectNumber ("YOUR_GCM_PROJECT_NUMBER");


		#endif
	}


	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			//go to background when pressing back button
			#if UNITY_ANDROID
			AndroidJavaObject activity = 
				new AndroidJavaClass("com.unity3d.player.UnityPlayer")
					.GetStatic<AndroidJavaObject>("currentActivity");
			activity.Call<bool>("moveTaskToBack", true);
			#endif
		}
			

		#if UNITY_IOS 
		if (!tokenSent) { 
			byte[] token = UnityEngine.iOS.NotificationServices.deviceToken;           
			if (token != null) {     
			//For iOS uninstall
				AppsFlyer.registerUninstall (token);
				tokenSent = true;
			}
		}    
		#endif
	}
	//A custom event tracking
	public void Purchase(){
		Dictionary<string, string> eventValue = new Dictionary<string,string> ();
		eventValue.Add("af_revenue","300");
		eventValue.Add("af_content_type","category_a");
		eventValue.Add("af_content_id","1234567");
		eventValue.Add("af_currency","USD");
		AppsFlyer.trackRichEvent("af_purchase", eventValue);

		AF_Sample_BGScript.pressed ();

	}

	//On Android ou can call the conversion data directly from your CS file, or from the default AppsFlyerTrackerCallbacks
	public void didReceiveConversionData(string conversionData) {
		print ("AppsFlyerTrackerCallbacks:: got conversion data = " + conversionData);
		if (conversionData.Contains ("Non")) {
			text.GetComponent<Text> ().text = "Non-Organic Install";
		} else {
			text.GetComponent<Text> ().text = "Organic Install";
		}	
	}
	public void didReceiveConversionDataWithError(string error) {
		print ("AppsFlyerTrackerCallbacks:: got conversion data error = " + error);
	}

	public void onAppOpenAttribution(string validateResult) {
		print ("AppsFlyerTrackerCallbacks:: got onAppOpenAttribution  = " + validateResult);

	}

	public void onAppOpenAttributionFailure (string error) {
		print ("AppsFlyerTrackerCallbacks:: got onAppOpenAttributionFailure error = " + error);

	}

}
