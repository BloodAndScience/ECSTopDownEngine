using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace Shooter.ECS
{
    public class MovementSystem : JobComponentSystem 
	{
        [ComputeJobOptimization]
        struct MovementJob : IJobProcessComponentData<Position, Rotation, MoveSpeed>
        {
            public float topBound;
            public float bottomBound;
            public float deltaTime;

            public void Execute(ref Position position, [ReadOnly] ref Rotation rotation, [ReadOnly] ref MoveSpeed speed)
            {
                float3 value = position.Value;

                value += deltaTime * speed.Value * math.forward(rotation.Value);

                if (value.z < bottomBound)
                    value.z = topBound;

                position.Value = value;
            }
        }

        // ...
        // OnUpdate Code
        // ...
    }
}