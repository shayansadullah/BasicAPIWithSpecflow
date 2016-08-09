Feature: Carbon Monitoring
	In order to filter out Carbon reading in the atmosphere
	As an environmental science engineer
	I want to be able to filter out the carbon reading for a given location

Scenario Outline: Confirm I can filter out the Carbon reading
	When I query the Carbon Monitoring page for <location>, <limit>, <colour>
	Then the results contains <Expected Entry>

	Examples:
	| location | limit | colour | Expected Entry           |
	| 5332921  | 1     | Red    | LA PALOMA GENERATING LLC |

	