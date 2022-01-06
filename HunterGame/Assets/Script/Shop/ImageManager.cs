using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageManager : MonoBehaviour
{
    static private ImageManager Instance = null;
    static public ImageManager Getinstace
    {
        get
        {
            if (Instance == null)
                Instance = new ImageManager();

            return Instance;
        }
    }

}
