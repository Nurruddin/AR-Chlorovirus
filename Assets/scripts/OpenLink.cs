using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class OpenLink : MonoBehaviour
{
    public void URLOpener()
    {
        // Open the PDF file with an external viewer
        Application.OpenURL("https://cdn.jsdelivr.net/gh/Nurruddin/ARApp/ARAppHelp.pdf");
    }
}
