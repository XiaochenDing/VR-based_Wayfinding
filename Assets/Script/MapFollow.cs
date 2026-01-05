using UnityEngine;

public class MapFollow : MonoBehaviour
{
    public Transform playerHead;  
    public Vector3 offset = new Vector3(0, -0.2f, 1f); 

    void LateUpdate()
    {
        if (playerHead == null) return;

      
        transform.position = playerHead.position + playerHead.forward * offset.z + playerHead.up * offset.y;

     
        Vector3 lookDirection = playerHead.position - transform.position;
        lookDirection.y = 0;
        transform.rotation = Quaternion.LookRotation(lookDirection);
    }
}
