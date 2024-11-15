using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class OpenLink : MonoBehaviour
{
    public void URLOpener()
    {
        string fileName = "ARAppHelp.pdf";
        string filePath = Path.Combine(Application.persistentDataPath, fileName);

        // Check if the file has already been copied
        if (File.Exists(filePath))
        {
            // Open the existing file
            Application.OpenURL(filePath);
        }
        else
        {
            // Start the coroutine to copy and open the PDF
            StartCoroutine(CopyAndOpenPDF(fileName, filePath));
        }
    }

    private IEnumerator CopyAndOpenPDF(string sourceFileName, string destinationPath)
    {
        // Get the path to the PDF in the StreamingAssets folder
        string sourcePath = Path.Combine(Application.streamingAssetsPath, sourceFileName);

        // For Android, check if the path is a URL (jar:file://)
        if (sourcePath.Contains("://"))
        {
            using (UnityWebRequest request = UnityWebRequest.Get(sourcePath))
            {
                yield return request.SendWebRequest();

                if (request.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogError("Failed to load PDF: " + request.error);
                }
                else
                {
                    // Write the file to persistentDataPath so it's accessible
                    File.WriteAllBytes(destinationPath, request.downloadHandler.data);
                }
            }
        }
        else
        {
            // For platforms where we can directly copy from StreamingAssets
            File.Copy(sourcePath, destinationPath);
        }

        // Open the PDF file with an external viewer
        Application.OpenURL(destinationPath);
    }
}
