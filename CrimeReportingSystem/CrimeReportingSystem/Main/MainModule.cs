using CrimeReportingSystemAPP.dao;
using CrimeReportingSystemAPP.Entity;
using CrimeReportingSystemAPP.util;
using CrimeReportingSystemAPP.exception;
using CrimeReportingSystem.Entity;
namespace CrimeReportingSystemAPP.Main
{
    internal class MainModule
    {
        public void Module()

            {
                
                Console.WriteLine("=========CRIME REPORTING AND ANALYSIS SYSTEM=========");
                
            ICrimeAnalysisService service = new CrimeAnalysisService();

                Console.WriteLine("===Menu===");
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Create Incident");
                Console.WriteLine("2. Update Incident Status");
                Console.WriteLine("3. Get Incidents In Date Range");
                Console.WriteLine("4. Search Incidents");
                Console.WriteLine("5. Generate Incident Report");
                Console.WriteLine("6. Get Case Details");
                Console.WriteLine("7. Update Case Details");
                Console.WriteLine("8. Get All Cases");
                Console.WriteLine("9. Get All Incidents");
                Console.WriteLine("10. Get Incident by IncidentID");
                Console.WriteLine("11. Exit");
                Console.WriteLine("-----------------------------------------");
            while (true)
            {
                Console.Write("Enter choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {

                    case 1:
                        {
                            Console.WriteLine("Enter Victim Details:");
                            Console.Write("First Name: ");
                            string victimFirstName = Console.ReadLine();

                            Console.Write("Last Name: ");
                            string victimLastName = Console.ReadLine();

                            Console.Write("Date of Birth (yyyy-MM-dd): ");
                            DateTime victimDOB = DateTime.Parse(Console.ReadLine());

                            Console.Write("Gender: ");
                            string victimGender = Console.ReadLine();

                            Console.Write("Contact Information: ");
                            string victimContactInfo = Console.ReadLine();

                            // Create a new victim object
                            Victims victim = new Victims
                            {
                                FirstName = victimFirstName,
                                LastName = victimLastName,
                                DateOfBirth = victimDOB,
                                Gender = victimGender,
                                Contactinformation = victimContactInfo
                            };
                            Console.WriteLine("\nEnter Suspect Details:");
                            Console.Write("First Name: ");
                            string suspectFirstName = Console.ReadLine();

                            Console.Write("Last Name: ");
                            string suspectLastName = Console.ReadLine();

                            Console.Write("Date of Birth (yyyy-MM-dd): ");
                            DateTime suspectDOB = DateTime.Parse(Console.ReadLine());

                            Console.Write("Gender: ");
                            string suspectGender = Console.ReadLine();

                            Console.Write("Contact Information: ");
                            string suspectContactInfo = Console.ReadLine();

                            // Create a new suspect object
                            Suspects suspect = new Suspects
                            {
                                FirstName = suspectFirstName,
                                LastName = suspectLastName,
                                DateOfBirth = suspectDOB,
                                Gender = suspectGender,
                                ContactInformation = suspectContactInfo
                            };
                            Console.WriteLine("Enter Incident Type:");
                            string incidentType = Console.ReadLine();

                            Console.WriteLine("Enter Location:");
                            string location = Console.ReadLine();

                            Console.WriteLine("Enter Description:");
                            string description = Console.ReadLine();

                            Console.WriteLine("Enter Status:");
                            string status = Console.ReadLine();

                            Console.WriteLine("Choose the AgencyID:");
                            Console.WriteLine("1. Police Department, City, 9876543212");
                            Console.WriteLine("2. State Police, State, 9876543211");
                            Console.WriteLine("3. Central Police, Central, 9876543210");
                            int agencyId;
                            do
                            {
                                Console.WriteLine("Choose the AgencyID (1, 2, or 3):");
                                string input = Console.ReadLine();

                                if (input == "1" || input == "2" || input == "3")
                                {
                                    agencyId = int.Parse(input);
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid choice. Please enter 1, 2, or 3.");
                                }
                            } while (true);
                            Incidents incidents = new Incidents
                            {
                                IncidentType = incidentType,
                                Location = location,
                                Description = description,
                                Status = status,
                                AgencyID = agencyId
                            };
                            bool addIncidentStatus = service.AddIncidents(incidents,victim, suspect);
                            if (addIncidentStatus)
                            {
                                Console.WriteLine("incident Added Successfully");
                            }
                            else
                            {
                                Console.WriteLine("incident Addition Failed");
                            }
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Enter Incident ID:");
                            int incidentId = int.Parse(Console.ReadLine());

                            Console.WriteLine("Enter New Status:");
                            string status = Console.ReadLine();
                            Incidents incidents = new Incidents();
                            bool addUpdateStatus = service.UpdateIncidentStatus(incidentId, status);
                            if (addUpdateStatus)
                            {
                                Console.WriteLine("Updated Successfully");
                            }
                            else
                            {
                                Console.WriteLine("Updated Failed");
                            }
                            break;
                        }
                    case 3:
                        {

                            Console.WriteLine("Enter start date (yyyy-mm-dd):");
                            DateTime startDate;
                            while (!DateTime.TryParse(Console.ReadLine(), out startDate))
                            {
                                Console.WriteLine("Invalid date format. Please enter again (yyyy-mm-dd):");
                            }

                            Console.WriteLine("Enter end date (yyyy-mm-dd):");
                            DateTime endDate;
                            while (!DateTime.TryParse(Console.ReadLine(), out endDate))
                            {
                                Console.WriteLine("Invalid date format. Please enter again (yyyy-mm-dd):");
                            }

                            List<Incidents> incidentsList = service.GetIncidentsInDateRange(startDate, endDate);

                            if (incidentsList.Count == 0)
                            {
                                Console.WriteLine("No incidents found for the given date range.");
                            }
                            else
                            {
                                foreach (Incidents inc in incidentsList)
                                {
                                    Console.WriteLine(inc);
                                }
                            }
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Enter the incident type to search (e.g., Robbery, Theft):");
                            string criteria = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(criteria))
                            {
                                Console.WriteLine("Incident type cannot be empty. Please try again.");
                                break;
                            }

                            List<Incidents> incidentsList = service.SearchIncidents(criteria);

                            if (incidentsList.Count == 0)
                            {
                                Console.WriteLine("No incidents found for the specified type.");
                            }
                            else
                            {
                                Console.WriteLine($"Incidents of type '{criteria}':");
                                foreach (Incidents inc in incidentsList)
                                {
                                    Console.WriteLine(inc);
                                }
                            }
                            break;


                        }
                    case 5:
                        {
                            Console.WriteLine("Enter Report ID:");
                            int reportId = int.Parse(Console.ReadLine());

                            Reports report = service.GenerateIncidentReport(reportId);
                            if (report != null)
                            {
                                Console.WriteLine($"Report ID: {report.ReportID}");
                                Console.WriteLine($"Report Date: {report.ReportDate:yyyy-MM-dd}");
                                Console.WriteLine($"Details: {report.ReportDetails}");
                                Console.WriteLine($"Status: {report.Status}");
                                Console.WriteLine("Incident Details:");
                                Console.WriteLine($"  Incident ID: {report.IncidentDetails.IncidentID}");
                                Console.WriteLine($"  Type: {report.IncidentDetails.IncidentType}");
                                Console.WriteLine($"  Date: {report.IncidentDetails.IncidentDate:yyyy-MM-dd}");
                                Console.WriteLine($"  Location: {report.IncidentDetails.Location}");
                                Console.WriteLine($"  Description: {report.IncidentDetails.Description}");
                                Console.WriteLine($"  Status: {report.IncidentDetails.Status}");
                            }
                            else
                            {
                                Console.WriteLine("No report found with the provided ID.");
                            }


                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("Enter Report ID:");
                            int reportId = int.Parse(Console.ReadLine());

                            Reports report = service.GetDetails(reportId);
                            if (report != null)
                            {
                                Console.WriteLine($"Report ID: {report.ReportID}");
                                Console.WriteLine($"Report Date: {report.ReportDate:yyyy-MM-dd}");
                                Console.WriteLine($"Details: {report.ReportDetails}");
                                Console.WriteLine($"Status: {report.Status}");
                                Console.WriteLine("Incident Details:");
                                Console.WriteLine($"Incident ID: {report.IncidentDetails.IncidentID}");
                                Console.WriteLine($"Incident Type: {report.IncidentDetails.IncidentType}");
                                Console.WriteLine($"Date: {report.IncidentDetails.IncidentDate:yyyy-MM-dd}");
                                Console.WriteLine($"Location: {report.IncidentDetails.Location}");
                                Console.WriteLine($"Description: {report.IncidentDetails.Description}");
                                Console.WriteLine($"Status: {report.IncidentDetails.Status}");
                            }
                            else
                            {
                                Console.WriteLine("No report found with the provided ID.");
                            }
                            break;
                        }
                    case 7:
                        {
                            Console.WriteLine("Enter Report ID to update:");
                            int reportId = int.Parse(Console.ReadLine());

                            Console.WriteLine("Enter new Report Details:");
                            string reportDetails = Console.ReadLine();

                            Console.WriteLine("Enter new Report Date (yyyy-MM-dd):");
                            DateTime reportDate;
                            while (!DateTime.TryParse(Console.ReadLine(), out reportDate))
                            {
                                Console.WriteLine("Invalid date format. Please enter again (yyyy-MM-dd):");
                            }

                            Console.WriteLine("Enter new Status:");
                            string status = Console.ReadLine();

                            // Create a Reports object with updated details
                            Reports updatedReport = new Reports
                            {
                                ReportID = reportId,
                                ReportDetails = reportDetails,
                                ReportDate = reportDate,
                                Status = status
                            };
                            bool isUpdated = service.UpdateCaseDetails(updatedReport);
                            if (isUpdated)
                            {
                                Console.WriteLine("Report updated successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Failed to update the report. Please check the Report ID and try again.");
                            }
                            break;
                        }
                    case 8:
                        {
                            List<CaseReport> cases = service.GetAllCases();
                            if (cases == null || cases.Count == 0)
                            {
                                Console.WriteLine("No cases found.");
                                return;
                            }

                            Console.WriteLine("========= All Case Reports =========");
                            foreach (var CaseReport in cases)
                            {
                                Console.WriteLine("-------------------------------------");
                                Console.WriteLine(CaseReport.ToString());
                            }
                            Console.WriteLine("-------------------------------------");
                            break;
                        }
                    case 9:
                        {
                            List<Incidents> incident = service.GetAllIncidents();
                            foreach (Incidents inc in incident )
                                {
                                    Console.WriteLine(inc);
                                }
                                break;
                        }
                    case 10:
                        {
                            try
                            {
                                Console.Write("Enter the Incident ID: ");
                                int incidentId = int.Parse(Console.ReadLine());
                                Incidents incident = service.GetIncidentById(incidentId);

                                Console.WriteLine("\nIncident Details:");
                                Console.WriteLine($"ID: {incident.IncidentID}");
                                Console.WriteLine($"Type: {incident.IncidentType}");
                                Console.WriteLine($"Location: {incident.Location}");
                                Console.WriteLine($"Description: {incident.Description}");
                                Console.WriteLine($"Status: {incident.Status}");
                            }
                            catch (IncidentNumberNotFoundException ex)
                            {

                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            break;
                        }
                        case 11:
                        {
                            Console.WriteLine("Exit successfully");
                            return;
                        }
                        default:
                            {
                                Console.WriteLine("Invalid choice.");
                                break;
                            }

                    }

                }
            }
        }
    }

   
    
