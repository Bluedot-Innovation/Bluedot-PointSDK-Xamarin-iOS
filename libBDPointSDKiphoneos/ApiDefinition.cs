using System;
using CoreGraphics;
using CoreLocation;
using Foundation;
using MapKit;
using ObjCRuntime;
using UIKit;

namespace libBDPointSDKiphoneos
{

	[Static]
	partial interface Constants
	{
		// extern CLLocationAccuracy BDCoreLocation_MinimumAccuracy;
		[Field("BDCoreLocation_MinimumAccuracy", "__Internal")]
		double BDCoreLocation_MinimumAccuracy { get; }

		// extern CLLocationAccuracy BDCoreLocation_MaximumAccuracy;
		[Field("BDCoreLocation_MaximumAccuracy", "__Internal")]
		double BDCoreLocation_MaximumAccuracy { get; }
	}

	// @interface BDLocationManager : CLLocationManager
	[BaseType(typeof(CLLocationManager))]
	interface BDLocationManager
	{

		// +(BDLocationManager *)instance;
		[Static]
		[Export("instance")]
		BDLocationManager Instance();

		// @property (readonly, nonatomic) BOOL isBluetoothAvailable;
		[Export("isBluetoothAvailable")]
		bool IsBluetoothAvailable { get; }

		// @property (readonly, nonatomic) CLAuthorizationStatus authorizationStatus;
		[Export("authorizationStatus")]
		CLAuthorizationStatus AuthorizationStatus { get; }

		// -(void)authenticateWithApiKey:(NSString *)apiKey packageName:(NSString *)packageName username:(NSString *)username;
		[Export("authenticateWithApiKey:packageName:username:")]
		void AuthenticateWithApiKey(string apiKey, string packageName, string username);

		// -(void)authenticateWithApiKey:(NSString *)apiKey packageName:(NSString *)packageName username:(NSString *)username endpointURL:(NSURL *)endpointURL;
		[Export("authenticateWithApiKey:packageName:username:endpointURL:")]
		void AuthenticateWithApiKey(string apiKey, string packageName, string username, NSUrl endpointURL);

		// -(void)logOut;
		[Export("logOut")]
		void LogOut();

		// -(void)setPointDelegate:(id<BDPointDelegate>)pointDelegate;
		[Export("setPointDelegate:")]
		void SetPointDelegate(IBDPointDelegate pointDelegate);

		[Wrap("WeakLocationDelegate")]
		IBDPLocationDelegate LocationDelegate { get; set; }

		// @property id<BDPLocationDelegate> locationDelegate;
		[NullAllowed, Export("locationDelegate", ArgumentSemantic.Assign)]
		IBDPLocationDelegate WeakLocationDelegate { get; set; }

		[Wrap("WeakSessionDelegate")]
		IBDPSessionDelegate SessionDelegate { get; set; }

		// @property id<BDPSessionDelegate> sessionDelegate;
		[NullAllowed, Export("sessionDelegate", ArgumentSemantic.Assign)]
		IBDPSessionDelegate WeakSessionDelegate { get; set; }

		//[Wrap("WeakAuthenticationDelegate")]
		//IBDPAuthenticationDelegate AuthenticationDelegate { get; set; }

		// @property id<BDPAuthenticationDelegate> authenticationDelegate __attribute__((deprecated("This has been superceded by BDPSessionDelegate and will be removed in a future release.")));
		//[NullAllowed, Export("authenticationDelegate", ArgumentSemantic.Assign)]
		//NSObject WeakAuthenticationDelegate { get; set; }

		// @property (readonly) BDAuthenticationState authenticationState;
		[Export("authenticationState")]
		new BDAuthenticationState AuthenticationState { get; }

		// @property (readonly, nonatomic) NSSet * zoneInfos;
		[Export("zoneInfos")]
		NSSet ZoneInfos { get; }

		// -(void)setZone:(NSString *)zoneId disableByApplication:(BOOL)disable;
		[Export("setZone:disableByApplication:")]
		void SetZone(string zoneId, bool disable);

		// -(BOOL)isZoneDisabledByApplication:(NSString *)zoneId;
		[Export("isZoneDisabledByApplication:")]
		bool IsZoneDisabledByApplication(string zoneId);

