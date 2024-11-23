using CrimeReportingSystem.Entity;
using CrimeReportingSystemAPP.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimeReportingSystemAPP.dao
{
    internal interface ICrimeAnalysisService
    {
        List<Incidents> GetAllIncidents();

        List<CaseReport> GetAllCases();

        bool AddIncidents(Incidents incidents,Victims victim,Suspects suspect);

        bool UpdateIncidentStatus(int incidentId, String status);

        List<Incidents> GetIncidentsInDateRange(DateTime startDate, DateTime endDate);

        List<Incidents> SearchIncidents(string incidentType);

        Reports GenerateIncidentReport(int reportId);

        Reports GetDetails(int reportId);

        bool UpdateCaseDetails(Reports updatedReport);

        Incidents GetIncidentById(int incidentId);



    }
    
}
