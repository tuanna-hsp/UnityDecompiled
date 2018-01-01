using System;
using System.Runtime.CompilerServices;

namespace UnityEditorInternal
{
	public static class ScriptUpdatingManager
	{
		public static extern int numberOfTimesAsked
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool WaitForVCSServerConnection(bool reportTimeout);

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void ReportExpectedUpdateFailure();

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void ReportGroupedAPIUpdaterFailure(string msg);

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void ResetConsentStatus();
	}
}