		// -(NSString *)installRef;
		[Export("installRef")]
		string InstallRef();

		// -(void)notifyPushUpdateWithData:(NSDictionary *)data;
		[Export("notifyPushUpdateWithData:")]
		void NotifyPushUpdateWithData(NSDictionary data);

		// -(NSString *)sdkVersion;
		[Export("sdkVersion")]
		string SdkVersion();
	}

	// @protocol BDPSessionDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface BDPSessionDelegate
	{
		// @required -(void)willAuthenticateWithUsername:(NSString *)username apiKey:(NSString *)apiKey packageName:(NSString *)packageName;
		[Abstract]
		[Export("willAuthenticateWithUsername:apiKey:packageName:")]
		void WillAuthenticateWithUsername(string username, string apiKey, string packageName);

		// @required -(void)authenticationWasSuccessful;
		[Abstract]
		[Export("authenticationWasSuccessful")]
		void AuthenticationWasSuccessful();

		// @required -(void)authenticationWasDeniedWithReason:(NSString *)reason;
		[Abstract]
		[Export("authenticationWasDeniedWithReason:")]
		void AuthenticationWasDeniedWithReason(string reason);

		// @required -(void)authenticationFailedWithError:(NSError *)error;
		[Abstract]
		[Export("authenticationFailedWithError:")]
		void AuthenticationFailedWithError(NSError error);

		// @required -(void)didEndSession;
		[Abstract]
		[Export("didEndSession")]
		void DidEndSession();

		// @required -(void)didEndSessionWithError:(NSError *)error;
		[Abstract]
		[Export("didEndSessionWithError:")]
		void DidEndSessionWithError(NSError error);
	}

	interface IBDPLocationDelegate { }
	interface IBDPSessionDelegate { }
	interface IBDPointDelegate { }
	interface IBDPSpatialObjectInfo { }

