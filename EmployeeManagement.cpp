Class Employee
{
int id;
string name;
string department;
bool: working

public:
saveEmployeeTODatabase()
printEmployeeDetailReportXML()
printEmployeeDetailReportCSV()
terminateEmployee()
bool
isWorking()
}; 



// This class violates SRP because it mixes multiple responsibilities such as employee data management, persistence, reporting (XML/CSV), and employment lifecycle handling, so changes in any one method would force modifications to this single class.
