using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

[UpdateBefore(typeof(TransformSystemGroup))]
[BurstCompile]
public partial struct PlayerMoveSystem : ISystem
{
    [BurstCompile]
    void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<MainThread>();
        state.RequireForUpdate<FloatingOriginObjectWorldOffset>();
        state.RequireForUpdate<PlayerMoveInput>();
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        var endSimulationBufferSystem = SystemAPI.GetSingleton<EndSimulationEntityCommandBufferSystem.Singleton>();
        EntityCommandBuffer commandBuffer = endSimulationBufferSystem.CreateCommandBuffer(state.WorldUnmanaged);
        var deltaTime = SystemAPI.Time.DeltaTime;
        new PlayerMoveJob { DeltaTime = deltaTime, ecb = commandBuffer }.Schedule();
    }
}

[BurstCompile]
public partial struct PlayerMoveJob : IJobEntity
{
    public float DeltaTime;
    public EntityCommandBuffer ecb;

    [BurstCompile]
    private void Execute(in Entity self, ref LocalTransform transform, in PlayerMoveInput moveInput)
    {
        transform.Position.xz += moveInput.Value * 150f * DeltaTime;
        if(math.lengthsq(moveInput.Value) > float.Epsilon)
        {
            float3 forward = new float3(moveInput.Value.x, 0f, moveInput.Value.y);
            transform.Rotation = quaternion.LookRotation(forward, math.up());
        }
        ecb.SetComponent(self, new FloatingOriginObjectWorldOffset { OriginData = new SpaceGraphicsToolkit_Extension.SgtPosition(transform.Position) });
    }
}