	// @protocol BDPLocationDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface BDPLocationDelegate
	{
		// @optional -(void)didUpdateZoneInfo:(NSSet *)zoneInfos;
		[Export("didUpdateZoneInfo:")]
		void DidUpdateZoneInfo(NSSet zoneInfos);

		// @optional -(void)didCheckIntoFence:(BDFenceInfo *)fence inZone:(BDZoneInfo *)zoneInfo atCoordinate:(BDLocationCoordinate2D)coordinate onDate:(NSDate *)date willCheckOut:(BOOL)willCheckOut withCustomData:(NSDictionary *)customData;
		[Export("didCheckIntoFence:inZone:atCoordinate:onDate:willCheckOut:withCustomData:")]
		void DidCheckIntoFence(BDFenceInfo fence, BDZoneInfo zoneInfo, BDLocationCoordinate2D coordinate, NSDate date, bool willCheckOut, NSDictionary customData);

		// @optional -(void)didCheckIntoFence:(BDFenceInfo *)fence inZone:(BDZoneInfo *)zoneInfo atCoordinate:(BDLocationCoordinate2D)coordinate onDate:(NSDate *)date withCustomData:(NSDictionary *)customData __attribute__((deprecated("Use method didCheckIntoFence:inZone:atCoordinate:onDate:willCheckOut:withCustomData: instead")));
		[Export("didCheckIntoFence:inZone:atCoordinate:onDate:withCustomData:")]
		void DidCheckIntoFence(BDFenceInfo fence, BDZoneInfo zoneInfo, BDLocationCoordinate2D coordinate, NSDate date, NSDictionary customData);

		// @optional -(void)didCheckOutFromFence:(BDFenceInfo *)fence inZone:(BDZoneInfo *)zoneInfo onDate:(NSDate *)date withDuration:(NSUInteger)checkedInDuration withCustomData:(NSDictionary *)customData;
		[Export("didCheckOutFromFence:inZone:onDate:withDuration:withCustomData:")]
		void DidCheckOutFromFence(BDFenceInfo fence, BDZoneInfo zoneInfo, NSDate date, nuint checkedInDuration, NSDictionary customData);

		// @optional -(void)didCheckIntoBeacon:(BDBeaconInfo *)beacon inZone:(BDZoneInfo *)zoneInfo withProximity:(CLProximity)proximity onDate:(NSDate *)date willCheckOut:(BOOL)willCheckOut withCustomData:(NSDictionary *)customData;
		[Export("didCheckIntoBeacon:inZone:withProximity:onDate:willCheckOut:withCustomData:")]
		void DidCheckIntoBeacon(BDBeaconInfo beacon, BDZoneInfo zoneInfo, CLProximity proximity, NSDate date, bool willCheckOut, NSDictionary customData);

		// @optional -(void)didCheckIntoBeacon:(BDBeaconInfo *)beacon inZone:(BDZoneInfo *)zoneInfo withProximity:(CLProximity)proximity onDate:(NSDate *)date withCustomData:(NSDictionary *)customData __attribute__((deprecated("Use method didCheckIntoBeacon:inZone:withProximity:onDate:willCheckOut:withCustomData: instead")));
		[Export("didCheckIntoBeacon:inZone:withProximity:onDate:withCustomData:")]
		void DidCheckIntoBeacon(BDBeaconInfo beacon, BDZoneInfo zoneInfo, CLProximity proximity, NSDate date, NSDictionary customData);

		// @optional -(void)didCheckOutFromBeacon:(BDBeaconInfo *)beacon inZone:(BDZoneInfo *)zoneInfo withProximity:(CLProximity)proximity onDate:(NSDate *)date withDuration:(NSUInteger)checkedInDuration withCustomData:(NSDictionary *)customData;
		[Export("didCheckOutFromBeacon:inZone:withProximity:onDate:withDuration:withCustomData:")]
		void DidCheckOutFromBeacon(BDBeaconInfo beacon, BDZoneInfo zoneInfo, CLProximity proximity, NSDate date, nuint checkedInDuration, NSDictionary customData);

		// @optional -(void)didStartRequiringUserInterventionForBluetooth;
		[Export("didStartRequiringUserInterventionForBluetooth")]
		void DidStartRequiringUserInterventionForBluetooth();

		// @optional -(void)didStopRequiringUserInterventionForBluetooth;
		[Export("didStopRequiringUserInterventionForBluetooth")]
		void DidStopRequiringUserInterventionForBluetooth();

		// @optional -(void)didStartRequiringUserInterventionForLocationServicesAuthorizationStatus:(CLAuthorizationStatus)authorizationStatus;
		[Export("didStartRequiringUserInterventionForLocationServicesAuthorizationStatus:")]
		void DidStartRequiringUserInterventionForLocationServicesAuthorizationStatus(CLAuthorizationStatus authorizationStatus);

		// @optional -(void)didStopRequiringUserInterventionForLocationServicesAuthorizationStatus:(CLAuthorizationStatus)authorizationStatus;
		[Export("didStopRequiringUserInterventionForLocationServicesAuthorizationStatus:")]
		void DidStopRequiringUserInterventionForLocationServicesAuthorizationStatus(CLAuthorizationStatus authorizationStatus);

		// @optional -(void)didStartRequiringUserInterventionForPowerMode;
		[Export("didStartRequiringUserInterventionForPowerMode")]
		void DidStartRequiringUserInterventionForPowerMode();

		// @optional -(void)didStopRequiringUserInterventionForPowerMode;
		[Export("didStopRequiringUserInterventionForPowerMode")]
		void DidStopRequiringUserInterventionForPowerMode();
	}

	// @protocol BDPointDelegate <BDPSessionDelegate, BDPLocationDelegate>
	[Protocol, Model]
	interface BDPointDelegate : BDPSessionDelegate, BDPLocationDelegate
	{
	}

	// @protocol BDPAuthenticationStateProvider <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface BDPAuthenticationStateProvider
	{
		// @required @property (readonly) BDAuthenticationState authenticationState;
		[Abstract]
		[Export("authenticationState")]
		BDAuthenticationState AuthenticationState { get; }
	}

	// @interface BDPointSDK (MKMapView)
	[Category]
	[BaseType(typeof(MKMapView))]
	interface MKMapView_BDPointSDK
	{
		// -(void)bluedotAddOverlaysForBeacon:(BDBeaconInfo *)beaconInfo iconImage:(UIImage *)icon iconScale:(CGFloat)scale;
		[Export("bluedotAddOverlaysForBeacon:iconImage:iconScale:")]
		void BluedotAddOverlaysForBeacon(BDBeaconInfo beaconInfo, UIImage icon, nfloat scale);

