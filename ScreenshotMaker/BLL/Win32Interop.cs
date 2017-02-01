﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Agilent.System.IO
{
	public class Win32Interop
	{
		[Flags]
		public enum MoveFileFlags : uint
		{
			MOVEFILE_REPLACE_EXISTING = 1u,
			MOVEFILE_COPY_ALLOWED = 2u,
			MOVEFILE_DELAY_UNTIL_REBOOT = 4u,
			MOVEFILE_WRITE_THROUGH = 8u,
			MOVEFILE_CREATE_HARDLINK = 16u,
			MOVEFILE_FAIL_IF_NOT_TRACKABLE = 32u
		}
		public enum ErrorCodes : int
		{
			ERROR_ALREADY_EXISTS	= 183
		}
		[DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		public static extern bool MoveFileEx(string lpExistingFileName, string lpNewFileName, MoveFileFlags dwFlags);
		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern bool CreateDirectory(string lpPathName, IntPtr lpSecurityAttributes);
	}
}
