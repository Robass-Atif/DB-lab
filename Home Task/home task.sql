SELECT CONCAT(last_name, ', ', job_id) AS Employee_Title, job_id AS Title FROM employees;

SELECT last_name, salary FROM employees WHERE salary > 12000;

SELECT last_name, salary FROM employees WHERE salary NOT BETWEEN 5000 AND 12000;

SELECT last_name, hire_date FROM employees WHERE YEAR(hire_date) = 1994;

SELECT last_name FROM employees WHERE SUBSTRING(last_name, 3, 1) = 'a';

SELECT last_name FROM employees WHERE last_name LIKE '%a%' AND last_name LIKE '%e%';

SELECT employee_id, last_name, salary, ROUND(salary * 1.155,4) AS increased_salary FROM employees;
SELECT last_name FROM employees WHERE SUBSTRING(last_name, 3, 1) = 'a';
SELECT last_name FROM employees WHERE SUBSTRING(last_name, 3, 1) = 'a';

SELECT CONCAT(UPPER(SUBSTRING(last_name, 1, 1)), LOWER(SUBSTRING(last_name, 2,2))) AS "Last Name", LEN(last_name) AS "Name Length" FROM employees WHERE last_name LIKE 'J%' OR last_name LIKE 'A%' OR last_name LIKE 'M%' ORDER BY last_name;

SELECT last_name, CEILING(DATEDIFF(MONTH, hire_date, GETDATE()) / 1.0) AS MONTHS_WORKED FROM employees ORDER BY MONTHS_WORKED;

SELECT last_name, CONCAT('earns $', salary, ' monthly but wants $', salary * 3) AS "Dream Salaries" FROM employees;

SELECT last_name, FORMAT(salary, 'C', 'en-US') AS SALARY FROM employees;

SELECT last_name, FORMAT(hire_date, 'dddd, the d"th" of MMMM, yyyy') AS hire_date_formatted, FORMAT(DATEADD(DAY, (CASE WHEN DATEPART(WEEKDAY, hire_date) = 1 THEN 1 ELSE 8 - DATEPART(WEEKDAY, hire_date) END) + 6*4, hire_date), 'dddd, the d"th" of MMMM, yyyy') AS REVIEW FROM employees;

SELECT MAX(salary) AS Maximum, MIN(salary) AS Minimum, SUM(salary) AS Sum, AVG(salary) AS Average FROM employees;

SELECT job_id, MAX(salary) AS Maximum, MIN(salary) AS Minimum, SUM(salary) AS Sum, AVG(salary) AS Average FROM employees GROUP BY job_id;

SELECT job_id, COUNT(*) AS PeopleCount FROM employees GROUP BY job_id;

SELECT COUNT(*) AS TotalEmployees, SUM(CASE WHEN YEAR(hire_date) = 1995 THEN 1 ELSE 0 END) AS Hired1995, SUM(CASE WHEN YEAR(hire_date) = 1996 THEN 1 ELSE 0 END) AS Hired1996, SUM(CASE WHEN YEAR(hire_date) = 1997 THEN 1 ELSE 0 END) AS Hired1997, SUM(CASE WHEN YEAR(hire_date) = 1998 THEN 1 ELSE 0 END) AS Hired1998 FROM employees;

SELECT manager_id, MIN(salary) AS LowestSalary FROM employees WHERE manager_id IS NOT NULL GROUP BY manager_id HAVING MIN(salary) > 6000 ORDER BY LowestSalary DESC;

SELECT l.location_id, l.street_address, l.city, l.state_province, c.country_name FROM locations l JOIN countries c ON l.country_id = c.country_id;

SELECT e.last_name, e.department_id, d.department_name FROM employees e JOIN departments d ON e.department_id = d.department_id;

SELECT e.last_name, e.job_id, e.department_id, d.department_name FROM employees e JOIN departments d ON e.department_id = d.department_id WHERE e.department_id IN (SELECT e.department_id FROM locations WHERE city = 'Toronto');

SELECT e.last_name AS employee_last_name, e.employee_id AS employee_number, m.last_name AS manager_last_name, e.manager_id AS manager_number FROM employees e LEFT JOIN employees m ON e.manager_id = m.employee_id;

SELECT e.last_name AS employee_last_name, e.employee_id AS employee_number, m.last_name AS manager_last_name, e.manager_id AS manager_number FROM employees e LEFT JOIN employees m ON e.manager_id = m.employee_id WHERE e.last_name = 'King';

SELECT job_id, MIN(salary) AS min_salary, MAX(salary) AS max_salary FROM employees GROUP BY job_id;

SELECT last_name, hire_date, DATEADD(DAY, ((8 - DATEPART(WEEKDAY, hire_date)) % 7 + 1) + 6*4, hire_date) AS REVIEW FROM employees;
SELECT last_name, hire_date, DATENAME(WEEKDAY, hire_date) AS DAY FROM employees ORDER BY CASE WHEN DATEPART(WEEKDAY, hire_date) = 1 THEN 8 ELSE DATEPART(WEEKDAY, hire_date) END;

SELECT LEFT(last_name, 8) AS EMPLOYEES, REPLICATE('*', salary / 1000) AS SALARIES FROM employees ORDER BY salary DESC;
SELECT last_name, hire_date, DATENAME(WEEKDAY, hire_date) AS DAY FROM employees ORDER BY CASE WHEN DATEPART(WEEKDAY, hire_date) = 1 THEN 8 ELSE DATEPART(WEEKDAY, hire_date) END;
