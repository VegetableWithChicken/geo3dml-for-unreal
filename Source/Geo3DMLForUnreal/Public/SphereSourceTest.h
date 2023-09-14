// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GameFramework/Actor.h"
#include "SphereSourceTest.generated.h"


class UProceduralMeshComponent;
UCLASS()
class GEO3DMLFORUNREAL_API ASphereSourceTest : public AActor
{
	GENERATED_BODY()

public:
	// Sets default values for this actor's properties
	ASphereSourceTest();

protected:
	UPROPERTY(VisibleAnywhere)
	USceneComponent* ThisScene;
	UPROPERTY(VisibleAnywhere)
	UProceduralMeshComponent* mesh;

	void GenerateSphere();


public:
	virtual void PostActorCreated() override;
	virtual void PostLoad() override;

};