		// -(void)bluedotAddOverlaysForFence:(BDFenceInfo *)fenceInfo;
		[Export("bluedotAddOverlaysForFence:")]
		void BluedotAddOverlaysForFence(BDFenceInfo fenceInfo);

		// -(void)bluedotAddOverlaysForZone:(BDZoneInfo *)zoneInfo withBeaconIconImage:(UIImage *)beaconIconImage beaconIconScale:(CGFloat)beaconIconScale;
		[Export("bluedotAddOverlaysForZone:withBeaconIconImage:beaconIconScale:")]
		void BluedotAddOverlaysForZone(BDZoneInfo zoneInfo, UIImage beaconIconImage, nfloat beaconIconScale);

		// -(void)bluedotAddOverlaysForZones:(NSSet *)zoneInfos withBeaconIconImage:(UIImage *)beaconIconImage beaconIconScale:(CGFloat)beaconIconScale;
		[Export("bluedotAddOverlaysForZones:withBeaconIconImage:beaconIconScale:")]
		void BluedotAddOverlaysForZones(NSSet zoneInfos, UIImage beaconIconImage, nfloat beaconIconScale);

		// -(void)bluedotRemoveAllSpatialObjectOverlays;
		[Export("bluedotRemoveAllSpatialObjectOverlays")]
		void BluedotRemoveAllSpatialObjectOverlays();

		// -(void)bluedotRemoveOverlaysForSpatialObjectInfo:(id<BDPSpatialObjectInfo>)spatialObject;
		[Export("bluedotRemoveOverlaysForSpatialObjectInfo:")]
		void BluedotRemoveOverlaysForSpatialObjectInfo(IBDPSpatialObjectInfo spatialObject);

		// -(void)bluedotSetTintColor:(UIColor *)tintColor forSpatialObject:(id<BDPSpatialObjectInfo>)spatialObjectInfo;
		[Export("bluedotSetTintColor:forSpatialObject:")]
		void BluedotSetTintColor(UIColor tintColor, IBDPSpatialObjectInfo spatialObjectInfo);

		// -(MKMapRect)bluedotMapRectForSpatialObject:(id<BDPSpatialObjectInfo>)spatialObjectInfo;
		[Export("bluedotMapRectForSpatialObject:")]
		MKMapRect BluedotMapRectForSpatialObject(IBDPSpatialObjectInfo spatialObjectInfo);

		// -(MKMapRect)bluedotMapRectForZone:(BDZoneInfo *)zone;
		[Export("bluedotMapRectForZone:")]
		MKMapRect BluedotMapRectForZone(BDZoneInfo zone);

		// -(MKMapRect)bluedotMapRectForZones:(NSSet *)zones;
		[Export("bluedotMapRectForZones:")]
		MKMapRect BluedotMapRectForZones(NSSet zones);
	}

	// @interface BDPointOverlayRendererFactory : NSObject
	[BaseType(typeof(NSObject))]
	interface BDPointOverlayRendererFactory
	{
		// +(instancetype)sharedInstance;
		[Static]
		[Export("sharedInstance")]
		BDPointOverlayRendererFactory SharedInstance();

		// -(MKOverlayRenderer *)rendererForOverlay:(id<MKOverlay>)pointOverlay;
		[Export("rendererForOverlay:")]
		MKOverlayRenderer RendererForOverlay(MKOverlay pointOverlay);

		// -(BOOL)isPointOverlay:(id<MKOverlay>)overlay;
		[Export("isPointOverlay:")]
		bool IsPointOverlay(MKOverlay overlay);
	}

	// @protocol BDPDeepCopy <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface BDPDeepCopy
	{
		// @required -(id)deepCopy;
		[Abstract]
		[Export("deepCopy")]
		NSObject DeepCopy();
	}

	// @protocol BDPGeometry <BDPDeepCopy>
	[Protocol, Model]
	interface BDPGeometry : BDPDeepCopy
	{
		// @required -(BOOL)intersects:(BDGeometry *)geometry;
		[Abstract]
		[Export("intersects:")]
		bool Intersects(BDGeometry geometry);

		// @required -(BOOL)isEnclosedBy:(BDGeometry *)geometry;
		[Abstract]
		[Export("isEnclosedBy:")]
		bool IsEnclosedBy(BDGeometry geometry);

