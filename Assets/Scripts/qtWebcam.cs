using UnityEngine;
using System.Collections;
using System.IO;

public class qtWebcam : MonoBehaviour {

    WebCamTexture webCameraTexture;
	void Start () {
        webCameraTexture = new WebCamTexture();
        renderer.material.mainTexture = webCameraTexture;
        webCameraTexture.Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void TakePhoto()
    {
        //Khoi tao 1 Texture voi kich thuoc cua camera
        Texture2D photo = new Texture2D(webCameraTexture.width, webCameraTexture.height);
        //Lay cac diem anh cua camera gan vao Texture photo
        photo.SetPixels(webCameraTexture.GetPixels());
        //Thuc hien viec tren
        photo.Apply();

        //Chuyen doi thanh dinh dang phu hop
        byte[] bytes = photo.EncodeToJPG();

        //Ghi file
        File.WriteAllBytes(Application.streamingAssetsPath+"photo.jpg",bytes);
    }
}
