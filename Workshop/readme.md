![DesignDevelopServerlessEventDrivenMicroserviceSolution](https://github.com/TaleLearnCode/DesignDevelopServerlessEventDrivenMicroserviceSolution/blob/main/Thumbnail.png)

# Design and Develop a Serverless Event-Driven Microservice-Based Solution Workshop

You have heard all the buzzwords such as microservices, event-driven architecture, serverless, etc. You probably have attended sessions that talked about these terms.  But how do you put all that together?

In this full-day hands-on workshop, attendees will dive into the exciting world of serverless event-driven microservices using Azure and C#. This comprehensive training session is designed to equip developers with the knowledge and practical skills to architect, build, and deploy scalable, efficient, and cost-effective serverless solutions on Microsoft's Azure cloud platform.

## Workshop Content:

> The workshop content is subject to change as it is still in development.

1. **Introduction to Serverless Architecture:**
   - Understanding the principles of serverless computing and its advantages.
   - Exploring event-driven microservices and their role in modern application development.

2. **Azure Serverless Services Overview:**
   - An in-depth look at key Azure services such as Azure Functions, Event Hubs, and Service Bus.
   - Selecting the appropriate services based on specific use cases and requirements.

3. **Building Serverless Functions with C#:**
   - Learning the basics of Azure Functions and setting up a development environment with C#.
   - Creating and deploying serverless functions to handle various triggers and events.

4. **Event-Driven Communication and Messaging:**
   - Implementing event-based communication between microservices using Azure Event Hubs.
   - Leveraging Event Hubs and Azure Service Bus to decouple components and enhance scalability.

5. **Securing Serverless Solutions:**
   - Understanding security best practices for serverless applications.
   - Integrating Azure Active Directory for authentication and authorization.

6. **Scaling and Performance Optimization:**
   - Strategies for optimizing performance and minimizing latency in serverless solutions.
   - Handling concurrent requests and efficiently managing resources.

7. **Lessons Learned and Real-World Case Studies:**
   - Examining real-world examples of successful serverless microservice solutions.
   - Identifying common pitfalls and best practices from industry experts.

## Technologies and Services
The following technologies and services will be levered in this workshop (subject to change):

- [Azure App Configuration](https://azure.microsoft.com/en-us/products/app-configuration/)
- [Azure Cosmos DB](https://azure.microsoft.com/en-us/products/cosmos-db/)
- [Azure Event Hubs](https://azure.microsoft.com/en-us/products/event-hubs/)
- [Azure Functions](https://azure.microsoft.com/en-us/products/functions/)
- [Azure Logic Apps](https://azure.microsoft.com/en-us/products/logic-apps/)
- [Azure KeyVault](https://azure.microsoft.com/en-us/products/key-vault/)
- [Azure SQL](https://azure.microsoft.com/en-us/products/azure-sql/)
- [GitHub Actions](https://learn.microsoft.com/en-us/azure/developer/github/github-actions?WT.mc_id=AZ-MVP-5004334)

## Prerequisites:

- Basic understanding of C# programming language and .NET ecosystem.
- Familiarity with cloud computing concepts and Azure services is beneficial but not mandatory.
- Attendees should bring their own laptops with administrative privileges and have the Azure SDK installed (a guide will be provided before the workshop).

In order to participate in the hands-on exercises, please have the following installed and ready to go before the workshop day:

- Visual Studio Community 2022 or better; [available here](https://visualstudio.microsoft.com/vs/)
- Visual Studio Code (optional/instead of Visual Studio 2022); [available here](https://code.visualstudio.com/)
- GIT; [available here](https://git-scm.com/downloads)
- A GitHub account where you can create code repositories; [available here](https://github.com/join)
- An active Azure subscription; [available here](https://azure.microsoft.com/en-us/free)
- .NET 6 SDK; [available here](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- PostMan; [available here](https://www.postman.com/downloads/)
- SendGrid account; [available here](https://signup.sendgrid.com/)

> **Note:** Please understand that we cannot spend time setting up your machine and getting subscriptions as the workshop has too much material to spend time on these tasks.  Please try to arrive for thw orkshop with a machine, Azure subscription, and GitHub account that you can use from the venue WiFi.

Join us for this immersive workshop and unlock the potential of serverless event-driven microservices on Azure. By the end of the day, you will have the confidence and expertise to build scalable and event-driven solutions that can revolutionize the way you approach modern application development.

## Scenario
Building Bricks, a company specializing in the retain of LEGO products, intends to establish a robust and efficient ecommerce system to enhance their online presence, improve customer experience, and increase sales revenue.  Your company has been hired to build this solution for them and your team is responsible for the backend components.

In the process of building the backend, you will build the following microservices:

- **Product Management:** Responsible for managing product information.
- **Order Management:** Handles order placement and processing.
- **Inventory Management:** Manages product inventory levels.
- **Shipping Management:** Handles order shipping and tracking.
- **Email Management:** Sends order confirmations and status updates to customers.