using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XenoWare
{
    public class UpdateColiderForHelper : MonoBehaviour
    {
        [SerializeField]
        float distanceFromCamera = 100;

        Camera _camera;
        // Start is called before the first frame update
        void Start()
        {
            _camera = Camera.main;
            ResizeHelperBox();
        }

        private void ResizeHelperBox()
        {
            Vector3[] corners = new Vector3[4];

            corners[0] = _camera.ViewportToWorldPoint(new Vector3(0, 1, distanceFromCamera));
            corners[1] = _camera.ViewportToWorldPoint(new Vector3(1, 1, distanceFromCamera));
            corners[2] = _camera.ViewportToWorldPoint(new Vector3(0, 0, distanceFromCamera));

            var xDis = Vector3.Distance(corners[0], corners[1]);
            var yDis = Vector3.Distance(corners[0], corners[2]);

            gameObject.transform.localScale = new Vector3(xDis + distanceFromCamera, yDis + distanceFromCamera, 1f);
        }
    }
}
