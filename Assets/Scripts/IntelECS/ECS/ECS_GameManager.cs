using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace Shooter.ECS
{
    public class GameManager : MonoBehaviour
    {
        EntityManager manager;
        

        void Start()
        {
            manager = World.Active.GetOrCreateManager<EntityManager>();
            AddShips(enemyShipCount);
        }

        void Update()
        {
            if (Input.GetKeyDown("space"))
                AddShips(enemyShipIncremement);
        }

        void AddShips(int amount)
        {
            NativeArray<Entity> entities = new NativeArray<Entity>(amount, Allocator.Temp);
            manager.Instantiate(enemyShipPrefab, entities);

            for (int i = 0; i < amount; i++)
            {
                float xVal = Random.Range(leftBound, rightBound);
                float zVal = Random.Range(0f, 10f);
                manager.SetComponentData(entities[i], new Position { Value = new float3(xVal, 0f, topBound + zVal) });
                manager.SetComponentData(entities[i], new Rotation { Value = new quaternion(0, 1, 0, 0) });
                manager.SetComponentData(entities[i], new MoveSpeed { Value = enemySpeed });
            }
            entities.Dispose();
        }
    }
}

