Feature: BasicOperation
	Covers basic API Test operations

@smoke
Scenario: GET product by id
	Given user performs GET operation of "Product/GetProductById/{id}"
		| ProductId |
		| 1         |
	Then should receive the product name as "Keyboard"
