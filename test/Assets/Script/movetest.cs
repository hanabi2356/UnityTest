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

    private void FixedUpdate()
    {
        float xx = Input.GetAxis("Horizontal");
        float zz = Input.GetAxis("Vertical");

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        transform.position += new Vector3(xx, 0.0f, zz) * moveSpeed*Time.fixedDeltaTime;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
        {
            Vector3 lookDir = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            transform.LookAt(lookDir);
        }
    }


    void Update()
    {
       
        
    }
}
