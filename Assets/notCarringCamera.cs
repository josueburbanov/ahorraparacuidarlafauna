﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notCarringCamera : MonoBehaviour
{
    public followPlayerX follow;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        follow.notJumper = true;
    }
}