		// @required -(BDBoundingBox *)boundingBox;
		[Abstract]
		[Export("boundingBox")]
		BDBoundingBox BoundingBox();

		// @required -(BDPoint *)centroid;
		[Abstract]
		[Export("centroid")]
		BDPoint Centroid();

		// @required -(BDLocationDistance)distanceTo:(BDGeometry *)geometry;
		[Abstract]
		[Export("distanceTo:")]
		double DistanceTo(BDGeometry geometry);
	}

	// @interface BDGeometry : NSObject <BDPGeometry>
	[BaseType(typeof(NSObject))]
	interface BDGeometry : BDPGeometry
	{
	}

	// @protocol BDPValidatable <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface BDPValidatable
	{
		// @required -(BOOL)valid;
		[Abstract]
		[Export("valid")]
		bool Valid();
	}

	// @interface BDBoundingBox : BDGeometry <NSCopying, BDPValidatable>
	[BaseType(typeof(BDGeometry))]
	interface BDBoundingBox : INSCopying, BDPValidatable
	{
		// -(instancetype)initWithNorth:(BDLocationDegrees)north west:(BDLocationDegrees)west south:(BDLocationDegrees)south east:(BDLocationDegrees)east;
		[Export("initWithNorth:west:south:east:")]
		IntPtr Constructor(double north, double west, double south, double east);

		// -(instancetype)initWithNorthEast:(BDPoint *)northEast southWest:(BDPoint *)southWest;
		[Export("initWithNorthEast:southWest:")]
		IntPtr Constructor(BDPoint northEast, BDPoint southWest);

		// -(void)setWest:(BDLocationDegrees)west;
		[Export("setWest:")]
		void SetWest(double west);

		// -(BDLocationDegrees)west;
		[Export("west")]
		double West();

		// -(void)setNorth:(BDLocationDegrees)north;
		[Export("setNorth:")]
		void SetNorth(double north);

		// -(BDLocationDegrees)north;
		[Export("north")]
		double North();

		// -(void)setEast:(BDLocationDegrees)east;
		[Export("setEast:")]
		void SetEast(double east);

		// -(BDLocationDegrees)east;
		[Export("east")]
		double East();

		// -(void)setSouth:(BDLocationDegrees)south;
		[Export("setSouth:")]
		void South(double south);

		// -(BDLocationDegrees)south;
		[Export("south")]
		double South();

		// -(BDLocationDegrees)longitudeSpan;
		[Export("longitudeSpan")]
		double LongitudeSpan();

		// -(BDLocationDegrees)latitudeSpan;
		[Export("latitudeSpan")]
		double LatitudeSpan();

		// @property (nonatomic) BDPoint * northEast;
		[Export("northEast", ArgumentSemantic.Assign)]
		BDPoint NorthEast { get; set; }

		// @property (nonatomic) BDPoint * southWest;
		[Export("southWest", ArgumentSemantic.Assign)]
		BDPoint SouthWest { get; set; }

		// -(NSArray *)vertices;
		[Export("vertices")]
		NSObject[] Vertices { get; }
	}

	// @interface BDCircle : BDGeometry
	[BaseType(typeof(BDGeometry))]
	interface BDCircle
	{
		// @property (nonatomic) BDPoint * center;
		[Export("center", ArgumentSemantic.Assign)]
		BDPoint Center { get; set; }

		// @property (nonatomic) BDLocationDistance radius;
		[Export("radius")]
		double Radius { get; set; }

		// -(instancetype)initWithCenter:(BDPoint *)center radius:(BDLocationDistance)radius;
		[Export("initWithCenter:radius:")]
		IntPtr Constructor(BDPoint center, double radius);

		// +(BDCircle *)circleWithCenter:(BDPoint *)center radius:(BDLocationDistance)radius;
		[Static]
		[Export("circleWithCenter:radius:")]
		BDCircle CircleWithCenter(BDPoint center, double radius);

		// -(BOOL)isEqual:(id)other;
		[Export("isEqual:")]
		bool IsEqual(NSObject other);

		// -(BOOL)isEqualToCircle:(BDCircle *)circle;
		[Export("isEqualToCircle:")]
		bool IsEqualToCircle(BDCircle circle);

