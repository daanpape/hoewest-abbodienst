howest-abbodienst
==============

Implementatie van het voorbeeldexamen uit 2011-2012 met 
technieken uit ASP.NET MVC5. 

Indien er een SQL Exceptie optreed bij opstarten moet volgende
worden toegevoegd aan web.confg:

<connectionStrings>
<add name="MagazineContext" connectionString="Data Source=(LocalDb)\v11.0;Initial Catalog=MagazineContext;Integrated Security=SSPI;" providerName="System.Data.SqlClient" />
</connectionStrings>

