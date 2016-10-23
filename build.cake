var target = Argument("target", "Build");
var outputDir =  MakeAbsolute(Directory("./build")).ToString();
var solidrOutputDir =  MakeAbsolute(Directory("./build/SolidR")).ToString();

Task("Settings")
    .Does(() => {
		Information(outputDir);
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