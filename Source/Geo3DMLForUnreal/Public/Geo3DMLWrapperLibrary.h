// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "Kismet/BlueprintFunctionLibrary.h"
#include "Geo3DMLWrapperLibrary.generated.h"

/**
 * 
 */
UCLASS()
class GEO3DMLFORUNREAL_API UGeo3DMLWrapperLibrary : public UBlueprintFunctionLibrary
{
	GENERATED_BODY()
public:
		UFUNCTION(BlueprintCallable, Category = "Geo3DML")
		static void OpenAPI_XMLReader(FString inPath);
	
};
