using UnityEngine;
using UnityEngine.VFX;

public class GeneratePhones : MonoBehaviour
{
    public bool yesRicoKaboom = false;
    public int batchCount = 5;
    public float spawnTime = 0.5f;
    float curTime = 0; 

    public float spawnRange = 13.0f;
    public GameObject phone;
    GameObject curSpawn;

    // Update is called once per frame
    void Update()
    {
        if (yesRicoKaboom && curTime <= 0) {
            for (int i = 0; i < batchCount; i++) {
                curSpawn = Instantiate(phone);
                curSpawn.transform.position = new Vector3(Random.Range(-spawnRange, spawnRange), 8.0f, 200);
            }
            curTime = spawnTime;
        }
        else if (yesRicoKaboom) {
            curTime -= Time.deltaTime;
        }
    }

    public void enableSpawns() {
        yesRicoKaboom = true;
    }
}
