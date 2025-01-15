using UnityEngine;

public class menusound : Sounds
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlaySound(sounds[0], loop:true, volume:0.3f);
    }
}
