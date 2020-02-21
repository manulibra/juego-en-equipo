using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Boundaries
{
    public struct CameraWorldBounds
    {
        public float minX;
        public float maxX;
        public float minY;
        public float maxY;

        public CameraWorldBounds(float minX, float maxX, float minY, float maxY)
        {
            this.minX = minX;
            this.maxX = maxX;
            this.minY = minY;
            this.maxY = maxY;
        }
    }

    public static CameraWorldBounds GetCameraWorldBounds()
    {
        Vector3 downLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        Vector3 topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane));

        return new CameraWorldBounds(downLeft.x, topRight.x, downLeft.y, topRight.y);
    }
}
