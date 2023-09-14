using UnityEngine;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Transforms;
using SpaceGraphicsToolkit_Extension;

[BurstCompile]
public partial struct FloatingOriginObjectSystem : ISystem, ISystemStartStop
{
    private Entity _playerEntity;

    public void OnStartRunning(ref SystemState state)
    {
        _playerEntity = SystemAPI.GetSingletonEntity<FloatingOriginObjectWorldOffset>();
    }

    public void OnStopRunning(ref SystemState state)
    {
        _playerEntity = Entity.Null;
    }

    [BurstCompile]
    void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<FloatingOriginObjectData>();
        state.RequireForUpdate<FloatingOriginObjectWorldOffset>();
        state.RequireForUpdate<MainThread>();
    }

    [BurstCompile]
    void OnUpdate(ref SystemState state)
    {
        UpdateFloatingOriginObjectPositionJob job = new UpdateFloatingOriginObjectPositionJob
        {
            deltaTime = SystemAPI.Time.DeltaTime,
            floatingOriginObjectWorldOffset = SystemAPI.GetComponent<FloatingOriginObjectWorldOffset>(_playerEntity).OriginData
        };

        job.ScheduleParallel();
    }
}

[BurstCompile]
partial struct UpdateFloatingOriginObjectPositionJob : IJobEntity
{
    public float deltaTime;
    
    [ReadOnly]
    public SgtPosition floatingOriginObjectWorldOffset;

    void Execute(ref LocalTransform transform,
        in FloatingOriginObjectData floatingOriginObjectData)
    {
        transform = transform.RotateZ(4.5f * deltaTime);
        transform.Position = SgtPosition.VectorRefRO(ref floatingOriginObjectWorldOffset, floatingOriginObjectData.OriginData);
    }
}