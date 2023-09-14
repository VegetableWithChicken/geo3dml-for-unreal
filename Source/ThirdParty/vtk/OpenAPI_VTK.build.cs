// Copyright 2020-2021 CesiumGS, Inc. and Contributors

using UnrealBuildTool;
using System;
using System.Collections.Generic;
using System.IO;
using System.Collections;


public class OpenAPI_VTK : ModuleRules
{
    public OpenAPI_VTK(ReadOnlyTargetRules Target) : base(Target)
    {
        PCHUsage = ModuleRules.PCHUsageMode.UseExplicitOrSharedPCHs;
        bUseRTTI = true;
        Type = ModuleType.External;

        string libPath = Path.Combine(ModuleDirectory, "lib");
        string binPath = Path.Combine(ModuleDirectory, "bin");
        PublicIncludePaths.AddRange(
            new string[] {
                Path.Combine(ModuleDirectory, "include/vtk-9.2"),
                Path.Combine(ModuleDirectory, "include/vtk-9.2/vtklibxml2/include"),
                Path.Combine(ModuleDirectory, "include/vtk-9.2/vtkdiy2/include"),
                Path.Combine(ModuleDirectory, "include/vtk-9.2/vtklibxml2/include"),
                Path.Combine(ModuleDirectory, "include/vtk-9.2/vtknlohmannjson/include"),
                Path.Combine(ModuleDirectory, "include/vtk-9.2/vtkogg/include"),
                Path.Combine(ModuleDirectory, "include/vtk-9.2/vtknetcdf/include"),
                Path.Combine(ModuleDirectory, "include/vtk-9.2/vtktheora/include"),
                Path.Combine(ModuleDirectory, "include/vtk-9.2/vtklibproj/include"),
                Path.Combine(ModuleDirectory, "include/vtk-9.2/vtklibharu/include"),
                Path.Combine(ModuleDirectory, "include/vtk-9.2/vtkglew/include"),
                Path.Combine(ModuleDirectory, "include/vtk-9.2/vtkfreetype/include"),
                Path.Combine(ModuleDirectory, "include/vtk-9.2/vtkexodusII/include"),
                //Path.Combine(ModuleDirectory, "include/vtk-9.2/vtkexodusII/include")
               // Path.Combine(ModuleDirectory, "../ThirdParty/libxml2/libxml2-2.9.10/include")

            }
        );

        PrivateIncludePaths.AddRange(
            new string[] {
            }
        );



        PublicDependencyModuleNames.AddRange(
            new string[]
            {
                "Core",
                "Projects",
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
        //get all .lib file
        if (Target.Platform == UnrealTargetPlatform.Win64)
        {
            //lib
            string vtklibfolderPath=libPath;
            ArrayList vtklibs=new ArrayList() ;
            foreach (string filePath in Directory.GetFiles(vtklibfolderPath, "*.lib"))
            {
                vtklibs.Add(filePath);
            }
            foreach (string lib in vtklibs)
            {  
             PublicAdditionalLibraries.Add(Path.Combine(vtklibfolderPath,lib));
            }

            //dll
            string vtkbinfoldpath=binPath;
            ArrayList vtkdlls=new ArrayList() ;
            foreach (string filePath in Directory.GetFiles(vtkbinfoldpath, "*.dll"))
            {
                vtkdlls.Add(filePath);
            }
            foreach(string dll in vtkdlls){
            //PublicDelayLoadDlls.AddRange(geolibs.Select(dll));
                RuntimeDependencies.Add(Path.Combine(vtkbinfoldpath,dll));
            }

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
}
