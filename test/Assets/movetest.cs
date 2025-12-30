using UnityEngine;

public class movetest : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public float rotSpeed = 5.0f;
    public Camera mainCamera;
    public LayerMask groundLayer;
    void Start()
    {
        
    }

    
    void Update()
    {
        float xx = Input.GetAxis("Horizontal");
        float zz = Input.GetAxis("Vertical");

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        /*Debug.Log(xx);*/
       /* Vector3 temppos = transform.position;
        temppos.x += xx * moveSpeed * Time.deltaTime;
        temppos.z += zz * moveSpeed * Time.deltaTime;

        transform.position = temppos;*/

        transform.position += new Vector3(xx, 0.0f, zz)* Time.deltaTime* moveSpeed;
        if(Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer) )
        {
            Debug.Log("rayHit\n");
            Vector3 lookDir = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            Debug.Log(lookDir);
            transform.LookAt(lookDir);
        }
        
    }
}
