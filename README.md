howest-abbodienst
==============

Implementatie van het voorbeeldexamen uit 2011-2012 met 
technieken uit ASP.NET MVC5. 

Indien er een SQL Exceptie optreed bij opstarten moet volgende
worden toegevoegd aan web.confg:

```
<connectionStrings>
<add name="MagazineContext" connectionString="Data Source=(LocalDb)\v11.0;Initial Catalog=MagazineContext;Integrated Security=SSPI;" providerName="System.Data.SqlClient" />
</connectionStrings>
```

Om Entity framework te installeren in een nieuw project moet
de NuGET package manager worden gebruikt:
```
 > Install-Package EntityFramework
 > Enable-Migrations -ContextTypeName <Project>.Models.<Context> -EnableAutomaticMigration:$true
 ```
 
Om unobtrusive Ajax te gebruiken moeten met NuGET volgende packages worden geïnstalleerd:
```
 > Install-Package Microsoft.jQuery.Unobtrusive.Ajax
 > Install-Package jQuery.UI.Combined
 ```
 
 