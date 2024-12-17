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
    //[Test]

    ////Test scene transition
    //public void TestSceneTransition()
    //{
    //    altDriver.LoadScene("LoginScene");
    //    Assert.AreEqual("LoginScene", altDriver.GetCurrentScene());
    //    Assert.Pass();
    //}

    [Test]
    // Test Valid User Login
    public void TestValidUserLogin()
    {
        altDriver.LoadScene("LoginScene");

        var usernameInputField = altDriver.FindObject(By.NAME, "Username_InputField");
        var passwordInputField = altDriver.FindObject(By.NAME, "Password_InputField");
        var login_Btn = altDriver.FindObject(By.NAME, "Login_Button");

        usernameInputField.SetText(null, true);
        usernameInputField.Click();
        usernameInputField.SetText("test", true);
        passwordInputField.SetText(null, true);
        passwordInputField.Click();
        passwordInputField.SetText("12345", true);
        login_Btn.Click();
        altDriver.LoadScene("HomePage");
        altDriver.WaitForCurrentSceneToBe("HomePage",5);

        Assert.AreEqual("HomePage",altDriver.GetCurrentScene());
        Assert.Pass("Test Valid User Login successfull");
    }

    [Test]
    //Test Invalid username, valid password
    public void TestInvaildUsername()
    {
        altDriver.LoadScene("LoginScene");

        var usernameInputField = altDriver.FindObject(By.NAME, "Username_InputField");
        var passwordInputField = altDriver.FindObject(By.NAME, "Password_InputField");
        var login_Btn = altDriver.FindObject(By.NAME, "Login_Button");

        usernameInputField.SetText("hello", true);

        passwordInputField.Click();
        passwordInputField.SetText(null, true);
        passwordInputField.SetText("12345", true);
        login_Btn.Click();
        string popupText = altDriver.FindObject(By.NAME, "PopUp").GetText();

        Assert.AreEqual("Username or password is incorrect", popupText);
        Assert.AreEqual("LoginScene", altDriver.GetCurrentScene());
        Assert.Pass("Test Invalid username successfull");
    }

    [Test]
    //Test valid username, Invalid password
    public void TestInvaildPassword()
    {
        altDriver.LoadScene("LoginScene");

        var usernameInputField = altDriver.FindObject(By.NAME, "Username_InputField");
        var passwordInputField = altDriver.FindObject(By.NAME, "Password_InputField");
        var login_Btn = altDriver.FindObject(By.NAME, "Login_Button");

        usernameInputField.SetText(null, true);
        usernameInputField.Click();
        usernameInputField.SetText("test", true);
        passwordInputField.Click();
        passwordInputField.SetText(null, true);
        passwordInputField.SetText("1212", true);
        login_Btn.Click();
        string popupText = altDriver.FindObject(By.NAME, "PopUp").GetText();

        Assert.AreEqual("Username or password is incorrect", popupText);
        Assert.AreEqual("LoginScene", altDriver.GetCurrentScene());
        Assert.Pass("Test Invalid password successfull");
    }

    [Test]
    //Test null Username and password
    public void TestNullUsernamePassword()
    {
        altDriver.LoadScene("LoginScene");

        var usernameInputField = altDriver.FindObject(By.NAME, "Username_InputField");
        var passwordInputField = altDriver.FindObject(By.NAME, "Password_InputField");
        var login_Btn = altDriver.FindObject(By.NAME, "Login_Button");

        usernameInputField.SetText(null, true);
        passwordInputField.SetText(null, true);
        login_Btn.Click();
        string popupText = altDriver.FindObject(By.NAME, "PopUp").GetText();

        Assert.AreEqual("Please enter your username and password", popupText);
        Assert.AreEqual("LoginScene", altDriver.GetCurrentScene());
        Assert.Pass("Test null User Login successfull");
    }

    [Test]
    //Test null Username
    public void TestNullUsername()
    {
        altDriver.LoadScene("LoginScene");

        var usernameInputField = altDriver.FindObject(By.NAME, "Username_InputField");
        var passwordInputField = altDriver.FindObject(By.NAME, "Password_InputField");
        var login_Btn = altDriver.FindObject(By.NAME, "Login_Button");

        usernameInputField.SetText(null, true);
        passwordInputField.Click();
        passwordInputField.SetText(null, true);
        passwordInputField.SetText("12345", true);
        login_Btn.Click();
        string popupText = altDriver.FindObject(By.NAME, "PopUp").GetText();

        Assert.AreEqual("Please enter your username and password", popupText);
        Assert.AreEqual("LoginScene", altDriver.GetCurrentScene());
        Assert.Pass("Test null User Login successfull");
    }

    [Test]
    //Test null password
    public void TestNullPassword()
    {
        altDriver.LoadScene("LoginScene");

        var usernameInputField = altDriver.FindObject(By.NAME, "Username_InputField");
        var passwordInputField = altDriver.FindObject(By.NAME, "Password_InputField");
        var login_Btn = altDriver.FindObject(By.NAME, "Login_Button");

        usernameInputField.SetText("test", true);
        passwordInputField.Click();
        passwordInputField.SetText(null, true);
        passwordInputField.SetText(null, true);
        login_Btn.Click();
        string popupText = altDriver.FindObject(By.NAME, "PopUp").GetText();

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