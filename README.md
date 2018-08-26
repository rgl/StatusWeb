An ASP.NET Framework Web Application using bare IHttpHandlers

To be able to configure the IIS HTTP handlers from `web.config` you must change the `Handlers Mappings` Feature Delegation (at the server level) from `Read Only` to `Read/Write`.

