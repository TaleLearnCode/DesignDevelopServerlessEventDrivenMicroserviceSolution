# 00 - Connect to Azure

## User Story
As a member of the Building Bricks' e-commerce backend development team, I want to access the Azure subscription so that I can perform my work on the project.

### Definition of Done
The developer has a valid Azure subscription and can access it from the command line.

---

## Workshop Exercises
For some of the workshop, we will be using Azure.  You will need to have an Azure account to complete the workshop.  If you do not have an Azure account, you can create one for free [here](https://azure.microsoft.com/en-us/free/).

### Install Azure CLI (00A)
The Azure CLI is a command-line tool providing a great experience for managing Azure resources. The CLI is designed to make scripting easy, query data, support long-running operations, and more. It is available across Azure services and is designed to be consistent, easy to use, and easy to learn.

1. Navigate to [Install Azure CLI on Windows](https://learn.microsoft.com/en-us/cli/azure/install-azure-cli-windows?tabs=azure-cli)
1. Follow the instructions to install the Azure CLI

### Login to Azure (00B)
1. Open a command prompt
1. Type `az login`
1. Follow the instructions to login to Azure
1. Type `az account list`
1. Verify that the subscription you want to use is listed
1. Type `az account set --subscription <subscription id>`
1. Verify that the correct subscription is set
1. Type `az account show`
1. Verify that the correct subscription is set