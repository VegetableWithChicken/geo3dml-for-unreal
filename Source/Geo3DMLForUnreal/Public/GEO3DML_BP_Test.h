// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "Kismet/BlueprintFunctionLibrary.h"
#include "GEO3DML_BP_Test.generated.h"

/**
 * 
 */
UCLASS()
class GEO3DMLFORUNREAL_API UGEO3DML_BP_Test : public UBlueprintFunctionLibrary
{
	GENERATED_BODY()

public:
	UFUNCTION(BlueprintCallable)
	static void ReadGeoData(FString inPath);
	
};
