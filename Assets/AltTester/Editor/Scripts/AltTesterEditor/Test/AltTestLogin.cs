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
    public void Test()
    {
        //Here you can write the test
        // Load "LoginScene"
        altDriver.LoadScene("LoginScene");

        // Find the button by its name and click it
        var homePageButton = altDriver.FindObject(By.NAME, "HomePage_Btn");
        Assert.NotNull(homePageButton, "HomePage_Btn was not found!");
        homePageButton.Tap();

        // Wait for the "HomePage" scene to load
        altDriver.WaitForCurrentSceneToBe("HomePage");

        // Verify that the scene successfully transitioned
        Assert.AreEqual("HomePage", altDriver.GetCurrentScene(), "Scene did not transition to HomePage!");
        Assert.Pass();
    }

    //At the end of the test closes the connection with the socket
    [OneTimeTearDown]
    public void TearDown()
    {
        altDriver.Stop();
    }
}