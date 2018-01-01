using System;
using UnityEditor.Connect;
using UnityEditor.CrashReporting;

namespace UnityEditor.Web
{
	[InitializeOnLoad]
	internal class CrashReportingAccess : CloudServiceAccess
	{
		[Serializable]
		public struct CrashReportingServiceState
		{
			public bool crash_reporting;
		}

		private const string kServiceName = "Game Performance";

		private const string kServiceDisplayName = "Game Performance";

		private const string kServiceUrl = "https://public-cdn.cloud.unity3d.com/editor/production/cloud/crash";

		static CrashReportingAccess()
		{
			UnityConnectServiceData cloudService = new UnityConnectServiceData("Game Performance", "https://public-cdn.cloud.unity3d.com/editor/production/cloud/crash", new CrashReportingAccess(), "unity/project/cloud/crashreporting");
			UnityConnectServiceCollection.instance.AddService(cloudService);
		}

		public override string GetServiceName()
		{
			return "Game Performance";
		}

		public override string GetServiceDisplayName()
		{
			return "Game Performance";
		}

		public override bool IsServiceEnabled()
		{
			return CrashReportingSettings.enabled;
		}

		public override void EnableService(bool enabled)
		{
			if (CrashReportingSettings.enabled != enabled)
			{
				CrashReportingSettings.SetEnabledServiceWindow(enabled);
				EditorAnalytics.SendEventServiceInfo(new CrashReportingAccess.CrashReportingServiceState
				{
					crash_reporting = enabled
				});
			}
		}

		public bool GetCaptureEditorExceptions()
		{
			return CrashReportingSettings.captureEditorExceptions;
		}

		public void SetCaptureEditorExceptions(bool captureEditorExceptions)
		{
			CrashReportingSettings.captureEditorExceptions = captureEditorExceptions;
		}
	}
}
