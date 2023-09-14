using SpaceGraphicsToolkit_Extension;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class PlayerAuthoring : MonoBehaviour
{
    [SerializeField]
    public SgtPosition originData;

    public void Initialize()
    {
        Debug.Log("PlayerAuthoring Initialize called");
        originData = new SgtPosition(transform.position);
    }

    public class PlayerAuthoringBaker : Baker<PlayerAuthoring>
    {
        public override void Bake(PlayerAuthoring authoring)
        {
            authoring.Initialize();

            var playerEntity = GetEntity(TransformUsageFlags.Dynamic);

            AddComponent<PlayerTag>(playerEntity);
            AddComponent<PlayerMoveInput>(playerEntity);
            AddComponent(playerEntity, new FloatingOriginObjectWorldOffset { OriginData = authoring.originData });
        }
    }
}
