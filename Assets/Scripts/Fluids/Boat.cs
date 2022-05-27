using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    [SerializeField] GameObject boat;
    [SerializeField] float depth = 1;
    [SerializeField] float speed = 1;
    [SerializeField] float turnRate = 1;
    [SerializeField] float lerpRate = 0.1f;

    Rigidbody rb;
    Vector3 prevUp = Vector3.up;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
        
    void Update()
    {
        float yaw = Input.GetAxis("Horizontal");
        rb.AddTorque(new Vector3(0, yaw * turnRate, 0), ForceMode.Force);

        if (Input.GetKey(KeyCode.W))
		{
            rb.AddRelativeForce(Vector3.forward * speed, ForceMode.Force);
		}

        if (Physics.Raycast(transform.position + Vector3.up * 5, Vector3.down, out RaycastHit raycastHit))
		{
            Debug.DrawRay(raycastHit.point, raycastHit.normal);
            transform.position = raycastHit.point + (Vector3.down * depth);

            Vector3 up = Vector3.Lerp(prevUp, raycastHit.normal, lerpRate * Time.deltaTime);

            Quaternion qrotation = Quaternion.LookRotation(up, Vector3.forward) * Quaternion.AngleAxis(90, Vector3.right);

            Quaternion qpitch = Quaternion.AngleAxis(-qrotation.eulerAngles.x, Vector3.right);
            Quaternion qroll = Quaternion.AngleAxis(-qrotation.eulerAngles.z, Vector3.forward);
            Quaternion qyaw = Quaternion.AngleAxis(rb.rotation.eulerAngles.y, Vector3.up);

            transform.rotation = qpitch * qroll * qyaw;
            prevUp = up;
        }
    }
}
