using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sprint_0_Warm_Up;

namespace UnitTestAirplaneToyPlane
{
    [TestClass]
    public class UnitTest1
    {

        Airplane ap = new Airplane();
        ToyPlane tp = new ToyPlane();
        Helicopter heli = new Helicopter();
        Drone drone = new Drone();

        // ------------------------- Airplane Tests ---------------------------

        [TestMethod]
        public void AirplaneDefaultAbout()
        {
            //Arrange
            string TestAbout;

            //Act
            TestAbout = ap.About();

            //Assert
            Assert.AreEqual(
                $"This {ap} has a Max Altitude of {ap.MaxAltitude} ft.\n" +
                $"It's Current Altitude is {ap.CurrentAltitude} ft.\n" +
                $"{ap.GetEngineStartedString()}", TestAbout);
        }

        [TestMethod]
        public void AirplaneDefaultTakeOff()
        {
            //Arrange
            string TestTakeOffFail;
            string TestTakeOffSuccess;
            bool TestIsFlying;

            //Act
            TestTakeOffFail = ap.TakeOff();
            ap.StartEngine();
            TestTakeOffSuccess = ap.TakeOff();
            TestIsFlying = ap.IsFlying;

            //Assert
            Assert.AreEqual($"{ap.Engine} isn't started yet, so {ap} can't take off.", TestTakeOffFail);
            Assert.AreEqual($"{ap} is flying.", TestTakeOffSuccess);
            Assert.AreEqual(ap.IsFlying, TestIsFlying);
        }

        [TestMethod]
        public void AirplaneDefaultFlyUp()
        {
            //Arrange
            int TestFlyUpAltitude;
            int TestFlyUpTooHighAltitude;
            int TestFlyUpSpecificAltitude;
            ap.StartEngine();
            ap.TakeOff();

            //Act
            ap.FlyUp();
            TestFlyUpAltitude = ap.CurrentAltitude;
            ap.FlyUp(44000); // Shouldn't work
            TestFlyUpTooHighAltitude = ap.CurrentAltitude; // should be equal to previous fly up, no change
            ap.FlyUp(39000);
            TestFlyUpSpecificAltitude = ap.CurrentAltitude; //(39,000 + 1000) + 1000 = MaxAltitude OR 41,000ft;

            //Assert
            Assert.AreEqual(true, ap.IsFlying);
            Assert.AreEqual(1000, TestFlyUpAltitude);
            Assert.AreEqual(TestFlyUpAltitude, TestFlyUpTooHighAltitude);
            Assert.AreEqual(41000, TestFlyUpSpecificAltitude);
        }

        [TestMethod]
        public void AirplaneDefaultFlyDown()
        {
            //Arrange
            int TestFlyDownAltitudeFail;
            int TestLandingAltitude;
            bool TestLandingIsFlying;
            bool TestEngineIsStarted;
            ap.StartEngine();
            ap.TakeOff();
            ap.FlyUp(ap.MaxAltitude-1000); // start Airplane Tests at Max Altitude

            //Act
            ap.FlyDown(50000); // Shouldn't work - Altitude should stay the same
            TestFlyDownAltitudeFail = ap.CurrentAltitude;
            ap.FlyDown(ap.CurrentAltitude); // Should Land - Engine will turn off and IsFlying will be false
            TestLandingAltitude = ap.CurrentAltitude;
            TestLandingIsFlying = ap.IsFlying;
            TestEngineIsStarted = ap.Engine.IsStarted;

            //Assert
            Assert.AreEqual(ap.MaxAltitude, TestFlyDownAltitudeFail);
            Assert.AreEqual(0, TestLandingAltitude);
            Assert.AreEqual(false, TestLandingIsFlying);
            Assert.AreEqual(false, TestEngineIsStarted);
        }

        // ----------------- ToyPlane Tests ------------------

        [TestMethod]
        public void ToyPlaneDefaultAbout()
        {
            //Arrange
            string tpAbout;

            //Act
            tpAbout = tp.About();

            //Assert
            Assert.AreEqual(tpAbout,
                $"This {tp} has a Max Altitude of {tp.MaxAltitude} ft.\n" +
                $"It's Current Altitude is {tp.CurrentAltitude} ft.\n" +
                $"{tp.GetEngineStartedString()}" + tp.GetWindUpString());

        }

        [TestMethod]
        public void ToyPlaneDefaultWindUpFly()
        {
            //Arrange
            bool TestEngineStartFail;
            bool TestEngineStartSuccess;
            string TestWindUp;
            int TestFlyUpAltitude;
            int TestFlyUpSpecificAltitude;
                
            //Act
            tp.StartEngine();
            TestEngineStartFail = tp.Engine.IsStarted; // should be false still
            tp.WindUp();
            TestWindUp = tp.GetWindUpString(); // should be wound up
            tp.StartEngine();
            TestEngineStartSuccess = tp.Engine.IsStarted; //shoud be true
            tp.FlyUp();   // 0ft to 5ft
            TestFlyUpAltitude = tp.CurrentAltitude;
            tp.FlyUp(40); // 5ft to 50ft
            TestFlyUpSpecificAltitude = tp.CurrentAltitude;

            //Assert
            Assert.AreEqual(false, TestEngineStartFail);
            Assert.AreEqual($"{tp} is wound up.", TestWindUp);
            Assert.AreEqual(true, TestEngineStartSuccess);
            Assert.AreEqual(5, TestFlyUpAltitude);
            Assert.AreEqual(50, TestFlyUpSpecificAltitude);

        }

        // ----------------- Helicopter Tests ------------------

        [TestMethod]
        public void HelicopterDefaultAbout()
        {
            //Arrange
            string heliAbout;

            //Act
            heliAbout = heli.About();

            //Assert
            Assert.AreEqual($"This {heli} has a Max Altitude of {heli.MaxAltitude} ft.\n" +
                $"It's Current Altitude is {heli.CurrentAltitude} ft.\n" +
                $"{heli.GetEngineStartedString()}", heliAbout);

        }

        // ----------------- Drone Tests ------------------

        [TestMethod]
        public void DroneDefaultAbout()
        {
            //Arrange
            string droneAbout;

            //Act
            droneAbout = drone.About();

            //Assert
            Assert.AreEqual($"This {drone} has a Max Altitude of {drone.MaxAltitude} ft.\n" +
                $"It's Current Altitude is {drone.CurrentAltitude} ft.\n" +
                $"{drone.GetEngineStartedString()}", droneAbout);

        }

    }
}
