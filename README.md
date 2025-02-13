## Day 1
Create a class named Vehicle with the following properties:
  - Id (int)
  - Model (string)
  - Brand (string)
  - Price (nullable double)
  - FuelTypes (List<string>)

Create a Static List of Vehicles(Method which returns list of Vehicles) and populate at least 20 Vehicle.

Write LINQ Queries(Using Method & Query syntax) to Solve the Following:
1. Get vehicles costing more than 1,000,000.
2. Retrieve vehicle models along with their fuel types.
3. Retrieve all unique fuel types.
4. Find the vehicle with the highest and lowest price.
5. Group vehicles by brand.
6. Count vehicles available in each brand.
7. Retrieve vehicles with missing price values.
8. Sort vehicles by price, then by brand.
9. Find the average price of vehicles in each brand.
10. Find the brand with the highest number of vehicles.

![day1_1](/img/day1_1.png)
![day1_2](/img/day1_2.png)

## Day 2
Create a Static List of Vehicles(Method which returns list of Vehicles) and populate at least 20 Vehicle.

Write LINQ Queries(Using Method & Query syntax) to Solve the Following:
1. Write a LINQ query to fetch the EmployeeId, Employee Name, SalaryId, and Amount using an inner join.
2. Write a LINQ query to perform a Group Join, listing employees along with their salaries.
3. Write a LINQ query to perform a Cross Join, generating all possible combinations of Employees and Salaries.
4. Write a LINQ query to perform a Left Outer Join, listing all employees along with their salaries (even if they don’t have any salaries recorded).
5. Write a LINQ query to group salaries by EmployeeId, displaying the total salary received by each employee.
6. Use ToLookup to create a dictionary-like structure where EmployeeId is the key and salaries are the values.
7. Modify the GroupBy query to display the EmployeeId, count of salaries received, and the highest salary per employee.
8. Fetch employee names who have received at least one salary above $5000 using a nested LINQ query.
9. Get a list of unique departments where employees work.
10. Get a combined list of months from two different salary collections.
11. Find common months between two different salary collections.
12. Find months that exist in the first salary collection but not in the second.
13. Assume a list of duplicate employee names. Write a LINQ query to get a unique list.
14. Create a LINQ query that retrieves employees from a collection and demonstrate deferred execution and immediate execution
15. Implement an example that simulates lazy vs. eager loading using LINQ queries.

![day2_1](/img/day2_1.png)
![day2_2](/img/day2_2.png)
