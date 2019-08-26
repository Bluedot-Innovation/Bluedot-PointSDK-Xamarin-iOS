using System;
using System.Runtime.InteropServices;
using BDPointSDK;
using Foundation;
using ObjCRuntime;

[Native]
public enum BDAuthenticationState : nint
{
	NotAuthenticated,
	Authenticating,
	Authenticated
}

static class CFunctions
{
	// extern NSString * BDStringFromAuthenticationState (BDAuthenticationState state);
	[DllImport ("__Internal")]
	[Verify (PlatformInvoke)]
	static extern NSString BDStringFromAuthenticationState (BDAuthenticationState state);
}

[Native]
public enum BDAuthorizationLevel : nint
{
	Always,
	WhenInUse
}
