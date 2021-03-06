# usbeject

.NET class library to safely eject removable storage.


## Details

Code taken from a [CodeProject article](https://www.codeproject.com/Articles/13530/Eject-USB-disks-using-C)
with the following modifications/additions:

* Fixed a bug where it wasn't ejecting the drive it claimed to be ejecting (@mthiffau)
* Added AnyCPU support (@iscgar)
* Built for .NET 2.0, 3.5 and 4.0 in addition to .NET 4.5
* Simplified usage
* Fixed API collection types (`IReadOnlyCollection<T>` in .NET 4.5, `IEnumerable<T>` in older targets)
* Added [Chimp.Logging.Core](https://github.com/CHDKUtil/Chimp.Logging.Core) abstraction
* Implemented thread-safe properties
* Implemented Disposable pattern
* Fixed minor bugs


## Installation

```powershell
Install-Package UsbEject -Pre
```


## Usage

```csharp
using (VolumeDeviceClass volumes = new VolumeDeviceClass())
{
  Volume volume = volumes.SingleOrDefault(v => ejectDrive.Equals(v.LogicalDrive));
  volume?.Eject(false);
}
```


## Reference

https://chdkutil.github.io/UsbEject


## Notice

Copyright © 2006 Simon Mourier

THIS WORK IS PROVIDED UNDER THE TERMS OF THE CODE PROJECT OPEN LICENSE.

THIS WORK IS PROVIDED "AS IS", "WHERE IS" AND "AS AVAILABLE", WITHOUT ANY EXPRESS OR IMPLIED WARRANTIES OR CONDITIONS OR GUARANTEES.
YOU, THE USER, ASSUME ALL RISK IN ITS USE, INCLUDING COPYRIGHT INFRINGEMENT, PATENT INFRINGEMENT, SUITABILITY, ETC.
AUTHOR EXPRESSLY DISCLAIMS ALL EXPRESS, IMPLIED OR STATUTORY WARRANTIES OR CONDITIONS, INCLUDING WITHOUT LIMITATION, WARRANTIES OR
CONDITIONS OF MERCHANTABILITY, MERCHANTABLE QUALITY OR FITNESS FOR A PARTICULAR PURPOSE, OR ANY WARRANTY OF TITLE OR NON-INFRINGEMENT,
OR THAT THE WORK (OR ANY PORTION THEREOF) IS CORRECT, USEFUL, BUG-FREE OR FREE OF VIRUSES. YOU MUST PASS THIS DISCLAIMER ON WHENEVER
YOU DISTRIBUTE THE WORK OR DERIVATIVE WORKS.
