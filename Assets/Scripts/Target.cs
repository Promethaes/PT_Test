using UnityEngine;

namespace PtTest
{
    public class Target : MonoBehaviour
    {
        public Vector3 Velocity;
        public Vector3 SpawnPos;

        // Update is called once per frame
        void Update()
        {
            transform.position += Velocity * Time.deltaTime;
            if (transform.position.z <= 0)
                transform.position = SpawnPos;
        }
    }
}