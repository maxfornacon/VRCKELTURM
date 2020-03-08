using UnityEngine;
using UnityEngine.EventSystems;

public class MagicWand : BaseInput
{
    private Rigidbody _pullable;
    private Rigidbody _lastCollidingObject;

    private OVRInput.Button leftTrigger = OVRInput.Button.PrimaryIndexTrigger;
    private OVRInput.Button rightTrigger = OVRInput.Button.SecondaryIndexTrigger;

    private float _distance;
    private bool _colliding;
    
    public override bool GetMouseButton(int button)
    {
        return OVRInput.Get(leftTrigger,  OVRInput.Controller.Touch);
    }

    public override bool GetMouseButtonDown(int button)
    {
        return OVRInput.GetDown(leftTrigger,  OVRInput.Controller.Touch);
    }

    public override bool GetMouseButtonUp(int button)
    {
        return OVRInput.GetUp(leftTrigger, OVRInput.Controller.Touch);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Blocks"))
        {
            _colliding = true;
            _lastCollidingObject = other.gameObject.GetComponent<Rigidbody>();
            Debug.Log("Collision Enter");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (_colliding && (OVRInput.GetDown(leftTrigger,  OVRInput.Controller.LTouch) || OVRInput.GetDown(rightTrigger, OVRInput.Controller.RTouch)))
        {
            _pullable = _lastCollidingObject;
            Debug.Log("Button Down");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _colliding = false;
        Debug.Log("Collision Exit");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_pullable && (OVRInput.Get(leftTrigger,  OVRInput.Controller.LTouch) || OVRInput.Get(rightTrigger, OVRInput.Controller.RTouch)))
        {
            var position = this.transform.position;
            _distance = Vector3.Distance(_pullable.transform.position, position);
            var direction = position - _pullable.position;
            Debug.Log(_distance);

            _pullable.AddForce(direction * (_distance * 1000 * Time.deltaTime), ForceMode.Force);
        }
    }

    private void Update()
    {
        if (OVRInput.Get(leftTrigger,  OVRInput.Controller.LTouch) || OVRInput.Get(rightTrigger, OVRInput.Controller.RTouch))
        {
            Debug.Log("Space UP");
            _pullable = null;
        }
    }
}
