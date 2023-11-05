## Inventory Management
~~~
Scaffold-DbContext 'Data Source=sql-orderprocessingsystem.database.windows.net;Initial Catalog=sqldb-InventoryManagement;Persist Security Info=True;User ID=sqladmin;Password=PA$$word00' Microsoft.EntityFrameworkCore.SqlServer -Namespace BuildingBricks.IM.Models -ContextNamespace BuildingBricks.IM -OutputDir Models -Force
~~~

## Notification Management
~~~
Scaffold-DbContext 'Data Source=sql-orderprocessingsystem.database.windows.net;Initial Catalog=sqldb-NotificationManagement;Persist Security Info=True;User ID=sqladmin;Password=PA$$word00' Microsoft.EntityFrameworkCore.SqlServer -Namespace BuildingBricks.NM.Models -ContextNamespace BuildingBricks.NM -OutputDir Models -Force
~~~

## Order Management
~~~
Scaffold-DbContext 'Data Source=sql-orderprocessingsystem.database.windows.net;Initial Catalog=sqldb-OrderManagement;Persist Security Info=True;User ID=sqladmin;Password=PA$$word00' Microsoft.EntityFrameworkCore.SqlServer -Namespace BuildingBricks.OM.Models -ContextNamespace BuildingBricks.OM -OutputDir Models -Force
~~~

## Shipping Management
~~~
Scaffold-DbContext 'Data Source=sql-orderprocessingsystem.database.windows.net;Initial Catalog=sqldb-ShippingManagement;Persist Security Info=True;User ID=sqladmin;Password=PA$$word00' Microsoft.EntityFrameworkCore.SqlServer -Namespace BuildingBricks.SM.Models -ContextNamespace BuildingBricks.SM -OutputDir Models -Force
~~~