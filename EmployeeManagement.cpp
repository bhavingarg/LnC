using namespace std;
class Employee
{
private:
    int id;
    string name;
    string department;
    bool working;

public:
    void terminate()
    {
        working = false;
    }

    bool isWorking() const
    {
        return working;
    }
};

class EmployeeRepository
{
public:
    void save(const Employee &employee)
    {
    }
};

class EmployeeReportService
{
public:
    void printXmlReport(const Employee &employee)
    {
    }

    void printCsvReport(const Employee &employee)
    {
    }
};
