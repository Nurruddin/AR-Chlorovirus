using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLink : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void URLOpener(){
        Application.OpenURL("https://cdn.jsdelivr.net/gh/Nurruddin/ARApp/ARAppHelp.pdf");
    }
}
