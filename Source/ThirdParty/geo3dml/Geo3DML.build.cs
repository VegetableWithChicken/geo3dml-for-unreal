// Copyright 2020-2021 CesiumGS, Inc. and Contributors

using UnrealBuildTool;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

public class Geo3DML : ModuleRules
{
    public Geo3DML(ReadOnlyTargetRules Target) : base(Target)
    {
        PCHUsage = ModuleRules.PCHUsageMode.UseExplicitOrSharedPCHs;
        bUseRTTI = true;
        Type = ModuleType.External;

        string LibPath = Path.Combine(ModuleDirectory, "lib");
        PublicIncludePaths.AddRange(
            new string[] {
                Path.Combine(ModuleDirectory, "include"),
               // Path.Combine(ModuleDirectory, "../vtk/include/vtk-9.2/vtklibxml2/include")
               // Path.Combine(ModuleDirectory, "../ThirdParty/libxml2/libxml2-2.9.10/include")

            }
        );

        PrivateIncludePaths.AddRange(
            new string[] {
                Path.Combine(ModuleDirectory, "src")
                // ... add other private include paths required here ...
            }
        );



        PublicDependencyModuleNames.AddRange(
            new string[]
            {
                "Core",
                "Projects",
                "OpenAPI_VTK"
                // ... add other public dependencies that you statically link with here ...
            }
        );


        PrivateDependencyModuleNames.AddRange(
            new string[]
            {
                "RHI",
                "CoreUObject",
                "Engine",
                "MeshDescription",
                "StaticMeshDescription",
                "HTTP",
                "LevelSequence",
                "RenderCore",
                "SunPosition",
                "DeveloperSettings",
                "UMG",
                "Renderer",
            }
        );



        PublicDefinitions.AddRange(
            new string[]
            {

            }
        );

        if (Target.bCompilePhysX && !Target.bUseChaos)
        {

        }
        else
        {
            PrivateDependencyModuleNames.Add("Chaos");
        }

        if (Target.bBuildEditor == true)
        {
            PublicDependencyModuleNames.AddRange(
                new string[] {
                    "UnrealEd",
                    "Slate",
                    "SlateCore",
                    "WorldBrowser",
                    "ContentBrowser",
                    "MaterialEditor"
                }
            );
        }

        string[] geolibs = new string[]
        {

            "libG3DXML.lib",
            "libGeo3DML.lib"
        };
        PublicAdditionalLibraries.AddRange(geolibs.Select(lib => Path.Combine(LibPath, "Release/" + lib)));

        DynamicallyLoadedModuleNames.AddRange(
            new string[]
            {
                // ... add any modules that your module loads dynamically here ...
            }
        );

        PCHUsage = PCHUsageMode.UseExplicitOrSharedPCHs;
        CppStandard = CppStandardVersion.Cpp17;
        bEnableExceptions = true;
    }
}
