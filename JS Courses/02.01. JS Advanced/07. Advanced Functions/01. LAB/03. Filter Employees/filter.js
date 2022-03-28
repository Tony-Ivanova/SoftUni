function employees(input, criteria) {
  let employees = JSON.parse(input);
  let [key, value] = criteria.split('-');

  employees
    .filter(filterEmployees)
    .forEach((employee, i) => console.log(`${i}. ${employee.first_name} ${employee.last_name} - ${employee.email}`));

  function filterEmployees(employee) {
    return employee[key] == value || key == "all";
  }
}

employees(`[{
    "id": "1",
    "first_name": "Ardine",
    "last_name": "Bassam",
    "email": "abassam0@cnn.com",
    "gender": "Female"
  }, {
    "id": "2",
    "first_name": "Kizzee",
    "last_name": "Jost",
    "email": "kjost1@forbes.com",
    "gender": "Female"
  },  
{
    "id": "3",
    "first_name": "Evanne",
    "last_name": "Maldin",
    "email": "emaldin2@hostgator.com",
    "gender": "Male"
  }]`,
  'gender-Female'
)