		// -(NSUInteger)hash;
		[Export("hash")]
		nuint Hash();
	}

	// @interface BDPoint : BDGeometry <NSCopying>
	[BaseType(typeof(BDGeometry))]
	interface BDPoint : INSCopying
	{
		// +(instancetype)pointWithLongitude:(BDLocationDegrees)longitude latitude:(BDLocationDegrees)latitude;
		[Static]
		[Export("pointWithLongitude:latitude:")]
		BDPoint PointWithLongitude(double longitude, double latitude);

		// -(instancetype)initWithLongitude:(BDLocationDegrees)longitude latitude:(BDLocationDegrees)latitude;
		[Export("initWithLongitude:latitude:")]
		IntPtr Constructor(double longitude, double latitude);

		// -(instancetype)initWithCoordinate:(BDLocationCoordinate2D)coordinate;
		[Export("initWithCoordinate:")]
		IntPtr Constructor(BDLocationCoordinate2D coordinate);

		// -(NSString *)latitudeString;
		[Export("latitudeString")]
		string LatitudeString();

		// -(NSString *)longitudeString;
		[Export("longitudeString")]
		string LongitudeString();

		// @property (nonatomic) BDLocationDegrees longitude;
		[Export("longitude")]
		double Longitude { get; set; }

		// @property (nonatomic) BDLocationDegrees latitude;
		[Export("latitude")]
		double Latitude { get; set; }

		// @property (readonly, nonatomic) BDLocationCoordinate2D coordinate;
		[Export("coordinate")]
		BDLocationCoordinate2D Coordinate { get; }

		// -(CGPoint)cgPoint;
		[Export("cgPoint")]
		CGPoint CgPoint();

		// -(BOOL)isEqual:(id)other;
		[Export("isEqual:")]
		bool IsEqual(NSObject other);

		// -(BOOL)isEqualToPoint:(BDPoint *)point;
		[Export("isEqualToPoint:")]
		bool IsEqualToPoint(BDPoint point);

		// -(NSUInteger)hash;
		[Export("hash")]
		nuint Hash();

		// -(BOOL)isOrigin;
		[Export("isOrigin")]
		bool IsOrigin();
	}

	// @interface BDPolygonal : BDGeometry
	[BaseType(typeof(BDGeometry))]
	interface BDPolygonal
	{
		// -(NSUInteger)vertexCount;
		[Export("vertexCount")]
		nuint VertexCount();

		// -(void)addVertex:(BDPoint *)vertex;
		[Export("addVertex:")]
		void AddVertex(BDPoint vertex);

		// @property (nonatomic) NSMutableArray * vertices;
		[Export("vertices", ArgumentSemantic.Assign)]
		NSMutableArray Vertices { get; set; }

		// -(BOOL)isClosed;
		[Export("isClosed")]
		bool IsClosed();
	}

	// @interface BDLineString : BDPolygonal
	[BaseType(typeof(BDPolygonal))]
	interface BDLineString
	{
		// +(instancetype)lineStringWithVertices:(NSArray *)vertices copy:(BOOL)copy;
		[Static]
		[Export("lineStringWithVertices:copy:")]
		BDLineString LineStringWithVertices(NSObject[] vertices, bool copy);

		// +(instancetype)lineWithStart:(BDPoint *)start end:(BDPoint *)end;
		[Static]
		[Export("lineWithStart:end:")]
		BDLineString LineWithStart(BDPoint start, BDPoint end);

		// -(instancetype)initWithVertices:(NSArray *)vertices copy:(BOOL)copy;
		[Export("initWithVertices:copy:")]
		IntPtr Constructor(NSObject[] vertices, bool copy);

		// -(instancetype)initWithStart:(BDPoint *)start end:(BDPoint *)end;
		[Export("initWithStart:end:")]
		IntPtr Constructor(BDPoint start, BDPoint end);

		// @property (nonatomic) BDPoint * start;
		[Export("start", ArgumentSemantic.Assign)]
		BDPoint Start { get; set; }

		// @property (nonatomic) BDPoint * end;
		[Export("end", ArgumentSemantic.Assign)]
		BDPoint End { get; set; }
	}

