// Android Manifest Configurator
// Created by Patryk Stepniewski
// Copyright (c) 2014-2017 gameDNA Ltd. All Rights Reserved.

using System.IO;

namespace UnrealBuildTool.Rules
{
	public class AndroidManifestConfigurator : ModuleRules
	{
		public AndroidManifestConfigurator(ReadOnlyTargetRules Target) : base(Target)
		{
			PCHUsage = PCHUsageMode.UseExplicitOrSharedPCHs;

			Definitions.Add("WITH_ANDROIDMANIFESTCONFIGURATOR=1");

			PrivateIncludePaths.Add("AndroidManifestConfigurator/Private");

            PublicDependencyModuleNames.AddRange(new string[] { "Engine", "Core", "CoreUObject" });
			PrivateIncludePathModuleNames.AddRange(new string[] { "Settings" });

			// Additional Frameworks and Libraries for Android
			if (Target.Platform == UnrealTargetPlatform.Android)
			{
				PrivateDependencyModuleNames.AddRange(new string[] { "Launch" });
				string PluginPath = Utils.MakePathRelativeTo(ModuleDirectory, Target.RelativeEnginePath);
				AdditionalPropertiesForReceipt.Add(new ReceiptProperty("AndroidPlugin", Path.Combine(PluginPath, "AndroidManifestConfigurator_UPL_Android.xml")));
			}
		}
	}
}
