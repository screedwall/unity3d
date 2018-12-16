using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOMETHING : MonoBehaviour {

	public void DAMAGE_PART(int PART_ID) {
        gameObject.transform.Find(PART_ID.ToString()).gameObject.SetActive(false);
    }
}
