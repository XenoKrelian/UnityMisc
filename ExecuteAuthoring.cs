using Unity.Entities;
using UnityEngine;

public class ExecuteAuthoring : MonoBehaviour
{
    public bool MainThread;
    public bool GameObjectSync;

    class Baker : Baker<ExecuteAuthoring>
    {
        public override void Bake(ExecuteAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.None);
            if (authoring.MainThread) AddComponent<MainThread>(entity);
            if (authoring.GameObjectSync) AddComponent<GameObjectSync>(entity);
        }
    }
}

public struct MainThread : IComponentData
{
}

public struct GameObjectSync : IComponentData
{
}