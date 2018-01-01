using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Security.Permissions;
using UnityEngine;

[assembly: AssemblyVersion("0.0.0.0")]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.DisableOptimizations | DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: InternalsVisibleTo("UnityEditor.LinuxStandalone.Extensions")]
[assembly: InternalsVisibleTo("UnityEditor.WindowsStandalone.Extensions")]
[assembly: InternalsVisibleTo("UnityEditor.OSXStandalone.Extensions")]
[assembly: InternalsVisibleTo("UnityEditor.Networking")]
[assembly: InternalsVisibleTo("UnityEngine.Networking")]
[assembly: InternalsVisibleTo("UnityEditor.Analytics")]
[assembly: InternalsVisibleTo("UnityEditor.Purchasing")]
[assembly: InternalsVisibleTo("UnityEditor.N3DS.Extensions")]
[assembly: InternalsVisibleTo("UnityEditor.Switch.Extensions")]
[assembly: InternalsVisibleTo("UnityEditor.EditorTestsRunner")]
[assembly: InternalsVisibleTo("UnityEditor.TestRunner")]
[assembly: InternalsVisibleTo("UnityEngine.TestRunner")]
[assembly: InternalsVisibleTo("UnityEditor.TreeEditor")]
[assembly: InternalsVisibleTo("UnityEditor.Timeline")]
[assembly: InternalsVisibleTo("UnityEditor.VR")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests.Framework")]
[assembly: InternalsVisibleTo("Assembly-CSharp-Editor-firstpass-testable")]
[assembly: InternalsVisibleTo("UnityEditor.WebGL.Extensions")]
[assembly: InternalsVisibleTo("Assembly-CSharp-Editor-testable")]
[assembly: InternalsVisibleTo("UnityEditor.PS4.Extensions")]
[assembly: InternalsVisibleTo("UnityEditor.XboxOne.Extensions")]
[assembly: InternalsVisibleTo("UnityEditor.Advertisements")]
[assembly: InternalsVisibleTo("UnityEditor.UIAutomation")]
[assembly: InternalsVisibleTo("Unity.PackageManager")]
[assembly: InternalsVisibleTo("Unity.PackageManagerStandalone")]
[assembly: InternalsVisibleTo("Unity.Automation")]
[assembly: InternalsVisibleTo("Unity.PureCSharpTests")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests")]
[assembly: InternalsVisibleTo("Unity.DeploymentTests.Services")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.UnityAnalytics")]
[assembly: InternalsVisibleTo("UnityEditor.Graphs")]
[assembly: InternalsVisibleTo("UnityEditor.WSA.Extensions")]
[assembly: InternalsVisibleTo("UnityEditor.iOS.Extensions.Common")]
[assembly: InternalsVisibleTo("UnityEditor.iOS.Extensions")]
[assembly: InternalsVisibleTo("UnityEditor.AppleTV.Extensions")]
[assembly: InternalsVisibleTo("UnityEditor.Android.Extensions")]
[assembly: InternalsVisibleTo("UnityEditor.Tizen.Extensions")]
[assembly: InternalsVisibleTo("UnityEditor.PSP2.Extensions")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
[assembly: InternalsVisibleTo("UnityEditor.Facebook.Extensions")]
[assembly: InternalsVisibleTo("UnityEditor.GoogleAudioSpatializer")]
[assembly: InternalsVisibleTo("UnityEditor.InteractiveTutorialsFramework")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEditorBridge.018")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEditorBridge.019")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEditorBridge.020")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEditorBridge.021")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEditorBridge.022")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEditorBridge.023")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEditorBridge.024")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEditorBridgeDev.001")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEditorBridgeDev.002")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEditorBridgeDev.003")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEditorBridgeDev.004")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEditorBridgeDev.005")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEditorBridge.016")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEditorBridge.015")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEditorBridge.017")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEditorBridge.013")]
[assembly: InternalsVisibleTo("UnityEditor.Networking")]
[assembly: InternalsVisibleTo("UnityEditor.UI")]
[assembly: InternalsVisibleTo("UnityEditor.AR")]
[assembly: InternalsVisibleTo("UnityEditor.SpatialTracking")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEditorBridge.014")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEditorBridge.001")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEditorBridge.002")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEditorBridge.003")]
[assembly: InternalsVisibleTo("UnityEditor.HoloLens")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEditorBridge.005")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEditorBridge.004")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEditorBridge.011")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEditorBridge.010")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEditorBridge.012")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEditorBridge.008")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEditorBridge.007")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEditorBridge.006")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEditorBridge.009")]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: AssemblyIsEditorAssembly]
[assembly: UnityAPICompatibilityVersion("2018.1.0b1")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[module: UnverifiableCode]
