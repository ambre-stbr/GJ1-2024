using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursors : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Rendre le curseur visible
        Cursor.visible = true;

        // Déverrouiller le curseur pour permettre au joueur de l'utiliser dans l'UI
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
