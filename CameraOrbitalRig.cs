using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XenoWare
{
    [RequireComponent(typeof(Camera))]
    public class CameraOrbitalRig : MonoBehaviour
    {
        [SerializeField] GameObject target;
        [SerializeField] bool invertZoom = true;

        [SerializeField] float minZoom = 1f;
        [SerializeField] float maxZoom = 50.0f;
        [SerializeField] float scrollSpeed = 5f;

        [SerializeField] InputHandler inputHandler;

        [SerializeField] float MouseXSensitivity = 4f;
        [SerializeField] float MouseYSensitivity = 4f;

        [SerializeField] float MouseAxisAcceleration = 1.05f;

        Vector3 _LocalRotation;
        Transform _Camera;
        Transform _CameraPivot;
        Transform _CameraRig;
        float zoom = 10f;

        [SerializeField] bool DoOrbitDampening = false;
        [SerializeField] float OrbitDampening = 10f;
        [SerializeField] float ScrollDampening = 6f;
        public bool invertX = false;
        public bool invertY = true;

        // Start is called before the first frame update
        void Start()
        {
            if (inputHandler == null)
            {
                inputHandler = GetComponent<InputHandler>();
            }
            _Camera = transform;
            _CameraPivot = transform.parent;
            _CameraRig = transform.parent.parent;
            zoom = Vector3.Distance(target.transform.position, _Camera.position);
        }

        // Update is called once per frame
        void Update()
        {
            inputHandler.TickInput(Time.deltaTime);
            _CameraRig.position = target.transform.position;
        }

        private void LateUpdate()
        {
            Vector2 mouseAxis = inputHandler.CameraMovementVector;
            float mouseScroll = inputHandler.getMouseScroll();

            //Rotation of the Camera based on Mouse Coordinates
            if (mouseAxis.x != 0 || mouseAxis.y != 0)
            {
                _LocalRotation.x += (invertX ? -GetXAxisWithSensitivity(mouseAxis) : GetXAxisWithSensitivity(mouseAxis)) * MouseAxisAcceleration;
                _LocalRotation.y += (invertY ? -GetYAxisWithSensitivity(mouseAxis) : GetYAxisWithSensitivity(mouseAxis)) * MouseAxisAcceleration;
                _LocalRotation.y = Mathf.Clamp(_LocalRotation.y, -90, 90);
                _LocalRotation.x = Mathf.Clamp(_LocalRotation.x, -720, 720);
            }

            if (mouseScroll > 0)
            {
                zoom += Time.deltaTime * (invertZoom ? -mouseScroll : mouseScroll) * scrollSpeed;
                zoom = Mathf.Clamp(zoom, minZoom, maxZoom);
            }

            if (mouseScroll < 0)
            {
                zoom += Time.deltaTime * (invertZoom ? -mouseScroll : mouseScroll) * scrollSpeed;
                zoom = Mathf.Clamp(zoom, minZoom, maxZoom);
            }

            //Actual Camera Rig Transformations
            Quaternion QT = Quaternion.Euler(_LocalRotation.y, _LocalRotation.x, 0);
            if (DoOrbitDampening)
            {
                _CameraPivot.rotation = Quaternion.Lerp(_CameraPivot.rotation, QT, Time.deltaTime * OrbitDampening);
            }
            else
            {
                _CameraPivot.rotation = QT;
            }

            if (_Camera.localPosition.z != zoom * -1f)
            {
                _Camera.localPosition = new Vector3(0f, 0f, Mathf.Lerp(_Camera.localPosition.z, zoom * -1f, Time.deltaTime * ScrollDampening));
            }
        }

        private float GetXAxisWithSensitivity(Vector2 mouseAxis)
        {
            return mouseAxis.x * MouseXSensitivity * Time.fixedDeltaTime;
        }

        private float GetYAxisWithSensitivity(Vector2 mouseAxis)
        {
            return mouseAxis.y * MouseYSensitivity * Time.fixedDeltaTime;
        }
    }
}