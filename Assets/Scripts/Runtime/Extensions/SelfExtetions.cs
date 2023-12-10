using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Runtime.Extensions
{
    public  static class SelfExtetions
    {
        
        public static Vector3 GetRandomTopPosition(GameObject cubeObject)
        {
            // get the dimensions of the cube object
            float x = cubeObject.transform.localScale.x;
            float y = cubeObject.transform.localScale.y;
            float z = cubeObject.transform.localScale.z;

            // calculate the position of the top face of the cube
            Vector3 topPosition = cubeObject.transform.position + new Vector3(0, y / 2f, 0);

            // generate a random position on the top face of the cube
            Vector3 randomTopPosition = new Vector3(
                Random.Range(topPosition.x - x / 2f, topPosition.x + x / 2f),
                topPosition.y,
                Random.Range(topPosition.z - z / 2f, topPosition.z + z / 2f)
            );

            return randomTopPosition;
        }
        
        public static float Map(float value, float inMin, float inMax, float outMin, float outMax)
        {

            float mappedNumber = (((value - inMin) * (outMax - outMin)) / (inMax - inMin)) + outMin;

            return mappedNumber;
        }

    }
}