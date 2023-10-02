# HumanCapitalManagement
## Overview
The Human Capital Management App will consists of three key components:

**EmployeesManagingAPI**: This is an ASP.NET Core 8 Web API that provides CRUD (Create, Read, Update, Delete) functionality for managing employee data. It uses a PostgreSQL database trough Entity Framework Core to store and retrieve information about the employees.

**DataAnalysisAPI**: Another ASP.NET Core Web API, this component is responsible for data analysis. It is automated to connect to the EmployeesManagingAPI daily to retrieve the latest employee data and performs various analyses to provide valuable insights. Also uses PostgreSQL database trough Entity Framework Core

**HumanCapitalClient**: This is the user interface for the application, built using ASP.NET Razor Pages. It allows users with different roles (Admin, Manager, Worker) to interact with the system, access reports, and manage employees based on their permissions. It uses SQLite to store the User data.

## Features
- Employee Management: Easily create, update, view, and delete employee records.
- Data Analysis: Get insights into your workforce through automated data analysis.
- User Roles: Three distinct user roles (Admin, Manager, Worker) with varying levels of access and functionality.
- Secure Authentication: User authentication and authorization to ensure data privacy.
- Database Integration: Utilizes a PostgreSQL database for data storage.
- Web Interface: A user-friendly web interface for seamless interaction.

## User Roles
This application has three distinctive user roles:

Admin: Administrators have full access to employee management, data analysis, and user management functionalities. They can configure and customize the application. They are the only ones who can create Users. 

Manager: Managers have access to employee management and data analysis features, but with limited administrative capabilities.

Worker: Workers have access to view and update their own employee data but have limited access to other functionalities.
