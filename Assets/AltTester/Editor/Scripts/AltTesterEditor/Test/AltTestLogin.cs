using NUnit.Framework;
using AltTester.AltTesterUnitySDK.Driver;

public class AltTestLogin
{   
    public AltDriver altDriver;

    //Before any test it connects with the socket
    [OneTimeSetUp]
    public void SetUp()
    {
        altDriver =new AltDriver(port: 13000);
    }
    [Test]

    // Test Valid User Login
    public void TestValidUserLogin()
    {
        altDriver.LoadScene("LoginScene");

        var usernameInputField = altDriver.FindObject(By.NAME, "Username_InputField");
        var passwordInputField = altDriver.FindObject(By.NAME, "Password_InputField");
        var login_Btn = altDriver.FindObject(By.NAME, "Login_Button");

        usernameInputField.SetText("test", true);
        usernameInputField.SetText("12345", true);
        login_Btn.Click();
        altDriver.WaitForCurrentSceneToBe("HomePage");

        Assert.AreEqual("HomePage",altDriver.GetCurrentScene());
        Assert.Pass("Test Valid User Login successfull");
    }

    //Test Invalid username, valid password
    public void TestInvaildUsername()
    {
        altDriver.LoadScene("LoginScene");

        var usernameInputField = altDriver.FindObject(By.NAME, "Username_InputField");
        var passwordInputField = altDriver.FindObject(By.NAME, "Password_InputField");
        var login_Btn = altDriver.FindObject(By.NAME, "Login_Button");

        usernameInputField.SetText("hello", true);
        usernameInputField.SetText("12345", true);
        login_Btn.Click();
        string popupText = altDriver.FindObject(By.NAME, "PopUp").GetText();
        altDriver.UnloadScene("HomePage");

        Assert.AreEqual("Username or password is incorrect", popupText);
        Assert.AreEqual("LoginScene", altDriver.GetCurrentScene());
        Assert.Pass("Test Invalid username successfull");
    }

    //Test valid username, Invalid password
    public void TestInvaildPassword()
    {
        altDriver.LoadScene("LoginScene");

        var usernameInputField = altDriver.FindObject(By.NAME, "Username_InputField");
        var passwordInputField = altDriver.FindObject(By.NAME, "Password_InputField");
        var login_Btn = altDriver.FindObject(By.NAME, "Login_Button");

        usernameInputField.SetText("test", true);
        usernameInputField.SetText("1212", true);
        login_Btn.Click();
        string popupText = altDriver.FindObject(By.NAME, "PopUp").GetText();
        altDriver.UnloadScene("HomePage");

        Assert.AreEqual("Username or password is incorrect", popupText);
        Assert.AreEqual("LoginScene", altDriver.GetCurrentScene());
        Assert.Pass("Test Invalid password successfull");
    }

    //Test null Username and password
    public void TestNullUsernamePassword()
    {
        altDriver.LoadScene("LoginScene");

        var usernameInputField = altDriver.FindObject(By.NAME, "Username_InputField");
        var passwordInputField = altDriver.FindObject(By.NAME, "Password_InputField");
        var login_Btn = altDriver.FindObject(By.NAME, "Login_Button");

        usernameInputField.SetText("", true);
        usernameInputField.SetText("", true);
        login_Btn.Click();
        string popupText = altDriver.FindObject(By.NAME, "PopUp").GetText();
        altDriver.UnloadScene("HomePage");

        Assert.AreEqual("Please enter your username and password", popupText);
        Assert.AreEqual("LoginScene", altDriver.GetCurrentScene());
        Assert.Pass("Test null User Login successfull");
    }

    //Test null Username
    public void TestNullUsername()
    {
        altDriver.LoadScene("LoginScene");

        var usernameInputField = altDriver.FindObject(By.NAME, "Username_InputField");
        var passwordInputField = altDriver.FindObject(By.NAME, "Password_InputField");
        var login_Btn = altDriver.FindObject(By.NAME, "Login_Button");

        usernameInputField.SetText("", true);
        usernameInputField.SetText("12345", true);
        login_Btn.Click();
        string popupText = altDriver.FindObject(By.NAME, "PopUp").GetText();
        altDriver.UnloadScene("HomePage");

        Assert.AreEqual("Please enter your username and password", popupText);
        Assert.AreEqual("LoginScene", altDriver.GetCurrentScene());
        Assert.Pass("Test null User Login successfull");
    }

    //Test null password
    public void TestNullPassword()
    {
        altDriver.LoadScene("LoginScene");

        var usernameInputField = altDriver.FindObject(By.NAME, "Username_InputField");
        var passwordInputField = altDriver.FindObject(By.NAME, "Password_InputField");
        var login_Btn = altDriver.FindObject(By.NAME, "Login_Button");

        usernameInputField.SetText("test", true);
        usernameInputField.SetText("", true);
        login_Btn.Click();
        string popupText = altDriver.FindObject(By.NAME, "PopUp").GetText();
        altDriver.UnloadScene("HomePage");

        Assert.AreEqual("Please enter your username and password", popupText);
        Assert.AreEqual("LoginScene", altDriver.GetCurrentScene());
        Assert.Pass("Test null User Login successfull");
    }

    //At the end of the test closes the connection with the socket
    [OneTimeTearDown]
    public void TearDown()
    {
        altDriver.Stop();
    }
}