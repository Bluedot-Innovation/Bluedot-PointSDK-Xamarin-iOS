using System;
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

    static class CFunctions
    {
        // extern NSString * BDStringFromAuthenticationState (BDAuthenticationState state);
        [DllImport ("__Internal")]
        static extern NSString BDStringFromAuthenticationState (BDAuthenticationState state);

        // extern BDLocationCoordinate2D BDLocationCoordinate2DMake (BDLocationDegrees latitude, BDLocationDegrees longitude);
        [DllImport ("__Internal")]
        static extern BDLocationCoordinate2D BDLocationCoordinate2DMake (double latitude, double longitude);
    }

    [StructLayout (LayoutKind.Sequential)]
    public struct BDLocationCoordinate2D
    {
        public double latitude;

        public double longitude;
    }
}
