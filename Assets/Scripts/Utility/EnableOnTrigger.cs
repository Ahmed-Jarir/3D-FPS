using System.Collections.Generic;
using UnityEngine;

public class EnableOnTrigger : MonoBehaviour
{
        public List<GameObject> ObjectsToEnable;
    
        private void OnTriggerEnter(Collider trigger)
        {
            if (trigger.tag == "Player")
            {
                foreach (GameObject enable in ObjectsToEnable)
                {
                    enable.SetActive(true);
                }
            }
        }
}