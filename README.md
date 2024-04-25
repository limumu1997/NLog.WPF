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

### Version

#### 1.2.6
fix:
    1. Constructor display failed
    2. Parameters[0] is true => Not Show Log Message

#### 1.2.5
feat:
  1. fixed some known issues


#### 1.2.4
feat:
  1. add IsLightTheme Property
  2. add IsShowLogMessage Function

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

## publish packget

``` powershell
dotnet nuget push <packageName> --api-key <apikey> --source https://api.nuget.org/v3/index.json
```
