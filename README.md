# ToDoAppAPI

**ToDoAppAPI** is a web api project to create,update,retrieve,delete tasks 

This project is built in **ASP.NET  (.NET Framework 4.7.2)**


## 📒 Table of Contents 

- [System Requirements](#-system-requirements)
- [Setup](#-setup)
- [Run Project](#-run-project)
- [Usage](#-usage)
- [Build](#-build)

## ⚙ System Requirements

* IDE Framework - **Visual Studio 2019 or higher**
* OS - **Windows 8 or higher**
* **IIS** should be installed.
---
## 🛠 Setup

1. Download the project from this repository.
2. Right-click on downloaded zip file. Click Properties. Check the checkbox for **Unblock**. Click Apply.
	> You can skip this step if you are cloning the repository.
	
3. Open **ToDoApp.sln** file via Visual Studio.
4. Right-click on **ToDoApp** and select **Set as Startup Project**.

---
## ⌛ Run Project

* Right-click on **ToDoApp** project. Click _**Set as Startup Project**_.
* Run the project by pressing **F5** in the keyboard.
* Use the localhost url from browser and append the following - api/home/inventory
* URL https://localhost:44358/todo/api/v1.0/tasks     **GET METHOD**
* URL https://localhost:44358/todo/api/v1.0/tasks/id?id=3     **GET METHOD**
* URL https://localhost:44358/todo/api/v1.0/create?task=5     **POST METHOD**
* URL https://localhost:44358/todo/api/v1.0/update?id=5&task=Analysis      **PUT METHOD**
* URL https://localhost:44358/todo/api/v1.0/delete?id=5       **DLETE METHOD**
* Token to be included in Header while calling the API 
* key = **Token** , value = **135a1eb922ae3aa21eefa5be17f510ec**

---
## ✔ Usage

* New Task can be created 
* The Tasks are listed 
* Task can be updated 
* Tasks can also be deleted 

---
## 🌐 Build

* In the Build Menu, change Configuration Manager from Debug to **Release**.
* Right-click on **ToDoApp** project. Select **Publish**.
* Select **Folder** from list of Hosting options. Click **Next**.
* Choose a publishing directory. 
* Click **Finish**.
---




