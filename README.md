# ChatWebApp

## Overview
ChatWebApp is a real-time web chat application built with ASP.NET Core MVC and Azure services. It features instant message delivery using SignalR, message storage in Azure SQL Database, and optional sentiment analysis using Azure Cognitive Services. Messages are color-coded according to sentiment: positive (green), neutral (yellow), and negative (red).
[https://chatapp-online-bwgrbtdeckhbh4hn.germanywestcentral-01.azurewebsites.net]

---
## Technologies Used
- **ASP.NET Core MVC** – Backend framework for server-side logic.  
- **SignalR** – Real-time communication library for live chat functionality.  
- **Azure App Service** – Hosting the web application.  
- **Azure SQL Database** – Storage of chat messages and sentiment analysis results.  
- **Azure Cognitive Services – Text Analytics** – Sentiment analysis API.  
- **HTML, CSS, JavaScript** – Frontend structure, styling, and interactivity.  

---

## Features
- **Real-Time Messaging:** Users can send and receive messages instantly without refreshing the page.  
- **Sentiment Analysis:** Each message is analyzed and tagged as positive, neutral, or negative.  
- **Color-Coded UI:** Messages are visually distinguished based on sentiment.  
  - Positive: Green  
  - Neutral: Yellow  
  - Negative: Red  
- **Persistent Storage:** All messages and sentiment scores are stored in Azure SQL Database.  
- **Responsive Chat UI:** Full-screen, flexible layout optimized for desktop browsers.  
---
## Usage
1. Enter your username in the input field.
2. Type a message and press Enter or click Send.
3. Messages will appear in real-time in the chat window, color-coded according to sentiment.
> **Note:** The first message after opening the chat may take a second or two to appear due to initial SignalR connection setup.
4. All messages are stored in Azure SQL Database.
