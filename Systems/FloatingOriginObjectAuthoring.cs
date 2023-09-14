using SpaceGraphicsToolkit_Extension;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

//[ExecuteInEditMode]
//https://forum.unity.com/threads/ecs-and-camera-movement.536001/
public class FloatingOriginObjectAuthoring : MonoBehaviour
{
    [SerializeField]
    public SgtPosition originData;

    public void Initialize()
    {
        originData = new SgtPosition(transform.position);
    }

    public class FloatingOriginObjectAuthoringBaker : Baker<FloatingOriginObjectAuthoring>
    {
        public override void Bake(FloatingOriginObjectAuthoring authoring)
        {
            authoring.Initialize();

            Entity floatingOriginEntity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(floatingOriginEntity, new FloatingOriginObjectData
            {
                OriginData = authoring.originData
            });
        }
    }
}

public struct FloatingOriginObjectData : IComponentData
{
    public SgtPosition OriginData;
}

public struct FloatingOriginObjectWorldOffset : IComponentData
{
    public SgtPosition OriginData;
}
