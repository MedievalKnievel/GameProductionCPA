using UnityEngine;

public class shootPos : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float distanceBehind = 5f;
    [SerializeField] private float cameraHeight = 2f;
    [SerializeField] private float smoothSpeed = 0.125f;
    // Update is called once per frame
    void Update()
    {
        Vector3 desiredPosition = target.position - target.forward * distanceBehind + Vector3.up * cameraHeight;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
