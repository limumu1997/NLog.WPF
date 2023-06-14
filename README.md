[1]: https://github.com/NLog/NLog.Windows.Forms
[2]: http://dotnetsolutionsbytomi.blogspot.se/2011/06/creating-awesome-logging-control-with.html

# NLog.WPF

This package is an extension to [NLog](https://github.com/NLog/NLog/).

NLog.WPF is a simple WPF-control to show NLog-logs. It's heavily inspired by [NLog.Windows.Forms][1] and [this blog][2].



## How to use?

Add a namespace to your Window, like this:

        xmlns:nlog ="clr-namespace:NLog.WPF;assembly=NLog.WPF"

then add the control

         <nlog:NlogListView x:Name="logCtrl" TimeWidth="auto" LoggerNameWidth="0" LevelWidth="auto" ExceptionWidth="auto" MessageWidth="auto" />

or

        <nlog:NlogRichTextBox x:Name="logCtrlNlogRichTextBox1"/>
        
clear NlogRichTextBox

        <Button Content="ClearLog" CommandTarget="{Binding ElementName=logCtrlNlogRichTextBox1}"  Command="{x:Static nlog:NlogRichTextBox.ClearCommand}" />


To setup NlogViewer as a target, add the following to your Nlog.config.

```xml
  <extensions>
    <add assembly="NLog.WPF" />
  </extensions>
  <targets>
    <target xsi:type="NLog.WPF" name="ctrl" />
  </targets>
  <rules>
    <logger name="*" minlevel="Trace" writeTo="ctrl" />
  </rules>
```

## public packget

``` powershell
dotnet pack --configuration Release
dotnet nuget push "bin/Release/NLog.WPF.1.2.0.nupkg"  --api-key YOUR_GITHUB_PAT  --source "https://nuget.pkg.github.com/limumu1997/index.json"
```
