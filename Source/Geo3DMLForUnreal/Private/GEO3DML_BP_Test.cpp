// Fill out your copyright notice in the Description page of Project Settings.


#include "GEO3DML_BP_Test.h"
#include "Pugi/pugiconfig.hpp"
#include "Pugi/pugixml.hpp"


void UGEO3DML_BP_Test::ReadGeoData(FString inPath) {
	FString tempPath = inPath.Replace(TEXT("\\"), TEXT("/"));
	std::string Temp = TCHAR_TO_UTF8(*tempPath);
	pugi::xml_document doc;
	pugi::xml_parse_result result = doc.load_file(Temp.c_str());
	pugi::xml_node TempNode = doc.root();
	const char* cc=TempNode.first_child().name();
	UE_LOG(LogTemp, Warning, TEXT("xml_parse result: %s"), ANSI_TO_TCHAR(result.description()));
	UE_LOG(LogTemp, Warning, TEXT("doc result:%s"), ANSI_TO_TCHAR(cc));

}