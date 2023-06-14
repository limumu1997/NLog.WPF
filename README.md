# NLog.WPF
==========
NLog.WPF is a simple WPF-control to show NLog-logs. It's heavily inspired by [this blog][1].

``` shell
dotnet pack --configuration Release
dotnet nuget push "bin/Release/NLog.WPF.1.2.0.nupkg"  --api-key YOUR_GITHUB_PAT  --source "https://nuget.pkg.github.com/limumu1997/index.json"
```

## How to use?

Add a namespace to your Window, like this:

        xmlns:nlog ="clr-namespace:NlogViewer;assembly=NlogViewer"

then add the control.

        <nlog:NlogViewer x:Name="logCtrl" /> 

To setup NlogViewer as a target, add the following to your Nlog.config.

```xml
  <extensions>
    <add assembly="NlogViewer" />
  </extensions>
  <targets>
    <target xsi:type="NlogViewer" name="ctrl" />
  </targets>
  <rules>
    <logger name="*" minlevel="Trace" writeTo="ctrl" />
  </rules>
```
