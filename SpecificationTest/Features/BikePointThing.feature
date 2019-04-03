Feature: BikePointThing

	Scenario: Returns a list of bike points
		Given the TFL API at https://api.tfl.gov.uk/BikePoint/
		When the API is queried
		#Then the API returns 784 records
