# DesktopInfo: User's Guide



## Downloads & Runtimes

Download the latest release from the [Releases page](https://github.com/RemusRigo/DesktopInfo-VB.NET/releases).

|Build|Architecture|Required Runtime|
|-|-|-|
|`win-x64`|64-bit|none (self-contained single file)|
|`win-x86`|32-bit|none (self-contained single file)|

> On 64-bit Windows 10/11, use **x64**. The release is a single `DesktopInfo.exe` that already contains .NET 10,
> so there is nothing else to install.



## Install

DesktopInfo is portable: there is no installer.

1. Copy `DesktopInfo.exe` to a permanent folder where you have write access, for example `D:\My Apps\DesktopInfo\`.
2. Double-click `DesktopInfo.exe`. A tray icon appears and the information is shown in the top-left corner of the desktop.
3. Optional: open **Options** and check **Current user** or **All Users** to start DesktopInfo with Windows.

> If Windows blocks the file ("Windows protected your PC"), right-click `DesktopInfo.exe` →
> **Properties** → check **Unblock** → **OK**, then try again.



## What it shows

|Line|Description|
|-|-|
|*user* on *computer*|Your user name and the computer name|
|**OS**|Windows edition, e.g. *Microsoft Windows 11 Pro*|
|**Version**, **Build Number**|Windows version and build|
|**Feature Update**, **Codename**|e.g. *24H2*, from the build number|
|**Private IP**|Your local IP address|
|**Public IP**|Your internet IP address, from [ipify.org](https://www.ipify.org) (needs an internet connection)|



## Tray icon

Click the tray icon (left, right or middle button) to open the menu:

|Menu|Description|
|-|-|
|**About**|Version information|
|**Options**|Settings (see below)|
|**Exit**|Close DesktopInfo|



## Options

|Setting|Description|
|-|-|
|**Position**|Top Left (default), Top Right, Bottom Left, Bottom Right of the primary monitor; the window moves as soon as you click|
|**Install: Current user**|Start DesktopInfo when you sign in to Windows|
|**Install: All Users**|Start DesktopInfo for every user of this PC (enabled only when DesktopInfo runs as administrator)|

The **Install** check boxes apply immediately. Click **Ok** to save the position.

|Setting|Stored in|
|-|-|
|Position|`DesktopInfo.json` next to `DesktopInfo.exe`|
|Start with Windows|`HKEY_CURRENT_USER` or `HKEY_LOCAL_MACHINE` `\Software\Microsoft\Windows\CurrentVersion\Run`, value `Remus Rigo DesktopInfo`|



## Uninstall

1. Open **Options** and uncheck **Current user** and **All Users** (run as administrator to uncheck **All Users**).
2. Click the tray icon → **Exit**.
3. Delete the folder you copied `DesktopInfo.exe` to.
