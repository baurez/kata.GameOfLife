Feature: GameOfLife
![Calculator](https://specflow.org/wp-content/uploads/2020/09/calculator.png)
Simple calculator for adding **two** numbers

Link to a feature: [Calculator](GolSpecFlow/Features/Calculator.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

@mytag
Scenario: Create GameOfLife Matrice
	Given the first number is 4
	And the second number is 5
	When the two numbers are transmitted
	Then the result should be a GameOfLife Matrice of 4 rows and 5 columns
