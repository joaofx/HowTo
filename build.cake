var target = Argument("target", "CopyConfigs");
var outputDir =  MakeAbsolute(Directory("./build")).ToString();
var solidrOutputDir =  MakeAbsolute(Directory("./build/SolidR")).ToString();
var environment = Argument("env", "dev");

Task("Settings")
    .Does(() => {
		Information("Output: "+outputDir);
        Information("Environment: "+environment);
    });

Task("Clean")
    .Does(() => {
        if (DirectoryExists(outputDir))
        {
            CleanDirectories(outputDir);
        }
        CreateDirectory(outputDir);
    });

Task("Build")
	.IsDependentOn("Settings")
//    .IsDependentOn("Clean")
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
        CopyFile("config/"+environment+".config", outputDir+"/database.config");
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