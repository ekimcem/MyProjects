using UnityEngine;
public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform targetPos;
    //[SerializeField] private GameObject PlayerTwoLevelTwo;
    // [SerializeField] private float cameraSpeed;
    private Vector3 distance;
    //private float offset;
    private void Start()
    { 
        distance = transform.position - targetPos.position;
    }
    void LateUpdate()
    {
        // transform.position = Vector3.Lerp(transform.position, targetPos.position,cameraSpeed * Time.deltaTime);
        if (targetPos != null)
        {
            transform.position = targetPos.position + distance;
        }
    }
}
