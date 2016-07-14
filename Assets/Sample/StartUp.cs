using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class StartUp : MonoBehaviour {
	public GameObject text;

	// Use this for initialization
	void Start () {

		Screen.orientation = ScreenOrientation.Portrait;

		#if UNITY_IOS 

		AppsFlyer.setAppsFlyerKey ("YOUR_DEV_KEY");
		AppsFlyer.setAppID ("YOUR_APP_ID");
		AppsFlyer.setIsDebug (true);
		AppsFlyer.getConversionData ();
		AppsFlyer.trackAppLaunch ();

		#elif UNITY_ANDROID

		// if you are working without the manifest, you can initialize the SDK programatically.
		AppsFlyer.init ("YOUR_DEV_KEY");
		AppsFlyer.setIsDebug(true);

		// un-comment this in case you are not working with the android manifest file
		AppsFlyer.setAppID ("YOUR_PACKAGE_NAME"); 

		// for getting the conversion data
		AppsFlyer.loadConversionData("StartUp","didReceiveConversionData", "didReceiveConversionDataWithError");

		// for in app billing validation
//		AppsFlyer.createValidateInAppListener ("AppsFlyerTrackerCallbacks", "onInAppBillingSuccess", "onInAppBillingFailure"); 

		#endif

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) 
			Application.Quit(); 
	}
	//A custom event tracking
	public void Purchase(){
		Dictionary<string, string> eventValue = new Dictionary<string,string> ();
		eventValue.Add("af_revenue","200");
		eventValue.Add("af_content_type","category_a");
		eventValue.Add("af_content_id","1234567");
		eventValue.Add("af_currency","USD");
		AppsFlyer.trackRichEvent("af_purchase", eventValue);
		AF_Sample_BGScript.pressed ();
	}

	public void didReceiveConversionData(string conversionData) {
		print ("AppsFlyerTrackerCallbacks:: got conversion data = " + conversionData);
		if (conversionData.Contains ("Non")) {
			text.GetComponent<Text> ().text = "Non-Organic Install";
		} else {
			text.GetComponent<Text> ().text = "Organic Install";
		}	
	}
}
