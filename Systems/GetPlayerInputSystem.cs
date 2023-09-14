using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

[UpdateInGroup(typeof(InitializationSystemGroup),OrderLast = true)]
public partial class GetPlayerInputSystem : SystemBase
{
    private DemoMovement inputActions;
    private Entity _playerEntity;
    bool updatedMovement = false;

    protected override void OnCreate()
    {
        RequireForUpdate<PlayerTag>();
        RequireForUpdate<PlayerMoveInput>();
        RequireForUpdate<MainThread>();

        inputActions = new DemoMovement();
    }

    protected override void OnStartRunning()
    {
        inputActions.Enable();
        _playerEntity = SystemAPI.GetSingletonEntity<PlayerTag>();
    }

    protected override void OnUpdate()
    {
        Vector2 curMovement = inputActions.PlayerActionsMap.PlayerMovement.ReadValue<Vector2>();
        if (curMovement != Vector2.zero)
        {
            SystemAPI.SetSingleton(new PlayerMoveInput { Value = curMovement });
            updatedMovement = true;
        }
        else if(updatedMovement)
        {
            SystemAPI.SetSingleton(new PlayerMoveInput { Value = Vector2.zero });
            updatedMovement = false;
        }
    }

    protected override void OnStopRunning()
    {
        inputActions.Disable();
        _playerEntity = Entity.Null;
    }
}