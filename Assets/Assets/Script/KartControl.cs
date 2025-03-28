using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class KartControl : MonoBehaviour
{

    [SerializeField]
    public Rigidbody rb;

    private float _speed, _accelerationLerpInterpolator, _rotationInput;
    [SerializeField]
    public float speedMax = 3, _accelerationFactor, _rotationSpeed = 0.5f;
    private bool _isAccelerating;

    [SerializeField]
    private AnimationCurve _accelerationCurve;

    [SerializeField]
    public string playerController;
    [SerializeField]
    public string playerForward;




    void Update()
    {

        _rotationInput = Input.GetAxis(playerController);


        if (Input.GetButtonDown(playerForward))
        {
            _isAccelerating = true;
        }
        if (Input.GetButtonUp(playerForward))
        {
            _isAccelerating = false;
        }
    }

    private void FixedUpdate()
    {

        if (_isAccelerating)
        {
            _accelerationLerpInterpolator += _accelerationFactor;
        }
        else
        {
            _accelerationLerpInterpolator -= _accelerationFactor * 2;
        }

        _accelerationLerpInterpolator = Mathf.Clamp01(_accelerationLerpInterpolator);

        _speed = _accelerationCurve.Evaluate(_accelerationLerpInterpolator) * speedMax;

        transform.eulerAngles += Vector3.up * _rotationSpeed * Time.deltaTime * _rotationInput;
        rb.MovePosition(transform.position + transform.forward * _speed * Time.fixedDeltaTime);
    }
}