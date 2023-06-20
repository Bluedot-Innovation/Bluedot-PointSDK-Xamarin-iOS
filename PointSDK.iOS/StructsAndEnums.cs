using System;
using System.Runtime.InteropServices;
using PointSDK;
using Foundation;
using ObjCRuntime;

namespace PointSDK.iOS
{
    [Native]
    public enum BDServiceError : long
    {
        SDKNotInitialized = -1000,
        InvalidProjectId = -1001,
        AccessDenied = -1002,
        StorageFull = -1003,
        NotificationPermissionNotGranted = -1004,
        SDKAlreadyInitialized = -1005,
        MissingLocation = -1006,
        FailedToConnect = -2000,
        FailedToRetrieveRemoteConfiguration = -2001,
        FailedToRetrieveGlobalConfig = -2002,
        FailedToRetrieveRuleSet = -2003
    }

    [Native]
    public enum BDTempoError : long
    {
        CannotStartWhileAlreadyInProgress = -1000,
        CannotStopWhileNotInProgress = -1001,
        InvalidDestinationId = -1002,
        InsufficientLocationPermission = -1003,
        CannotStartWhileApplicationInBackground = -1004,
        SDKHasBeenReset = -1005,
        UnexpectedError = -1006,
        TempoNotEnabled = -1007
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
    public enum EventType : long
    {
        FenceEntered = 0,
        FenceExited = 1,
        TempoUpdate = 2,
        TempoStop = 3,
        SdkInit = 4,
        SdkReset = 5,
        GeoTriggerStart = 6,
        GeoTriggerStop = 7
    }

    [Native]
    public enum NotificationType : long
    {
        Entry = 0,
        Exit = 1,
        Tempo = 2,
        Lifecycle = 3,
        Unknown = 4
    }

    [Native]
    public enum TempoStopReason : long
    {
        InvalidDestinationId = 0,
        StoppedByCustomerApp = 1,
        SdkLogout = 2,
        Expired = 3,
        TempoNotEnabled = 4
    }

    [Native]
    public enum TempoUpdateETADirection : long
    {
        LessThan = 0,
        GreaterThan = 1,
        Unknown = -1
    }

    [Native]
    public enum TriggerEngine : long
    {
        Bd = 0,
        Native = 1
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct BDLocationCoordinate2D
    {
        public double latitude;

        public double longitude;
    }

}