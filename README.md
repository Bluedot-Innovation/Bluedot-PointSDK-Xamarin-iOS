# PointSDK.iOS xamarin wrapper
This repository contains a project to make a C# wrapper for PointSDK.iOS framework.

## Dependencies
1. [Cocoapods](https://cocoapods.org)
2. [Objective sharpie](https://docs.microsoft.com/en-us/xamarin/cross-platform/macios/binding/objective-sharpie/)
3. [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/)
4. Same Xcode version as was used for SDK build
5. [git LFS](https://git-lfs.github.com)

## Building
Below are basic steps to build a wrapper. Currently it uses `Xamarin.Swift4` NuGets. However, in the future it requires an update.

1. Update cocoapods by using the following command
    
        pod update

    It will checkout the latest SDK into `Pods/BluedotPointSDK/PointSDK`

2. Update C# binding

        sharpie bind -f ./Pods/BluedotPointSDK/PointSDK/BDPointSDK.framework -o ./Binding -p BDPointSDK

    This will update bindings in the `/Bindings` folder

3. `git diff` bindings with the previous version. If there are significant changes in the API, it will be visible in the diff and project classes will require updating. Otherwise, project classes remain the same.

4. Open solution and perform required changes to wrapper API.

5. Open project **Options -> NuGet Package -> Metadata** and update version.

6. Build the project with `release` configuration. It will produce `Bluedot.PointSDK.iOS.X.Y.Z.nupkg` in `/PointSDK.iOS/bin/Release/`.

## Validating
There is a Integration sample at `git@github.com:Bluedot-Innovation/PointSDK-Xamarin-minimal-app-iOS.git`. The clone is a primary source of any modifications.

1. Open `BDPointiOSXamarinDemo.sln`

2. Open **Visual Studio Preferences -> NuGet -> Sources** then add build folder from the **step 6** in **Building** stage

3. Right click on **project -> Add -> Ad NuGet Packages...** then choose NuGet repository from the previous step.

4. Select desired version of **Bluedot.PointSDK.iOS** and press **Add Package**

5. Update the **APIKey** in ViewController.cs and run the project.

## Releasing

1. Open solution in Visual Studio

2. Build the project with `release` configuration. It will produce `Bluedot.PointSDK.iOS.X.Y.Z.nupkg` in `/PointSDK.iOS/bin/Release/`.

3. Go to `https://www.nuget.org/packages/Bluedot.PointSDK.iOS` and login to Bluedot account.

4. Upload `Bluedot.PointSDK.iOS.X.Y.Z.nupkg` from `PointSDK.iOS/bin/Release`