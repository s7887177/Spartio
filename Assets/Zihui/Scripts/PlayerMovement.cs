using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float vertical;
    [SerializeField]
    float horizontal;
    [SerializeField]
    float mouse_x;
    [SerializeField]
    float mouse_y;
    [SerializeField]
    float movementSpeed;
    [SerializeField]
    float rotateSpeed;
  

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        mouse_x = Input.GetAxis("Mouse X");
        mouse_y = Input.GetAxis("Mouse Y");

        this.transform.eulerAngles += this.transform.up * mouse_x * rotateSpeed;
        this.transform.position+= (this.transform.right * horizontal + this.transform.forward * vertical) * movementSpeed * Time.deltaTime;

    }
}
