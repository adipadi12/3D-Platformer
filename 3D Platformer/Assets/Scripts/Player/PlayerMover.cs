using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    private float movementSpeed = 7f;
    [SerializeField]
    private float rotationSpeed = 4f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInp = Input.GetAxis("Horizontal");
        float verticalInp = Input.GetAxis("Vertical");
        
        Vector3 movemntDir = new Vector3(horizontalInp, 0, verticalInp);
        movemntDir.Normalize();

        transform.Translate(movemntDir * movementSpeed * Time.deltaTime, Space.World);

        if (movemntDir != Vector3.zero)
        {
            Quaternion lookRot = Quaternion.LookRotation(movemntDir, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRot, rotationSpeed * Time.deltaTime);
        }
    }
}
