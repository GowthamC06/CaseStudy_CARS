using CrimeReportingSystemAPP.Entity;
using CrimeReportingSystem.Entity;
using CrimeReportingSystemAPP.util;
using CrimeReportingSystemAPP.exception;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimeReportingSystemAPP.dao
{
    internal class CrimeAnalysisService : ICrimeAnalysisService
    {

        SqlCommand cmd = null;
        string connectionString;

        //create a constructor
        public CrimeAnalysisService()
        {
            connectionString = DbConnUtil.GetConnectionString();
            cmd = new SqlCommand();
        }
        public List<Incidents> GetAllIncidents()
        {
            //Create a list to hold dataFrom Database
            List<Incidents> incident = new List<Incidents>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                cmd.CommandText = "select * from Incidents";
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Incidents incidents = new Incidents();
                    incidents.IncidentID = (int)reader["IncidentID"];
                    incidents.IncidentType = (string)reader["IncidentType"];
                    incidents.IncidentDate = (DateTime)reader["IncidentDate"];
                    incidents.Location = (string)reader["Location"];
                    incidents.Description = (string)reader["Description"];
                    incidents.Status = (string)reader["Status"];
                    incidents.VictimID = (int)reader["VictimID"];
                    incidents.SuspectID = (int)reader["SuspectID"];
                    incidents.AgencyID = (int)reader["AgencyID"];
                    incident.Add(incidents);
                }
            }
            return incident;
        }
     

        public bool AddIncidents(Incidents incidents, Victims victim, Suspects suspect)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand())
            {
                try
                {
                    sqlConnection.Open();   
                    cmd.CommandText = @"
                INSERT INTO Victims (FirstName, LastName, DateOfBirth, Gender, ContactInformation) 
                VALUES (@FirstName, @LastName, @DateOfBirth, @Gender, @ContactInformation);
                SELECT SCOPE_IDENTITY();";
                    cmd.Connection = sqlConnection; 
                    cmd.Parameters.Clear(); 
                    cmd.Parameters.AddWithValue("@FirstName", victim.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", victim.LastName);
                    cmd.Parameters.AddWithValue("@DateOfBirth", victim.DateOfBirth);
                    cmd.Parameters.AddWithValue("@Gender", victim.Gender);
                    cmd.Parameters.AddWithValue("@ContactInformation", victim.Contactinformation);

                    int newVictimID = Convert.ToInt32(cmd.ExecuteScalar());

                    
                    cmd.CommandText = @"
                INSERT INTO Suspects (FirstName, LastName, DateOfBirth, Gender, ContactInformation) 
                VALUES (@FirstName, @LastName, @DateOfBirth, @Gender, @ContactInformation);
                SELECT SCOPE_IDENTITY();";
                    cmd.Parameters.Clear(); 
                    cmd.Parameters.AddWithValue("@FirstName", suspect.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", suspect.LastName);
                    cmd.Parameters.AddWithValue("@DateOfBirth", suspect.DateOfBirth);
                    cmd.Parameters.AddWithValue("@Gender", suspect.Gender);
                    cmd.Parameters.AddWithValue("@ContactInformation", suspect.ContactInformation);

                    
                    int newSuspectID = Convert.ToInt32(cmd.ExecuteScalar());

                    
                    cmd.CommandText = @"
                INSERT INTO Incidents (IncidentType, Location, Description, Status, VictimID, SuspectID, AgencyID) 
                VALUES (@IncidentType, @Location, @Description, @Status, @VictimID, @SuspectID, @AgencyID)";
                    cmd.Parameters.Clear(); 
                    cmd.Parameters.AddWithValue("@IncidentType", incidents.IncidentType);
                    cmd.Parameters.AddWithValue("@Location", incidents.Location);
                    cmd.Parameters.AddWithValue("@Description", incidents.Description);
                    cmd.Parameters.AddWithValue("@Status", incidents.Status);
                    cmd.Parameters.AddWithValue("@VictimID", newVictimID);
                    cmd.Parameters.AddWithValue("@SuspectID", newSuspectID);
                    cmd.Parameters.AddWithValue("@AgencyID", incidents.AgencyID);

                    // Execute the query
                    int result = cmd.ExecuteNonQuery();

                    // Return true if the incident was successfully added
                    return result > 0;
                }
                catch (Exception ex)
                {
                    // Log the error and return false
                    Console.WriteLine("Error adding incident: " + ex.Message);
                    return false;
                }
            }
        }



        public bool UpdateIncidentStatus(int incidentId, string status)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "UPDATE Incidents SET Status = @Status WHERE IncidentID = @IncidentID";
                cmd.Parameters.AddWithValue("@IncidentID", incidentId);
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Connection = sqlConnection;
                try
                {
                    sqlConnection.Open();
                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error upadating incident Status: " + ex.Message);
                    return false;

                }

            }
        }
        public List<Incidents> GetIncidentsInDateRange(DateTime startDate, DateTime endDate)
        {

            List<Incidents> incidentsList = new List<Incidents>();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = @"SELECT * 
                         FROM Incidents 
                         WHERE IncidentDate BETWEEN @StartDate AND @EndDate";
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Incidents incidents = new Incidents();
                        incidents.IncidentID = (int)reader["IncidentID"];
                        incidents.IncidentType = (string)reader["IncidentType"];
                        incidents.IncidentDate = (DateTime)reader["IncidentDate"];
                        incidents.Location = (string)reader["Location"];
                        incidents.Description = (string)reader["Description"];
                        incidents.Status = (string)reader["Status"];
                        incidents.VictimID = (int)reader["VictimID"];
                        incidents.SuspectID = (int)reader["SuspectID"];
                        incidents.AgencyID = (int)reader["AgencyID"];
                        incidentsList.Add(incidents);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error fetching incidents: {ex.Message}");
                // Optionally, rethrow or handle it as needed
            }
            return incidentsList;
        }
        public List<Incidents> SearchIncidents(string incidentType)
        {
            List<Incidents> incidentsList = new List<Incidents>();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = @"SELECT * 
                         FROM Incidents 
                         WHERE IncidentType = @IncidentType";
                    cmd.Parameters.AddWithValue("@IncidentType", incidentType);
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Incidents incidents = new Incidents();
                        incidents.IncidentID = (int)reader["IncidentID"];
                        incidents.IncidentType = (string)reader["IncidentType"];
                        incidents.IncidentDate = (DateTime)reader["IncidentDate"];
                        incidents.Location = (string)reader["Location"];
                        incidents.Description = (string)reader["Description"];
                        incidents.Status = (string)reader["Status"];
                        incidents.VictimID = (int)reader["VictimID"];
                        incidents.SuspectID = (int)reader["SuspectID"];
                        incidents.AgencyID = (int)reader["AgencyID"];
                        incidentsList.Add(incidents);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error searching incidents: {ex.Message}");
            }
            return incidentsList;

        }
        public Reports GenerateIncidentReport(int reportId)
        {
            Reports report = null;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = @"
            SELECT r.ReportID, r.ReportDate, r.ReportDetails, r.Status,
                   i.IncidentID, i.IncidentType, i.IncidentDate, i.Location, i.Description, i.Status AS IncidentStatus
            FROM Reports r
            INNER JOIN Incidents i ON r.IncidentID = i.IncidentID
            WHERE r.ReportID = @ReportID";

                cmd.Parameters.AddWithValue("@ReportID", reportId);
                cmd.Connection = sqlConnection;
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    report = new Reports
                    {
                        ReportID = (int)reader["ReportID"],
                        ReportDate = (DateTime)reader["ReportDate"],
                        ReportDetails = (string)reader["ReportDetails"],
                        Status = (string)reader["Status"],
                        IncidentDetails = new Incidents
                        {
                            IncidentID = (int)reader["IncidentID"],
                            IncidentType = (string)reader["IncidentType"],
                            IncidentDate = (DateTime)reader["IncidentDate"],
                            Location = (string)reader["Location"],
                            Description = (string)reader["Description"],
                            Status = (string)reader["IncidentStatus"]
                        }
                    };

                }

            }
            return report;


        }
        public Reports GetDetails(int reportId)
        {
            Reports report = null;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = @"
            SELECT r.ReportID, r.ReportDate, r.ReportDetails, r.Status,
                   i.IncidentID, i.IncidentType, i.IncidentDate, i.Location, i.Description, i.Status AS IncidentStatus
            FROM Reports r
            INNER JOIN Incidents i ON r.IncidentID = i.IncidentID
            WHERE r.ReportID = @ReportID";

                cmd.Parameters.AddWithValue("@ReportID", reportId);
                cmd.Connection = sqlConnection;
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    report = new Reports
                    {
                        ReportID = (int)reader["ReportID"],
                        ReportDate = (DateTime)reader["ReportDate"],
                        ReportDetails = (string)reader["ReportDetails"],
                        Status = (string)reader["Status"],
                        IncidentDetails = new Incidents
                        {
                            IncidentID = (int)reader["IncidentID"],
                            IncidentType = (string)reader["IncidentType"],
                            IncidentDate = (DateTime)reader["IncidentDate"],
                            Location = (string)reader["Location"],
                            Description = (string)reader["Description"],
                            Status = (string)reader["IncidentStatus"]
                        }
                    };

                }

            }
            return report;
        }
        public bool UpdateCaseDetails(Reports updatedReport)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = @"
                UPDATE Reports
                SET ReportDetails = @ReportDetails,
                    ReportDate = @ReportDate,
                    Status = @Status
                WHERE ReportID = @ReportID";

                    cmd.Parameters.AddWithValue("@ReportID", updatedReport.ReportID);
                    cmd.Parameters.AddWithValue("@ReportDetails", updatedReport.ReportDetails);
                    cmd.Parameters.AddWithValue("@ReportDate", updatedReport.ReportDate);
                    cmd.Parameters.AddWithValue("@Status", updatedReport.Status);

                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating case details: {ex.Message}");
                return false;
            }
        }
        public List<CaseReport> GetAllCases()
        {
            List<CaseReport> caseList = new List<CaseReport>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = @"
            SELECT 
                i.IncidentType AS IncidentType,
                i.IncidentDate AS IncidentDate,
                i.Location AS IncidentLocation,
                i.Description AS IncidentDescription,
                i.Status AS IncidentStatus,
                v.FirstName AS VictimFirstName,
                v.LastName AS VictimLastName,
                v.DateOfBirth AS VictimDateOfBirth,
                v.Gender AS VictimGender,
                v.ContactInformation AS VictimContactInformation,
                s.FirstName AS SuspectFirstName,
                s.LastName AS SuspectLastName,
                s.DateOfBirth AS SuspectDateOfBirth,
                s.Gender AS SuspectGender,
                s.ContactInformation AS SuspectContactInformation,
                r.ReportID AS ReportID,
                r.IncidentID AS ReportIncidentID,
                r.ReportDate AS ReportDate,
                r.ReportDetails AS ReportDetails,
                r.Status AS ReportStatus,
                a.AgencyName AS AgencyName,
                a.Jurisdiction AS AgencyJurisdiction,
                a.ContactInformation AS AgencyContactInformation,
                o.FirstName AS OfficerFirstName,
                o.LastName AS OfficerLastName,
                o.BadgeNumber AS OfficerBadgeNumber,
                o.Rank AS OfficerRank,
                o.ContactInformation AS OfficerContactInformation,
                e.Description AS EvidenceDescription,
                e.LocationFound AS EvidenceLocation
            FROM Incidents i
            LEFT JOIN Evidence e ON i.IncidentID = e.IncidentID
            LEFT JOIN Victims v ON i.VictimID = v.VictimID
            LEFT JOIN Suspects s ON i.SuspectID = s.SuspectID
            LEFT JOIN Reports r ON i.IncidentID = r.IncidentID
            LEFT JOIN LawEnforcementAgencies a ON i.AgencyID = a.AgencyID
            LEFT JOIN Officers o ON a.AgencyID = o.AgencyID;";

                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    CaseReport crimeCase = new CaseReport
                    {
                        IncidentDetails = new Incidents
                        {
                            IncidentType = (string)reader["IncidentType"],
                            IncidentDate = (DateTime)reader["IncidentDate"],
                            Location = (string)reader["IncidentLocation"],
                            Description = (string)reader["IncidentDescription"],
                            Status = (string)reader["IncidentStatus"],
                        },
                        VictimDetails = new Victims
                        {
                            FirstName = (string)reader["VictimFirstName"],
                            LastName = (string)reader["VictimLastName"],
                            DateOfBirth = (DateTime)reader["VictimDateOfBirth"],
                            Gender = (string)reader["VictimGender"],
                            Contactinformation = (string)reader["VictimContactInformation"],
                        },
                        SuspectDetails = new Suspects
                        {
                            FirstName = (string)reader["SuspectFirstName"],
                            LastName = (string)reader["SuspectLastName"],
                            DateOfBirth = (DateTime)reader["SuspectDateOfBirth"],
                            Gender = (string)reader["SuspectGender"],
                            ContactInformation = (string)reader["SuspectContactInformation"],
                        },
                        ReportDetails = new Reports
                        {
                            IncidentID = (int)reader["ReportIncidentID"],
                            ReportDate = (DateTime)reader["ReportDate"],
                            ReportDetails = (string)reader["ReportDetails"],
                            Status = (string)reader["ReportStatus"],
                        },
                        AgencyDetails = new LawEnforcementAgencies
                        {
                            AgencyName = (string)reader["AgencyName"],
                            Jurisdiction = (string)reader["AgencyJurisdiction"],
                            ContactInformation = (string)reader["AgencyContactInformation"],
                        },
                        OfficerDetails = new Officers
                        {
                            FirstName = (string)reader["OfficerFirstName"],
                            LastName = (string)reader["OfficerLastName"],
                            BadgeNumber = (string)reader["OfficerBadgeNumber"],
                            Rank = (string)reader["OfficerRank"],
                            ContactInformation = (string)reader["OfficerContactInformation"],
                        },
                        EvidenceDetails = new Evidence
                        {
                            Description = (string)reader["EvidenceDescription"],
                            LocationFound = (string)reader["EvidenceLocation"],
                        }
                    };

                    caseList.Add(crimeCase);
                }

                reader.Close();
            }

            return caseList;
        }
        public Incidents GetIncidentById(int incidentId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT * FROM Incidents WHERE IncidentID = @IncidentID";
                cmd.Parameters.AddWithValue("@IncidentID", incidentId);
                cmd.Connection = sqlConnection;

                sqlConnection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Incidents
                        {
                            IncidentID = (int)reader["IncidentID"],
                            IncidentType = reader["IncidentType"].ToString(),
                            Location = reader["Location"].ToString(),
                            Description = reader["Description"].ToString(),
                            Status = reader["Status"].ToString()
                        };
                    }
                    else
                    {
                        throw new IncidentNumberNotFoundException($"Incident with ID {incidentId} not found.");
                    }
                }
            }
        }
    }
}
    