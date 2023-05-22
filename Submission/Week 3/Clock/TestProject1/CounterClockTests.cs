using NUnit.Framework;

namespace CounterClock.Tests
{
    [TestFixture]
    public class Tests
    {

        [Test]
        public void Initializing()
        {
            Clock clock_test = new Clock();
            Assert.That(clock_test.ReadTime, Is.EqualTo("00:00:00"));
        }

        [Test]
        public void IncrementingOneTime()
        {
            Clock clock_test = new Clock();
            clock_test.Tick();
            Assert.That(clock_test.ReadTime, Is.EqualTo("00:00:01"));
        }

        [Test]
        public void IncrementingMultipleTimes()
        {
            Clock clock_test = new Clock();
            for (int i=0; i < 1008; i++)
            {
                clock_test.Tick();
            }
            Assert.That(clock_test.ReadTime, Is.EqualTo("00:16:48"));
        }

        [Test]
        public void Reset()
        {
            Clock clock_test = new Clock();
            for (int i = 0; i < 1008; i++)
            {
                clock_test.Tick();
            }
            clock_test.ResetClock();    
            Assert.That(clock_test.ReadTime, Is.EqualTo("00:00:00"));
        }
    }
}