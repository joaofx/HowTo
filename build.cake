// TODO: generate TestResults.xml in another folder
#tool "nuget:?package=NUnit.Runners&version=2.6.4"

var target = Argument("target", "CopyConfigs");
var outputDir =  MakeAbsolute(Directory("./build")).ToString();
var solidrOutputDir =  MakeAbsolute(Directory("./build/SolidR")).ToString();
var environment = Argument("env", "dev");

Task("Settings")
    .Does(() => {
		if (target == "Tests") {
			environment = "test";
			Information("Target test. Setting environment to test");
		}

		Information("Output: {0}", outputDir);
        Information("Environment: {0}", environment);
    });

Task("Clean")
    .Does(() => {
        if (DirectoryExists(outputDir)) {
            CleanDirectories(outputDir);
        }
        CreateDirectory(outputDir);
    });

Task("Build")
	.IsDependentOn("Settings")
    .Does(() => {
		MSBuild("./src/HowTo.sln", configurator =>
    		configurator
				.SetConfiguration("Debug")
				.SetVerbosity(Verbosity.Minimal)
				.UseToolVersion(MSBuildToolVersion.VS2015)
				.SetMSBuildPlatform(MSBuildPlatform.x86)
				.SetPlatformTarget(PlatformTarget.MSIL)
				.WithProperty("OutDir", outputDir)
			);
    });

Task("CopyConfigs")
    .IsDependentOn("Build")
    .Does(() => {
		Information("Copying all settings files");
		CopyFiles("./config/*.config", outputDir);

		var settingsFile = "config/"+environment+".config";
		var outputSettingsFile = outputDir+"/database.config";

		Information("Copying {0} to {1}", settingsFile, outputSettingsFile);
        CopyFile(settingsFile, outputSettingsFile);
    });

Task("Tests")
    .IsDependentOn("CopyConfigs")
    .Does(() => {
		var assemblies = GetFiles("./build/*Tests*.dll");

		NUnit(assemblies, new NUnitSettings {
			// 10 seconds for each test
			Timeout = 10000, 
			StopOnError = false
		});
    });

// Task("SolidR")
// 	.IsDependentOn("Settings")
//     .Does(() => {
// 		MSBuild("./src/SolidR/SolidR.csproj", configurator =>
//     		configurator
// 				.SetConfiguration("Release")
// 				.SetVerbosity(Verbosity.Minimal)
// 				.UseToolVersion(MSBuildToolVersion.VS2015)
// 				.SetMSBuildPlatform(MSBuildPlatform.x86)
// 				.SetPlatformTarget(PlatformTarget.MSIL)
// 				.WithProperty("OutDir", solidrOutputDir)
// 			);

// 		CopyDirectory(solidrOutputDir, @"C:\tools\solidr");
//     });

RunTarget(target);