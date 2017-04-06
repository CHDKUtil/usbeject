// UsbEject version 1.0 March 2006
// written by Simon Mourier <email: simon [underscore] mourier [at] hotmail [dot] com>

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace UsbEject.Library
{
    /// <summary>
    /// The device class for volume devices.
    /// </summary>
    public class VolumeDeviceClass : DeviceClass
    {
        internal readonly SortedDictionary<string, string> _logicalDrives = new SortedDictionary<string, string>();

        /// <summary>
        /// Initializes a new instance of the VolumeDeviceClass class.
        /// </summary>
        public VolumeDeviceClass()
            : base(new Guid(Native.GUID_DEVINTERFACE_VOLUME))
        {
            StringBuilder sb = new StringBuilder(1024);
            foreach (string drive in Environment.GetLogicalDrives())
            {
                if (Native.GetVolumeNameForVolumeMountPoint(drive, sb, sb.Capacity))
                {
                    string volumeName = sb.ToString();
                    _logicalDrives.Add(volumeName, drive.Replace("\\", ""));
                    Trace.WriteLine(drive + " ==> " + volumeName);
                }
            }
        }

        internal override Device CreateDevice(DeviceClass deviceClass, Native.SP_DEVINFO_DATA deviceInfoData, string path, int index, int disknum = -1)
        {
            return new Volume(deviceClass, deviceInfoData, path, index);
        }
    }
}
