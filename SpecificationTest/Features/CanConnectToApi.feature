Feature: CanConnectToApi

	Scenario: Can Connect To Api
		Given the TFL API at https://api.tfl.gov.uk/BikePoint/
		When the API is queried
		Then the API returns a successful response

Scenario: Incorrect Url To Connect To Api
		Given the TFL API at https://api.tfl.gov.uk/BikePointt/
		When the API is queried
		Then I am redirected to the 401 Technical Error page