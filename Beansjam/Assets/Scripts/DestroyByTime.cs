using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    public float LifeTime;
    
    private void Start()
    {
        Destroy(gameObject, LifeTime);
    }
}