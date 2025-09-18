# Blog Post 1 - Project Formulation & Requirements

## Project Domain
Our project will focus on Environmental, Social and Governance (ESG) data management and reporting.
Companies focus on ESG data due to EU regulations and market expectations from investors, customers, and stakeholders.

Companies often struggle with how to collect, structure, and present ESG data in a way that is both transparent and useful for decision-making. Today much of this work is made manually in spreadsheets or systems that does not pair together, making it hard to compare data across time or giving any meaningful insights that directly support strategic decisions.

To address this challenge, we aim to design and implement a .NET based ESG reporting system. The system will allow companies to:
- Ingest ESG data such as energy consumption, CO2 emissions or waste.
- Calculate relevant KPIs such as emissions (Scope 1-3).
- Store data in a structed database.
- Provide role-based access for different users, ensuring data contributors, managers and executives can all interact with the system according to their role
- Visualize in Power BI for managers/decision-makers
  

## Why We Chose This Domain
We chose ESG reporting as our domain for three main reasons:

1. ESG reporting is no longer optional or just some keyword companies use to appear more green but has become a legal requirement for companies in Denmark and EU. While it can sound like a turn-off for some companies, it actually serves as a tool that can help guide companies. Supporting insight in many key aspects of the company's value chain and can help guide strategic decision making
2. ESG performance is tied to investor's confidence, customer trust and positioning. Companies that can track and improve ESG metrics are positioned better to attract investment, keep customers and reduce operational risks.
3. The domain provides a technical challenge. By combining a Restful .NET backend, Blazor web application, a SQLite database with Entity framework, and integration with PowerBI we will deliver a full-stack that demonstrates technical and business relevance.

## Requirements
- As an admin, I want to log in with a username and password, so that I can securely upload and manage ESG data.
- As a admin, I want to upload ESG data files, so that the company’s sustainability data is recorded in the system
- As an admin, I want to update or delete incorrect data
- As an admin, I want to create, and delete users, so that I can control who has access to the system.
- As a user, I want to log in with a username and password, so that I can securely access the ESG data and reports.
- As a user, I want to view ESG results in a Power BI dashboard, so that I can identify trends and support decision-making.
- As a user, I want to filter results, so that I can focus on the data needed.
- As a user, I want to see uploaded data in clear tables or charts
  
