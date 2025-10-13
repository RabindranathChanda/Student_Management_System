# Docker Usage Guide

This guide explains how to use Docker to **build** the Student Management System application. This is a great alternative if you do not want to install Visual Studio and the .NET Framework SDK on your machine.

**Important:** This process uses Docker to compile the application and package its files. You cannot run the graphical user interface (GUI) directly inside a Docker container because containers are "headless" (they have no screen). You will run the final `.exe` file on your Windows machine.

---

## Prerequisites
- Install Docker Desktop for Windows.

---

## Steps to Build and Run the Application

1.  **Build the Docker Image:**
    Open a terminal (like PowerShell) in the root directory of the project and run the following command. This will compile the application inside a Docker container.

   ```powershell
    docker build -t sms-app .
   ```

2.  **Extract the Application Files:**
    The following commands will create a temporary container, copy the compiled application files from the container to a new folder on your desktop, and then remove the temporary container.

   ```powershell
    # Create a temporary container (it won't start)
    docker create --name sms-container sms-app
    
    # Copy the compiled files from the container to a 'sms-release' folder on your Desktop
    docker cp sms-container:/app "C:\Users\$env:UserName\Desktop\sms-release"
    
    # Remove the temporary container
    docker rm sms-container
   ```

3.  **Run the Application:**
    Navigate to the `sms-release` folder on your desktop. Double-click `SMS.exe` to run the application.

    **Note:** You must still have a configured SQL Server instance available on your network for the application to connect to, as specified in the main `README.md`.

---

## Troubleshooting
- If you see errors about missing files, check your `.dockerignore` and file paths.
- Major Issues with DOCKER on windows host is it requires __hypervisor__ enabled which is available only pro,enterprise version.
- **For Windows Hosts Only** If you encounter issue while creating image run `$env:DOCKER_BUILDKIT=0;docker build --no-cache -t sms-app .`

---
