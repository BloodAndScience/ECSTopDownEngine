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

        // ...
        // Movement Job
        // ...

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            MovementJob moveJob = new MovementJob
            {
                topBound = GameManager.GM.topBound,
                bottomBound = GameManager.GM.bottomBound,
                deltaTime = Time.deltaTime
            };

            JobHandle moveHandle = moveJob.Schedule(this, 64, inputDeps);

            return moveHandle;
        }
    }
}
