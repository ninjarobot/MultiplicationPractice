Multiplication Practice
=========

Generates multiplication practice problems.

### Usage
Run at a command line, optionally passing a single parameter for the maximum factor to use in generating problems.

Press Ctrl+C on Linux or Windows or Cmd+C on macOS to exit.

### Build
Requires the dotnet 5 SDK.

Build a self-contained executable, for example for Linux on x64:
```
 dotnet publish -p:PublishSingleFile=true -p:PublishTrimmed=true -c Release --self-contained -r linux-x64
```
