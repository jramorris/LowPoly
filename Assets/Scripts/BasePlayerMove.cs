using UnityEngine;

public class BasePlayerMove : MonoBehaviour
{
    private float _vertical;
    private float _horizontal;
    private Vector3 _position;
    private int _jump;

    void ReadInput()
    {
        _vertical = Input.GetAxis("Vertical");
        _horizontal = Input.GetAxis("Horizontal");

        if (Input.GetButton("Jump"))
        {
            _jump = 1;
        } else if (Input.GetButton("Fire1"))
        {
            _jump = -1;
        } else
        {
            _jump = 0;
        }
    }

    void Update()
    {
        ReadInput();
        _position = new Vector3(_horizontal, _jump, _vertical) * .05f;
        transform.position += _position;
        Vector3 mouse = Input.mousePosition;
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(new Vector3(
                                                            mouse.x,
                                                            mouse.y,
                                                            transform.position.y));
        Vector3 forward = mouseWorld - transform.position;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(forward, Vector3.up), 0.1f);

    }
}
