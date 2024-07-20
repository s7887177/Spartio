using Sirenix.OdinInspector;
using System;
using UnityEngine;
using UnityEngine.Rendering.UI;
public class PlayerMovement : MonoBehaviour
{
    //[SerializeField]
    //float _vertical;
    //[SerializeField]
    //float _horizontal;
    //[SerializeField]
    //float _mouse_x;
    //[SerializeField]
    //float _mouse_y;

    [Header("Components")]
    [SerializeField] private Transform _neck;

    [Header("Settings")]
    [SerializeField] private float _moveSpeed;
    [SerializeField, PropertyRange(0, 1)] private float _moveLerp = .5f;
    [SerializeField] private float _rotateSpeed;
    [SerializeField, PropertyRange(0, 1)] private float _rotateLerp = .5f;

    // Update is called once per frame
    void Update()
    {
        var _moveInput = new Vector2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));

        var _mouse_x = Input.GetAxisRaw("Mouse X");
        var _mouse_y = Input.GetAxisRaw("Mouse Y");

        var neckRotation = _neck.transform.localEulerAngles;
        neckRotation = NormalizeRotationX(neckRotation);

        var calculatedBodyPosition = CalBodyPosition(this.transform.position, this.transform.right, this.transform.forward, _moveInput);
        var calculatedBodyRotation = CalBodyRotation(this.transform.eulerAngles, this.transform.up, _mouse_x);
        var calculatedNeckRotation = CalNeckRotation(_neck.transform.localEulerAngles, _mouse_y);

        // Mutate State
        this.transform.position = Vector3.Lerp(this.transform.position, calculatedBodyPosition, _moveLerp);
        this.transform.eulerAngles = Vector3.Lerp(this.transform.eulerAngles, calculatedBodyRotation, _rotateLerp);
        _neck.transform.localEulerAngles = Vector3.Lerp(neckRotation, calculatedNeckRotation, _rotateLerp);
    }

    private Vector3 CalBodyPosition(Vector3 position, Vector3 right, Vector3 forward, Vector2 input)
    {
        return position + (right * input.x + forward * input.y) * _moveSpeed * Time.deltaTime;
    }
    private Vector3 CalBodyRotation(Vector3 rotation, Vector3 up, float _mouse_x)
    {
        return rotation + this.transform.up * _mouse_x * _rotateSpeed * Time.deltaTime;
    }
    private Vector3 CalNeckRotation(Vector3 rotation, float _mouse_y)
    {
        var x = rotation.x;
        x -= _mouse_y * _rotateSpeed * Time.deltaTime;
        rotation.x = x;
        rotation = NormalizeRotationX(rotation);
        x = rotation.x;
        x = ClampNeckAngle(x);
        rotation.x = x;
        return rotation;
    }
    private Vector3 NormalizeRotationX(Vector3 rotation)
    {
        var x = rotation.x;
        while (x > 180)
        {
            x -= 360;
        }
        while (x < -180)
        {
            x += 360;
        }
        rotation.x = x;
        return rotation;
    }
    private float ClampNeckAngle(float x)
    {
        x = Math.Clamp(x, -90, 90);
        return x;
    }
}
