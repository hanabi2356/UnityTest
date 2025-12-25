using UnityEngine;

public class movetest : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    void Start()
    {
        
    }

    
    void Update()
    {
        float xx = Input.GetAxis("Horizontal");
        float zz = Input.GetAxis("Vertical");
        
        Vector3 temppos = transform.position;
        temppos.x += xx * moveSpeed * Time.deltaTime;
        temppos.z += zz * moveSpeed * Time.deltaTime;

        transform.position = temppos;
    }
}
