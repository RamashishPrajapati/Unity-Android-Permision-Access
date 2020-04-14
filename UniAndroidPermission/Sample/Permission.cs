using UnityEngine;
using UnityEngine.UI;

public class Permission : MonoBehaviour {

    [SerializeField] Text text;

	void Start()
	{
		RequestPermission ();
	}

    public void RequestPermission()
	{
		if (UniAndroidPermission.IsPermitted (AndroidPermission.CAMERA)) {
           // text.text = "WRITE_EXTERNAL_STORAGE is already permitted!!";
            return;
        }

		UniAndroidPermission.RequestPermission (AndroidPermission.CAMERA, OnAllow, OnDeny, OnDenyAndNeverAskAgain);
    }

    private void OnAllow()
    {
      //  text.text = "WRITE_EXTERNAL_STORAGE is permitted NOW!!";
    }


    private void OnDeny()
    {
       // text.text = "WRITE_EXTERNAL_STORAGE is NOT permitted...";
    }
		
    private void OnDenyAndNeverAskAgain()
    {
      //  text.text = "WRITE_EXTERNAL_STORAGE is NOT permitted and checked never ask again option";
    }
}
