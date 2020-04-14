using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;
using System.IO;

public class PermissionStorage : MonoBehaviour {

  //  [SerializeField] Text text;
	LevelController levelController;

	void Start()
	{
		levelController = GameObject.FindObjectOfType<LevelController> ();
		RequestCameraPermission ();
		RequestWritePermission ();
		RequestReadPermission ();
	}

	public void RequestCameraPermission()
	{
		if (UniAndroidPermission.IsPermitted (AndroidPermission.CAMERA)) {
			return;
		}

		UniAndroidPermission.RequestPermission (AndroidPermission.CAMERA, OnAllowCam, OnDenyCam, OnDenyAndNeverAskAgainCam);
	}

    public void RequestWritePermission()
	{
		if (UniAndroidPermission.IsPermitted (AndroidPermission.WRITE_EXTERNAL_STORAGE)) {
            return;
        }

		UniAndroidPermission.RequestPermission (AndroidPermission.WRITE_EXTERNAL_STORAGE, OnAllowWrite, OnDenyWrite, OnDenyAndNeverAskAgainWrite);
    }

	public void RequestReadPermission()
	{
		if (UniAndroidPermission.IsPermitted (AndroidPermission.READ_EXTERNAL_STORAGE)) {
			return;
		}

		UniAndroidPermission.RequestPermission (AndroidPermission.READ_EXTERNAL_STORAGE, OnAllowCamRead, OnDenyRead, OnDenyAndNeverAskAgainRead);
	}

	private void OnAllowCam()
	{
		RequestWritePermission ();
	}

	private void OnAllowWrite()
	{
		RequestReadPermission ();
		//CreateFolder ();
	}

	private void OnAllowCamRead()
	{
	//	CreateFolder ();
	}

//	void CreateFolder ()
//	{
//		string pathImg = "/storage/emulated/0/Senna360/Image/";
//		if (!Directory.Exists (pathImg))
//			Directory.CreateDirectory (pathImg);
//	}

	private void OnDenyCam()
	{
		levelController.ModelMenuLevelLoad ();
	}

	private void OnDenyWrite()
	{
		levelController.ModelMenuLevelLoad ();
	}

	private void OnDenyRead()
	{
		levelController.ModelMenuLevelLoad ();
	}
		
    private void OnDenyAndNeverAskAgainCam()
    {
		levelController.ModelMenuLevelLoad ();
    }

	private void OnDenyAndNeverAskAgainWrite()
	{
		levelController.ModelMenuLevelLoad ();
	}

	private void OnDenyAndNeverAskAgainRead()
	{
		levelController.ModelMenuLevelLoad ();
	}
}