using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Microsoft.Xna.Framework;
using Android.Content.PM;

namespace FontBuddySample.Android
{
	[Activity (Label = "FontBuddySample.Android", 
	           MainLauncher = true,
	           LaunchMode=LaunchMode.SingleInstance,
	           ConfigurationChanges = ConfigChanges.Orientation | 
	                                  ConfigChanges.KeyboardHidden | 
	                                  ConfigChanges.Keyboard,
	           ScreenOrientation=ScreenOrientation.Landscape)]
	public class Activity1 : AndroidGameActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			// Create our OpenGL view, and display it
			Game1.Activity = this;
			var g = new Game1();
			SetContentView(g.Window);
			g.Run();
		}
	}
}


