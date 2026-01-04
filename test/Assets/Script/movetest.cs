using UnityEngine;
using System.Collections;
using UnityEditorInternal;
public class movetest : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public float rotSpeed = 5.0f;
    public Camera mainCamera;
    public LayerMask groundLayer;
    public float dashPower = 10.0f;
    public float dashTime=2.0f;
    public float dashCoolDown=5.0f;

    Rigidbody rb;
    bool isDash;
    bool canDash;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float xx = Input.GetAxis("Horizontal");
        float zz = Input.GetAxis("Vertical");
        moveUpdate(xx, zz);
        rotUpdate();
    }


    void Update()
    {
               
        
    }
    private void moveUpdate(float x, float z)
    {
        transform.position += new Vector3(x, 0.0f, z) * moveSpeed * Time.fixedDeltaTime;
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(DashCoroutine());
        }
    }
    private void rotUpdate()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;


        if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
        {
            Vector3 lookDir = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            transform.LookAt(lookDir);
        }
    }
    IEnumerator DashCoroutine()
    {
        isDash = true;
        canDash = false;
        rb.useGravity = false;

        Vector3 dashDirection = transform.forward;
        rb.linearVelocity = dashDirection * dashPower;

        yield return new WaitForSeconds(dashTime);

        rb.useGravity = true;
        isDash = false;
        
        yield return new WaitForSeconds(dashCoolDown);
        canDash = true;
    }
}
