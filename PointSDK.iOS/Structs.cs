﻿using System;
using System.Runtime.InteropServices;
using PointSDK;
using Foundation;
using ObjCRuntime;

namespace PointSDK.iOS
{
	[Native]
	public enum BDAuthenticationState : long
	{
		NotAuthenticated,
		Authenticating,
		Authenticated
	}

	[Native]
	public enum BDServiceError : long
	{
		SDKNotInitialized = -1000,
		InvalidProjectId = -1001,
		AccessDenied = -1002,
		StorageFull = -1003,
		NotificationPermissionNotGranted = -1004,
		SDKAlreadyInitialized = -1005,
		FailedToConnect = -2000,
		FailedToRetrieveRemoteConfiguration = -2001,
		FailedToRetrieveGlobalConfig = -2002
	}

	[Native]
	public enum BDTempoError : long
	{
		CannotStartWhileAlreadyInProgress = -1000,
		CannotStopWhileNotInProgress = -1001,
		InvalidDestinationId = -1002,
		InsufficientLocationPermission = -1003,
		CannotStartWhileApplicationInBackground = -1004
	}

	[Native]
	public enum BDGeoTriggeringError : long
	{
		ErrorCannotStartWhileAlreadyInProgress = -1000,
		ErrorCannotStopWhileNotInProgress = -1001,
		ErrorInsufficientLocationPermission = -1002,
		ErrorCannotStartWhileApplicationInBackground = -1003,
		ErrorZoneDownloadFailed = -1004,
		InsufficientNotificationPermission = -1005
	}

	[Native]
	public enum BDAuthorizationLevel : long
	{
		Always,
		WhenInUse
	}

	static class CFunctions
	{
		// extern NSString * BDStringFromAuthenticationState (BDAuthenticationState state) __attribute__((deprecated("First deprecated in 15.4.0 - This will be removed in future version")));
		[Obsolete("First deprecated in 15.4.0 - This will be removed in future version")]
		[DllImport("__Internal")]
		static extern NSString BDStringFromAuthenticationState(BDAuthenticationState state);

		// extern BDLocationCoordinate2D BDLocationCoordinate2DMake (BDLocationDegrees latitude, BDLocationDegrees longitude);
		[DllImport("__Internal")]
		static extern BDLocationCoordinate2D BDLocationCoordinate2DMake(double latitude, double longitude);
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct BDLocationCoordinate2D
	{
		public double latitude;

		public double longitude;
	}
}