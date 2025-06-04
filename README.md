# Driving & Vehicle License Department (DVLD) System

A desktop-based application that manages drivers and the process of issuing, renewing, and handling various driving licenses. Built using **C#**, **.NET Framework**, and **SQL Server**.

---

## 🚗 Project Overview

The DVLD System is designed to streamline the operations of a Driver and Vehicle Licensing Department. It provides tools for managing people, users, drivers, and licenses through an intuitive interface, supporting a wide range of license-related actions.

---

## ✅ Features

- 👤 **People, Users, and Drivers Management** with full CRUD operations.
- 🆕 **First-Time License Issuing**
- 📝 **Test Management** – take and retake exams.
- ♻️ **License Renewal**
- 🚫 **Detain & Release Licenses**
- 📄 **Replacement for Lost or Damaged Licenses**
- 🌐 **Issue International Licenses**
- 🔜 **More features to be added in future updates**

---

## 💻 Technologies Used

- **C#** (.NET Framework)
- **SQL Server**
- **Windows Forms (WinForms)** via Visual Studio

---

## ⚙️ Installation & Setup

### 1. 🔄 Restore the Database

- Open SQL Server Management Studio.
- Run the following SQL command to restore the database:

```sql
RESTORE DATABASE DVLD
FROM DISK = 'D:\YourProjectPath\Database\DVLD.bak'
WITH MOVE 'DVLD' TO 'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DVLD.mdf',
     MOVE 'DVLD_log' TO 'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DVLD_log.ldf',
     REPLACE;
```

> 💡 Make sure to adjust the file paths (`DISK`, `MOVE`) according to where you saved the `DVLD.bak` and your SQL Server instance directories.



### 2. 🛠️ Run the Application
---
 Note:To allow the application to connect to your local SQL Server instance, you must update the connection string in the App.config file.

1- Navigate to the DVLD Folder.
2- Open the App.config in any text editor.
3- Locate the connection section should be like this:

      <connectionStrings>
          <add name="DVLDConnectionString"
              connectionString="Data Source=.;Initial Catalog=DVLD;User ID=sa;Password=123456;"
              providerName="System.Data.SqlClient" />
      </connectionStrings>

4-Update the values:

         Data Source → Your SQL Server instance (e.g., localhost, .\SQLEXPRESS, etc.)

         Initial Catalog → Leave as DVLD (or change if you used a different DB name)

         User ID and Password → Use your own SQL Server login credentials

5- Open the solution by navigating to the root project folder and double-clicking on DVLD.sln.
6- Navigate to the `DVLD` directory.
7- Double-click on `DVLD.sln` to open the solution in Visual Studio.
8- Ensure your connection string is configured in App.config (already included step 1 to 4).
9- Build and run the project.

---

### 🔐 Login Credentials

- **Username:** `User`  
- **Password:** `1234`

---

## 📁 Project Structure

DVLD/
├── DVLD/                              # Presentation Layer (WinForms UI)
├── DVLD_Business/                     # Business Logic Layer
├── DVLD_DataAccess/                   # Data Access Layer (Database connection & queries)
├── Database/                          # Contains DVLD.bak SQL Backup File
└── README.md                          # Project documentation
└── DVLD DVLD Relational Schema.png    # Database Relational Schema Diagram



## 📄 License

This project is licensed under the MIT License.
You are free to use, modify, and distribute this software with attribution.


## 👤 Author

moneebcodebase
Feel free to reach out or contribute via GitHub.


