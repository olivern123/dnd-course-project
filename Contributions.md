# Contributions of development
##Oliver Nedergaard (Backend Architecture, API & Integration)

Oliver had the main responsibility for the overall backend architecture and system integration.

Main contributions:

Designed the overall system architecture and layered structure

Designed and implemented the domain model, including:

WasteEntry

Site

WasteType

HandlingMethod

UploadedFile

User

Implemented AppDbContext using Entity Framework Core with SQLite

Defined entity relationships, constraints, and ensured data integrity

Implemented and coordinated RESTful API endpoints, including:

WasteEntriesController

UploadedFilesController

UsersController

Implemented Excel file import logic, including robust parsing and validation of inconsistent production data

Implemented KPI-related backend logic (total waste, internal reuse, waste categorisation)

Responsible for GitHub repository management, including:

Maintaining a runnable state

Handling merges

Ensuring backend and frontend compatibility after changes

## Salma Badeh (Frontend Development – Blazor)

Salma was responsible for the user-facing Blazor frontend and how waste data and KPIs are presented to users.

Main contributions:

Designed and implemented core Blazor pages, including:

Dashboard.razor

AddWasteEntry.razor

Login.razor

Competitor.razor

Implemented interactive dashboards with:

KPI cards

Tables

Percentage indicators

Implemented Excel upload UI and preview logic in the frontend

Implemented filtering functionality, including:

Date range filters

Year-based filtering for competitor data

Ensured dynamic updates of KPIs after data import

Integrated frontend pages with backend services using:

WasteService

AuthService

Focused on usability and clarity, ensuring ESG data is easy to interpret

## Fatima (User Roles, Access Control & Testing)

Fatima focused on user management, governance, and testing, ensuring the system reflected real-world access requirements.

Main contributions:

Contributed to defining user roles and permissions, including:

Admin vs regular user functionality

Helped define role-based access logic across frontend and backend

Contributed to writing and validating acceptance criteria for key features

Participated in defining test cases for:

Authentication

Data import

KPI calculation

Helped validate that system behavior matched business and ESG requirements

Contributed to quality assurance and requirement alignment

## Jasmin (Backend Controllers & API Support)

Jasmin contributed primarily to the backend API layer, focusing on controller logic and backend support.

Main contributions:

Assisted in developing and refining API controllers, including:

WasteEntriesController

UploadedFilesController

Worked with CRUD operations for waste data

Helped ensure uploaded files were correctly linked to waste entries

Tested API endpoints to verify correct data flow between backend and frontend

Collaborated with Oliver to ensure API responses matched frontend needs

Gained experience with RESTful API design and Entity Framework integration
