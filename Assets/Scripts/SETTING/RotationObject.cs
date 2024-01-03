using UnityEngine;

public class RotationObject : MonoBehaviour
{
    public float rotationSpeed = 10f; // Tốc độ quay của vật thể

    void Update()
    {
        // Quay vật thể quanh trục Y theo tốc độ đã chỉ định
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}