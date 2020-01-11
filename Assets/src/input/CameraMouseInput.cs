using UnityEngine;

namespace src.input
{
    public class CameraMouseInput : MonoBehaviour
    {
        [SerializeField] private Transform _cameraPivot;
        [SerializeField] private Transform _thisCamera;

        [SerializeField] private float cameraSpeed = 8;
        [SerializeField] private float zoomSpeed = 0.5f;
        [SerializeField] private float minZoom = 4f;
        [SerializeField] private float maxZoom = 15f;
        [SerializeField] private float smoothSpeed = 0.125f;


       private float rotationX;
       private float rotationY;
       private float zoom;

        void Start()
        {
            rotationX = _cameraPivot.rotation.eulerAngles.x;
            rotationY = _cameraPivot.rotation.eulerAngles.y;
        }
        void LateUpdate()
        {
            if (Input.GetMouseButton(1))
            {
                Rotate();
            }

            if (Input.GetAxis("Mouse ScrollWheel") != 0f)
            {
                Zoom();
            }
        }

        private void Rotate()
        {
            rotationX += Input.GetAxis("Mouse X") * cameraSpeed;
            rotationY += Input.GetAxis("Mouse Y") * cameraSpeed;
            rotationY = Mathf.Clamp(rotationY, -70, -26);

            _cameraPivot.rotation = Quaternion.AngleAxis(rotationX, Vector3.up);
            _cameraPivot.rotation *= Quaternion.AngleAxis(rotationY, Vector3.left);
        }

        private void Zoom()
        {
            zoom += -(Input.GetAxis("Mouse ScrollWheel") * zoom * zoomSpeed);
            zoom = Mathf.Clamp(zoom, minZoom, maxZoom);
            _thisCamera.localPosition = new Vector3(0, 0, -zoom);
        }
    }
}