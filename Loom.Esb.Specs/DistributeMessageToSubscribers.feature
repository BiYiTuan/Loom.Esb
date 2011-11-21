Feature: Publish message
	To be able to distribute the same message to multiple subscribers
	As a system user
	I want to be able to send a message to the bus that will be delivered to all registered subscribers

Scenario: Publish message on bus
	Given I have a message for publication
	And Two subscribers subscribe to the topic
	When I publish the message on the bus
	Then both subscribers should receive the message
