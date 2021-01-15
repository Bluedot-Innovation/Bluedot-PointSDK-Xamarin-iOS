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
	// extern NSString * BDStringFromAuthenticationState (BDAuthenticationState state) __attribute__((deprecated("First deprecated in 15.4.0 - This will be removed in future version")));
	[DllImport ("__Internal")]
	[Verify (PlatformInvoke)]
	static extern NSString BDStringFromAuthenticationState (BDAuthenticationState state);
}

[Native]
public enum BDServiceError : nint
{
	SDKNotInitialized = -1000,
	InvalidProjectId = -1001,
	AccessDenied = -1002,
	StorageFull = -1003,
	FailedToConnect = -2000,
	FailedToRetrieveRemoteConfiguration = -2001,
	FailedToRetrieveGlobalConfig = -2002
}

[Native]
public enum BDTempoError : nint
{
	CannotStartWhileAlreadyInProgress = -1000,
	CannotStopWhileNotInProgress = -1001,
	InvalidDestinationId = -1002,
	InsufficientLocationPermission = -1003,
	CannotStartWhileApplicationInBackground = -1004
}

[Native]
public enum BDGeoTriggeringError : nint
{
	CannotStartWhileAlreadyInProgress = -1000,
	CannotStopWhileNotInProgress = -1001,
	InsufficientLocationPermission = -1002,
	CannotStartWhileApplicationInBackground = -1003,
	ZoneDownloadFailed = -1004
}

[Native]
public enum BDAuthorizationLevel : nint
{
	Always,
	WhenInUse
}