	// @interface BDPolygon : BDPolygonal
	[BaseType(typeof(BDPolygonal))]
	interface BDPolygon
	{
		// +(instancetype)polygonWithVertices:(NSArray *)vertices copy:(BOOL)copy;
		[Static]
		[Export("polygonWithVertices:copy:")]
		BDPolygon PolygonWithVertices(NSObject[] vertices, bool copy);

		// +(instancetype)polygonWithLatLongCoordinates:(NSNumber *)scalar, ...;
		[Static, Internal]
		[Export("polygonWithLatLongCoordinates:", IsVariadic = true)]
		BDPolygon PolygonWithLatLongCoordinates(NSNumber scalar, IntPtr varArgs);
	}

	// @interface BDLocation : NSObject <BDPDeepCopy>
	[BaseType(typeof(NSObject))]
	interface BDLocation : BDPDeepCopy
	{
		// -(instancetype)initWithLatitude:(BDLocationDegrees)latitude longitude:(BDLocationDegrees)longitude altitude:(BDLocationDistance)altitude accuracy:(BDLocationAccuracy)accuracy altitudeAccuracy:(BDLocationAccuracy)altitudeAccuracy speed:(BDLocationSpeed)speed;
		[Export("initWithLatitude:longitude:altitude:accuracy:altitudeAccuracy:speed:")]
		IntPtr Constructor(double latitude, double longitude, double altitude, double accuracy, double altitudeAccuracy, double speed);

		// @property (nonatomic) BDLocationAccuracy accuracy;
		[Export("accuracy")]
		double Accuracy { get; set; }

		// @property (nonatomic) BDLocationAccuracy altitudeAccuracy;
		[Export("altitudeAccuracy")]
		double AltitudeAccuracy { get; set; }

		// @property (nonatomic) BDPoint * point;
		[Export("point", ArgumentSemantic.Assign)]
		BDPoint Point { get; set; }

		// @property (nonatomic) BDLocationDistance altitude;
		[Export("altitude")]
		double Altitude { get; set; }

		// @property (nonatomic) BDLocationSpeed speed;
		[Export("speed")]
		double Speed { get; set; }

		// @property (readonly, nonatomic) NSString * provider;
		[Export("provider")]
		string Provider { get; }

		// -(BOOL)isEqual:(id)other;
		[Export("isEqual:")]
		bool IsEqual(NSObject other);

		// -(BOOL)isEqualToLocation:(BDLocation *)location;
		[Export("isEqualToLocation:")]
		bool IsEqualToLocation(BDLocation location);

		// -(NSUInteger)hash;
		[Export("hash")]
		nuint Hash();
	}

	// @interface BDZoneInfo : NSObject
	[BaseType(typeof(NSObject))]
	interface BDZoneInfo
	{
		// @property (readonly, copy) NSString * name;
		[Export("name")]
		string Name { get; }

		// @property (readonly, copy) NSString * description;
		[Export("description")]
		string Description { get; }

		// @property (readonly, copy) NSString * ID;
		[Export("ID")]
		string ID { get; }

		// @property (readonly, copy) NSSet<BDFenceInfo *> * fences;
		[Export("fences", ArgumentSemantic.Copy)]
		NSSet Fences { get; }

		// @property (readonly, copy) NSSet<BDBeaconInfo *> * beacons;
		[Export("beacons", ArgumentSemantic.Copy)]
		NSSet Beacons { get; }

		// @property (readonly) BOOL checkOut;
		[Export("checkOut")]
		bool CheckOut { get; }

		// -(BOOL)isEqual:(id)other;
		[Export("isEqual:")]
		bool IsEqual(NSObject other);

		// -(BOOL)isEqualToInfo:(BDZoneInfo *)info;
		[Export("isEqualToInfo:")]
		bool IsEqualToInfo(BDZoneInfo info);

		// -(NSUInteger)hash;
		[Export("hash")]
		nuint Hash();
	}

	// @protocol BDPSpatialObject <NSObject>
	//[Protocol, Model]
	//[BaseType(typeof(NSObject))]
	//interface BDPSpatialObject
	//{
	// @required -(BDGeometry *)geometry;
	//  [Abstract]
	//  [Export("geometry")]
	//  BDGeometry Geometry();
	//}

	// @protocol BDPSpatialObjectInfo <BDPSpatialObject>
	[Protocol, Model]
	interface BDPSpatialObjectInfo
	{
		// @required @property (readonly, copy) NSString * name;
		[Abstract]
		[Export("name")]
		string Name { get; }

