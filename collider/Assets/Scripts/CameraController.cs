using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Copyright (C) Xenfinity LLC - All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Bilal Itani <bilalitani1@gmail.com>, June 2017
 */

public class CameraController : MonoBehaviour {

    public Transform target;

    public float lerpSpeed = 5;

    public float zOffset = -19;

    #region Monobehaviour API

	void LateUpdate ()
    {
        var currentPosition = transform.position;

        var targetPosition = new Vector3(target.position.x, currentPosition.y, target.position.z + zOffset);

        transform.position = Vector3.Lerp(currentPosition, targetPosition, Time.deltaTime * lerpSpeed);
	}

    #endregion
}
