using UnityEngine;

public class CoinRotation : MonoBehaviour
{
    public float rotationSpeed = 100f;

    void Update()
    {
        //rotate the coin 
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}

