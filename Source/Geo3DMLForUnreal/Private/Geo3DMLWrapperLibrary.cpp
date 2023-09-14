// Fill out your copyright notice in the Description page of Project Settings.


#include "Geo3DMLWrapperLibrary.h"

#include "Windows/AllowWindowsPlatformTypes.h"
#include <g3dvtk/ObjectFactory.h>
#include <g3dxml/XMLReader.h>
#include "Windows/HideWindowsPlatformTypes.h"

void UGeo3DMLWrapperLibrary::OpenAPI_XMLReader(FString inPath) {
	FString tempPath = inPath.Replace(TEXT("\\"), TEXT("/"));
	std::string Temp = TCHAR_TO_UTF8(*tempPath);
	g3dvtk::ObjectFactory g3dFactory;
	// 读取文件。
	g3dxml::XMLReader xmlReader(&g3dFactory);
	geo3dml::Object* g3dObject = xmlReader.LoadXMLFile(Temp);  // 该方法可读取工程或者模型。
	// 检查返回的对象类型。
	geo3dml::Model* model = dynamic_cast<geo3dml::Model*>(g3dObject);
	if (model != NULL) {
		// 按模型处理。
		// ......
	}
	else {
		geo3dml::Project* project = dynamic_cast<geo3dml::Project*>(g3dObject);
		if (project != NULL) {
			project->BindFeatureClassesToLayers(&g3dFactory); // 将要素类与图层绑定起来。
			// 按工程中的*geo3dml::Map*和*geo3dml::Model*来处理。
			// ......
		}
	}
}