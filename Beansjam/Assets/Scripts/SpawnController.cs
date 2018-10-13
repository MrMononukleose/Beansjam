using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnController : MonoBehaviour
{
    private float LeftXMinPosition = -7.5f;
    private float LeftXMaxPosition = -3.5f;

    private float RightXMinPosition = 3.5f;
    private float RightXMaxPosition = 7.5f;

    private float MinYPosition = -4.1f;
    private float MaxYPosition = 4.1f;

    public float SpawnMinRange = 1f;
    public float SpawnMaxRange = 2f;

    public GameObject Zuckerwatte;

    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        var positionVectorLeft = new Vector3(Random.Range(LeftXMinPosition, LeftXMaxPosition), Random.Range(MinYPosition, MaxYPosition));
        var positionVectorRight = new Vector3(Random.Range(RightXMinPosition, RightXMaxPosition), Random.Range(MinYPosition, MaxYPosition));

        Instantiate(Zuckerwatte, positionVectorLeft, Quaternion.identity);
        Instantiate(Zuckerwatte, positionVectorRight, Quaternion.identity);
        Invoke("Spawn", Random.Range(SpawnMinRange, SpawnMaxRange));
    }
}