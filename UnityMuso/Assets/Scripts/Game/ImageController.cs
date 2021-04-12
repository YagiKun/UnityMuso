using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*立ち絵をコントロールするスクリプト*/
public class ImageController : MonoBehaviour
{
    public enum FaceState
    {
        nomal,
        eyeClose,
        angry,
        wow,
        yey,
        damage
    }
    
    public static FaceState UnityChanFaceState = FaceState.nomal;
    public static Image UnityChanImage;
    [SerializeField] Sprite[] tempSprite = new Sprite[6];
    public static Sprite[] sprite = new Sprite[6];

    // Start is called before the first frame update
    void Start()
    {
        UnityChanImage = GameObject.Find("HP_Face").GetComponent<Image>();
        for (int i=0; i < 6; i++){
            sprite[i] = tempSprite[i];
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void PlayNomal()
    {
        UnityChanFaceState = FaceState.nomal;
        UnityChanImage.sprite = sprite[0];
    }
    public static void PlayEyeClose()
    {
        UnityChanFaceState = FaceState.eyeClose;
        UnityChanImage.sprite = sprite[1];
    }
    public static void PlayAngry()
    {
        UnityChanFaceState = FaceState.angry;
        UnityChanImage.sprite = sprite[2];
    }
    public static void PlayWow()
    {
        UnityChanFaceState = FaceState.wow;
        UnityChanImage.sprite = sprite[3];
    }
    public static void PlayYey()
    {
        UnityChanFaceState = FaceState.yey;
        UnityChanImage.sprite = sprite[4];
    }
    public static void PlayDamage()
    {
        UnityChanFaceState = FaceState.damage;
        UnityChanImage.sprite = sprite[5];
    }
}
