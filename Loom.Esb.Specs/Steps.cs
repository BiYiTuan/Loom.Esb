using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Loom.Esb.Specs
{
    [Binding]
    public class StepDefinitions
    {
        [Given(@"I have a message for publication")]
        public void GivenIHaveAMessageForPublication()
        {
            
        }

        [Given(@"Two subscribers subscribe to the topic")]
        public void GivenTwoSubscribersSubscribeToTheTopic()
        {
        }

        [Then(@"both subscribers should receive the message")]
        public void ThenBothSubscribersShouldReceiveTheMessage()
        {
        }

        [When(@"I publish the message on the bus")]
        public void WhenIPublishTheMessageOnTheBus()
        {
        }
    }
}
