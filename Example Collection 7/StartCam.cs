using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartCam : MonoBehaviour
{
	public WebCamTexture webcamTexture;
//	public Binarizer data;
//	public LuminanceSource source;
//	public Bitmap bMap;
//	public Color32[] pixels;
//	public sbyte[] byteThing;

	public RawImage camTexture;

//	int width;
//	int height;
//
//	int x, y, z;

	public void Start ()
	{
		webcamTexture = new WebCamTexture();
		webcamTexture.Play();
//		pixels = new Color32[webcamTexture.width * webcamTexture.height];
//		width = webcamTexture.width;
//		height = webcamTexture.height;
	}

	public void OnDestroy()
	{
		webcamTexture.Stop();
	}

	public void Update ()
	{
		camTexture.texture = webcamTexture;
	}

//	public void DecodeQR()
//	{
//		webcamTexture.Pause();
//		pixels = webcamTexture.GetPixels32();
//
//		//LuminanceSource source = new RGBLuminanceSource(pixels);
//		while(true){
//			try{
//				byteThing = new sbyte[width * height];
//				z = 0;
//				for(y = height - 1; y >= 0; y--) {
//					for(x = 0; x < width; x++) {
//						byteThing[z++] = (sbyte)(((int)pixels[y * width + x].r)<<16 | ((int)pixels[y * width + x].g)<<8 | ((int)pixels[y * width + x].b));
//					}
//				}
//				bMap = new Bitmap(byteThing, width, height);
//			}
//			catch
//			{
//				continue;
//			}
//		}
//	}
}