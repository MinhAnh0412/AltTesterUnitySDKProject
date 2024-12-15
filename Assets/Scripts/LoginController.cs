using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LoginController : MonoBehaviour
{
    [SerializeField] Data dataClass;

    [SerializeField] TMP_InputField Username_InputField;
    [SerializeField] TMP_InputField Password_InputField;
    [SerializeField] TextMeshProUGUI popup_Text;
    [SerializeField] Button Login_Btn;
    [SerializeField] Button HomePage;

    // Start is called before the first frame update
    void Start()
    {
        Login_Btn.onClick.AddListener(() => { CheckUserInfo(); });
        HomePage.onClick.AddListener(() => { SceneManager.LoadScene("HomePage"); });
    }
    private void CheckUserInfo()
    {
        //Check null username and password input field
        if (string.IsNullOrEmpty(Username_InputField.text) || string.IsNullOrEmpty(Password_InputField.text))
        {
            popup_Text.color = Color.red;
            popup_Text.text = "Please enter your username and password";
        }
        // Check valid username and password 
        else if (Username_InputField.text == dataClass.username && Password_InputField.text == dataClass.password)
        {
            popup_Text.color = Color.green;
            StartCoroutine(ExampleCoroutine());
            SceneManager.LoadScene("HomePage");
            Debug.Log("Username or password is correct");
        }
        //Check invalid username and password
        else if (Username_InputField.text != dataClass.username || Password_InputField.text != dataClass.password)
        {
            popup_Text.color = Color.red;
            popup_Text.text = "Username or password is incorrect";
            Debug.Log("Username or password is incorrect");
        }
    }
    IEnumerator ExampleCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}
