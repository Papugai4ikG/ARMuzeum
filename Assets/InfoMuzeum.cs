using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InfoMuzeum : MonoBehaviour
{
    [SerializeField]
    public RawImage image;
    [SerializeField]
    public TMP_Text header, desp;

    public void InfoMuzeums(Texture texture, string header, string desp)
    {
        image.texture = texture;
        this.header.text = header;
        this.desp.text = desp.Substring(0, 100)+"....";
    }
}
