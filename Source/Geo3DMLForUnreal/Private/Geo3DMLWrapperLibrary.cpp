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
	// ��ȡ�ļ���
	g3dxml::XMLReader xmlReader(&g3dFactory);
	geo3dml::Object* g3dObject = xmlReader.LoadXMLFile(Temp);  // �÷����ɶ�ȡ���̻���ģ�͡�
	// ��鷵�صĶ������͡�
	geo3dml::Model* model = dynamic_cast<geo3dml::Model*>(g3dObject);
	if (model != NULL) {
		// ��ģ�ʹ���
		// ......
	}
	else {
		geo3dml::Project* project = dynamic_cast<geo3dml::Project*>(g3dObject);
		if (project != NULL) {
			project->BindFeatureClassesToLayers(&g3dFactory); // ��Ҫ������ͼ���������
			// �������е�*geo3dml::Map*��*geo3dml::Model*������
			// ......
		}
	}
}