		// @required @property (readonly, copy) NSString * description;
		[Abstract]
		[Export("description")]
		string Description { get; }

		// @required @property (readonly, copy) NSString * ID;
		[Abstract]
		[Export("ID")]
		string ID { get; }

		// @required @property (readonly) BDGeometry * geometry;
		[Abstract]
		[Export("geometry")]
		BDGeometry Geometry { get; }
	}

	// @interface BDFenceInfo : NSObject <BDPSpatialObjectInfo>
	[BaseType(typeof(NSObject))]
	interface BDFenceInfo : BDPSpatialObjectInfo
	{
		// @property (readonly, copy) NSString * name;
		[Export("name")]
		new string Name { get; }

		// @property (readonly, copy) NSString * description;
		[Export("description")]
		new string Description { get; }

		// @property (readonly, copy) NSString * ID;
		[Export("ID")]
		new string ID { get; }

		// @property (readonly) BDGeometry * geometry;
		[Export("geometry")]
		new BDGeometry Geometry { get; }
	}

	// @interface BDBeaconInfo : NSObject <BDPSpatialObjectInfo>
	[BaseType(typeof(NSObject))]
	interface BDBeaconInfo : BDPSpatialObjectInfo
	{
		// @property (readonly, copy) NSString * name;
		[Export("name")]
		new string Name { get; }

		// @property (readonly, copy) NSString * description;
		[Export("description")]
		new string Description { get; }

		// @property (readonly, copy) NSString * ID;
		[Export("ID")]
		new string ID { get; }

		// @property (readonly, copy) NSString * proximityUuid;
		[Export("proximityUuid")]
		string ProximityUuid { get; }

		// @property (readonly) NSUInteger major;
		[Export("major")]
		nuint Major { get; }

		// @property (readonly) NSUInteger minor;
		[Export("minor")]
		nuint Minor { get; }

		// @property (readonly) CLLocationCoordinate2D location;
		[Export("location")]
		CLLocationCoordinate2D Location { get; }

		// @property (readonly) BDGeometry * geometry;
		[Export("geometry")]
		new BDGeometry Geometry { get; }
	}

	// @interface BDPointSessionException : NSException
	[BaseType(typeof(NSException))]
	interface BDPointSessionException
	{
		// +(NSException *)exceptionWithReason:(NSString *)reason;
		[Static]
		[Export("exceptionWithReason:")]
		NSException ExceptionWithReason(string reason);
	}

	// @protocol BDPRestartAlertDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface BDPRestartAlertDelegate
	{
		// @required -(NSString *)restartAlertTitle;
		[Abstract]
		[Export("restartAlertTitle")]
		string RestartAlertTitle();

		// @optional -(NSString *)restartButtonText;
		[Export("restartButtonText")]
		string RestartButtonText();
	}

	// @protocol BDPNamedDescribed
	[Protocol, Model]
	interface BDPNamedDescribed
	{
		// @required @property (copy) NSString * name;
		[Abstract]
		[Export("name")]
		string Name { get; set; }

		// @required @property (readwrite, copy) NSString * description;
		[Abstract]
		[Export("description")]
		string Description { get; set; }
	}

	// @interface BDURLEncoding (NSString)
	[Category]
	[BaseType(typeof(NSString))]
	interface NSString_BDURLEncoding
	{
		// -(NSString *)bluedotURLEncodeUsingEncoding:(NSStringEncoding)encoding;
		[Export("bluedotURLEncodeUsingEncoding:")]
		string BluedotURLEncodeUsingEncoding(nuint encoding);

		// -(NSString *)bluedotURLDecode;
		[Export("bluedotURLDecode")]
		string BluedotURLDecode();
	}

	//[Static]
	//partial interface Constants
	//{
	//  // extern double BDPointSDKVersionNumber;
	//  [Field("BDPointSDKVersionNumber", "__Internal")]
	//  double BDPointSDKVersionNumber { get; }
	//
	//  // extern const unsigned char [] BDPointSDKVersionString;
	//  [Field("BDPointSDKVersionString", "__Internal")]
	//  IntPtr BDPointSDKVersionString { get; }
	//}

}
