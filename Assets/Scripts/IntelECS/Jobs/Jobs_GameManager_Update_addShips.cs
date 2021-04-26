void Update()
{
    moveHandle.Complete();

    if (Input.GetKeyDown("space"))
        AddShips(enemyShipIncremement);

    moveJob = new MovementJob()
    {
        moveSpeed = enemySpeed,
        topBound = topBound,
        bottomBound = bottomBound,
        deltaTime = Time.deltaTime
    };

    moveHandle = moveJob.Schedule(transforms);

    JobHandle.ScheduleBatchedJobs();
}

void AddShips(int amount)
{
    moveHandle.Complete();

    transforms.capacity = transforms.length + amount;

    for (int i = 0; i < amount; i++)
    {
        float xVal = Random.Range(leftBound, rightBound);
        float zVal = Random.Range(0f, 10f);

        Vector3 pos = new Vector3(xVal, 0f, zVal + topBound);
        Quaternion rot = Quaternion.Euler(0f, 180f, 0f);

        var obj = Instantiate(enemyShipPrefab, pos, rot) as GameObject;

        transforms.Add(obj.transform);
    }
}




