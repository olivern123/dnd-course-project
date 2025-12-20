# Project Conclusion & Demonstration

## Final Development Status

The WasteTracker project has now reached a stable and functional state that fulfills the technical and academic requirements of the DND course. During the final phase of development, the focus was on refining existing functionality, improving data handling robustness, and ensuring a smooth interaction between the Blazor frontend and the RESTful Web API.

Key improvements in the final stage included stabilizing the Excel import functionality, validating KPI calculations, and ensuring that role-based access worked consistently across all relevant pages. Additional effort was also put into ensuring that the system could handle inconsistent real-world data formats, especially when parsing Excel files originating from production systems.

The system is delivered as two distinct applications: a .NET Web API responsible for data access and business logic, and a Blazor Server application acting as the user-facing frontend. These applications communicate exclusively through HTTP, fulfilling the architectural requirements of the project.

---

## Implemented Requirements Overview

The initial requirements defined in the first blog post were formulated as user stories. The table below summarizes their implementation status:

- **Upload Excel files and store waste data** – Implemented  
- **View waste-related KPIs (total waste, internal reuse, categories)** – Implemented  
- **Visual dashboards with tables and indicators** – Implemented  
- **Secure login with multiple user roles** – Implemented  
- **Admin-only edit and delete functionality** – Implemented  
- **Filtering waste data by date** – Implemented  
- **Competitor KPI comparison via Excel upload** – Implemented  

All core functional requirements defined at the start of the project have been successfully implemented.

---

## Technical Outcome

From a technical perspective, the project demonstrates the use of several core .NET technologies:

- **ASP.NET Core Web API** for RESTful services
- **Blazor Server** for interactive frontend development
- **Entity Framework Core with SQLite** for data persistence
- **LINQ** for querying and aggregating waste and KPI data
- **ClosedXML** for Excel file parsing
- **Role-based access control** to differentiate between users and administrators

The introduction of an ORM significantly simplified data access and reduced the need for manual SQL queries. LINQ enabled expressive and readable data operations, particularly for KPI aggregation and filtering.

---

## Challenges and Solutions

One of the main challenges encountered during development was handling inconsistent Excel data formats. Production files contained varying decimal separators, empty cells, and different numeric representations. This was addressed by implementing robust parsing logic that normalizes values before processing them.

Another challenge was ensuring correct role-based access across both frontend and backend layers. This was solved by combining authentication logic in the API with conditional rendering and checks in the Blazor frontend.

Ensuring that the frontend and backend evolved together without breaking functionality also required careful coordination and frequent testing, especially when introducing new endpoints or modifying data models.

---

## Project Demonstration

A short video demonstration of the final system has been recorded and uploaded to YouTube. The video shows the full workflow, including login, dashboard overview, Excel import, KPI updates, and competitor comparison.

## Youtube video demonstration
https://youtu.be/z2stDYgrQww

---

## Overall Conclusion

The WasteTracker project successfully meets the objectives of the DND course by delivering a complete, data-driven system built with modern .NET technologies. The project demonstrates how a RESTful backend and a Blazor frontend can be combined to solve a real-world problem involving data quality, sustainability reporting, and user interaction.

Beyond fulfilling the technical requirements, the project provided valuable experience in system architecture, data handling, and full-stack development. The final solution illustrates how software systems can support ESG reporting by transforming raw production data into structured, transparent, and actionable insights.

Overall, the project has been a strong learning experience and provides a solid foundation for future work involving .NET-based web applications and data-intensive systems.
