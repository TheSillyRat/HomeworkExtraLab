**AI-Powered Product Quality Inspection System**

**Project Overview**
This project is a web-based application designed to automate the product quality inspection process. By leveraging AI image analysis, the system evaluates product images, detects defects, and determines whether a product passes or fails quality standards.

**Features**

* AI Image Analysis: Upload product images for automated defect detection using the Google Gemini AI model.

* Instant Results: Retrieves AI-generated evaluations including quality status (Pass/Fail) and defect descriptions.

* Inspection History: Automatically saves confirmed inspection reports to a SQL database and displays them in a clean, real-time history table.

* Robust Architecture: Built with a separated Frontend (React) and Backend (.NET Web API) for scalable performance.

**Technologies Used**

* Frontend: React.js, Vite, CSS / Bootstrap

* Backend: C# .NET Core Web API, Entity Framework Core, SQL Server, Google Gemini API

**Project Structure**
Root_Folder/
├── Backend/ (Contains the .NET Web API solution)
├── Frontend/ (Contains the React Vite application)
└── README.md (Project documentation)

**How to Run the Project**

*Prerequisites*: Node.js installed, .NET SDK installed, SQL Server installed and running, A valid Google Gemini API Key.

*Backend Setup (.NET)*

1. Open the Backend folder in your IDE.

2. Open appsettings.json and update the ConnectionStrings.

3. Add your Gemini API Key.

4. Run migrations: dotnet ef database update

5. Start server: dotnet run

*Frontend Setup (React)*

1. Open the Frontend folder.

2. Install dependencies: npm install

3. Start server: npm run dev

**Demonstration**
A video demonstration of the system's workflow (uploading an image, AI processing, confirming the report, and updating the database) has been recorded and submitted alongside this project.