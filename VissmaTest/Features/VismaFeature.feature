Feature: VismaFeature

This feature ensures the funtionality of a few pages on the site, as well as the prices getting updated after the price slider gets moved

@Visma
Scenario: TestForVisma
	Given the user goes to Resources Section
	When the user gets to Start Here section
	Then search for Create New Blog
	And click on the 10th result
	Then scroll to the top and open Pricing Section 
	And verify the prices get updated when moving the slider to 20k members

